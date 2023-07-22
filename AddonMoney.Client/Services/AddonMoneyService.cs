using AddonMoney.Client.Models;
using ChromeDriverLibrary;
using OpenQA.Selenium;
using Serilog;
using System.Text.RegularExpressions;

namespace AddonMoney.Client.Services
{
    public class AddonMoneyService
    {
        private readonly object _lock = new();

        private MyChromeDriver _driver = null!;
        private readonly string _userDataDir = null!;
        private readonly string _profile = null!;
        private string _extensionId = null!;

        private string _referral = string.Empty;

        private bool _firstTimeActive = true;
        private bool _firstTimeGotoAddon = true;
        private bool _firstTimeCookie = true;

        private bool _loginAccountSuccess = false;
        private bool _loginFirstTimeSuccess = false;

        public ProfileInfo ProfileInfo { get; private set; }

        public string Profile { get => _profile; }

        public AddonMoneyService(string profile, string proxyPrefix)
        {
            ProfileInfo = new ProfileInfo(profile, proxyPrefix);
            _profile = Path.GetFileName(ProfileInfo.ProfilePath);
            _userDataDir = Path.GetDirectoryName(ProfileInfo.ProfilePath) ?? null!;
            Task.Run(() => KeepAlive());
        }

        private void KeepAlive()
        {
            while (true)
            {
                try
                {
                    lock (_lock)
                    {
                        _driver?.Driver?.GoToUrl("about:blank");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Keep alive exception of {_profile}. Error: {ex}");
                }
                finally
                {
                    Task.Delay(15000).Wait();
                }
            }
        }

        public AccountInfo ScanInfo(bool needToScan, CancellationToken token)
        {
            if (!string.IsNullOrEmpty(FrmMain.ReferLinkRoot))
            {
                if (FrmMain.OnlyRootLink)
                {
                    _referral = FrmMain.ReferLinkRoot;
                }
                else if (!string.IsNullOrEmpty(FrmMain.ReferLinkFirst))
                {
                    if (!string.IsNullOrEmpty(FrmMain.ReferLinkSecond))
                    {
                        _referral = FrmMain.ReferLinkSecond;
                    }
                    else
                    {
                        _referral = FrmMain.ReferLinkFirst;
                    }
                }
                else
                {
                    _referral = FrmMain.ReferLinkRoot;
                }
            }
            else
            {
                _referral = string.Empty;
            }
            lock (_lock)
            {
                AccountInfo account = new()
                {
                    Profile = _profile,
                    Success = false,
                    Email = ProfileInfo.Email
                };
                try
                {
                    CreateDriverTask(token).Wait(token);
                    if (_driver?.Driver == null) return account;

                    Task.Delay(500, token).Wait(token);
                    if (FrmMain.ClearCookies && _firstTimeCookie)
                    {
                        _driver.Driver.GoToUrl("https://addon.money");
                        _driver.Driver.Manage().Cookies.DeleteAllCookies();
                        Task.Delay(500, token).Wait(token);

                        _driver.Driver.GoToUrl("https://www.google.com/");
                        _driver.Driver.Manage().Cookies.DeleteAllCookies();
                        Task.Delay(500, token).Wait(token);

                        _firstTimeCookie = false;
                    }

                    var timeout = FrmMain.Timeout;
                    if (needToScan)
                    {
                        GetDataTask(account, timeout, token).Wait(token);
                        Task.Delay(1000, token).Wait(token);
                    }
                    else account.Success = false;

                    if (_loginAccountSuccess || _loginFirstTimeSuccess)
                    {
                        ActivateAddonTask(timeout, token).Wait(token);
                    }
                    return account;
                }
                catch (Exception ex)
                {
                    Log.Error($"Got exception while scanning info for {_profile}.", ex);
                    return account;
                }
            }
        }

        private async Task CreateDriverTask(CancellationToken token)
        {
            try
            {
                int createInstanceTimes = 0;
                while (_driver?.Driver == null)
                {
                    if (token.IsCancellationRequested) return;
                    try
                    {
                        _driver = await Task.Run(() => ChromeDriverInstance.GetInstance(0, 0, isMaximize: true,
                            privateMode: false, isHeadless: false, disableImg: true, token: token, isDeleteProfile: false,
                            keepOneWindow: false, userDataDir: _userDataDir, profile: _profile, proxy: ProfileInfo.Proxy)).ConfigureAwait(false);

                        if (_driver?.Driver == null) throw new Exception("driver is null");
                        _driver.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(FrmMain.Timeout);
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;

                        Log.Error($"Got exception while creating driver for {_profile}.", ex);
                        createInstanceTimes++;
                        if (createInstanceTimes == 2) throw;
                        await Task.Delay(1000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while creating web driver for {_profile}.", ex);
                await ApiService.SendError($"Create chrome driver failed for {_profile}. Error: {ex.Message}.").ConfigureAwait(false);
                _driver = null!;
            }
        }

        private async Task GetDataTask(AccountInfo account, int timeout, CancellationToken token)
        {
            try
            {
                int getDataTimes = 0;
                while (true)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(_referral) && _firstTimeGotoAddon)
                        {
                            _driver.Driver.GoToUrl(_referral);
                            var endTime = DateTime.Now.AddSeconds(timeout);
                            while (DateTime.Now < endTime)
                            {
                                try
                                {
                                    var success = (bool)_driver.Driver.ExecuteScript("return document.cookie.includes('partner=');");
                                    if (success) break;
                                }
                                catch { }
                                finally
                                {
                                    await Task.Delay(1000, token).ConfigureAwait(false);
                                }
                            }
                            _firstTimeGotoAddon = false;
                        }

                        var loginGGTimes = 0;
                        while (!_loginFirstTimeSuccess)
                        {
                            _loginFirstTimeSuccess = await LoginGoogleFirstTime(timeout, token);
                            loginGGTimes++;
                            if (loginGGTimes == 2) break;
                            await Task.Delay(1000, token).ConfigureAwait(false);
                        }

                        await GetAccountInfo(account, timeout, token).ConfigureAwait(false);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;
                        getDataTimes++;
                        if (getDataTimes == 2) throw;

                        if (_driver.Driver.Url.Contains("google.com"))
                        {
                            if (_loginFirstTimeSuccess && !_loginAccountSuccess)
                            {
                                _loginAccountSuccess = await LoginGoogle(timeout, token).ConfigureAwait(false);
                            }
                            if (!_loginAccountSuccess)
                            {
                                await ApiService.SendError($"Login google account failed. {ex.Message}.").ConfigureAwait(false);
                                return;
                            }
                        }
                    }
                    finally
                    {
                        _driver.Driver.GoToUrl("about:blank");
                        await Task.Delay(1000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while getting account info for {_profile}.", ex);
                await ApiService.SendError($"Got exception while getting account info for {_profile}. Error: {ex.Message}.").ConfigureAwait(false);
            }
        }

        private async Task GetAccountInfo(AccountInfo account, int timeout, CancellationToken token)
        {
            _driver.Driver.GoToUrl("https://addon.money/auth/index.php?social=yt");
            await Task.Delay(1000, token).ConfigureAwait(false);

            var accountNameElm = _driver.Driver.FindElement(".account-name", timeout, token);
            account.Name = _driver.Driver.GetInnerText(accountNameElm);

            var accountIdElm = _driver.Driver.FindElement(".account-login", timeout, token);
            var accountIdStr = _driver.Driver.GetInnerText(accountIdElm);
            var matchId = Regex.Match(accountIdStr, "(\\d{1,})");
            if (!matchId.Success) throw new InvalidDataException($"Invalid Account Id: {accountIdStr}.");
            account.Id = int.Parse(matchId.Value);

            var balanceElm = _driver.Driver.FindElement("#balance", timeout, token);
            var balanceStr = _driver.Driver.GetInnerText(balanceElm);
            account.Balance = int.Parse(balanceStr);

            var todayEarnElm = _driver.Driver.FindElement(".left .item:nth-child(2) .currency", timeout, token);
            var todayEarnStr = _driver.Driver.GetInnerText(todayEarnElm);
            account.TodayEarn = int.Parse(todayEarnStr);

            var earningLevelElm = _driver.Driver.FindElement(".informers .item:nth-child(3) .i-counter", timeout, token);
            account.EarningLevel = _driver.Driver.GetInnerText(earningLevelElm);

            var refLink = _driver.Driver.FindElement("#reflink", timeout, token).GetAttribute("value");
            if (string.IsNullOrEmpty(FrmMain.ReferLinkFirst)) FrmMain.ReferLinkFirst = refLink;
            else if (string.IsNullOrEmpty(FrmMain.ReferLinkSecond)) FrmMain.ReferLinkSecond = refLink;

            account.Success = true;
        }

        private async Task<bool> LoginGoogleFirstTime(int timeout, CancellationToken token)
        {
            try
            {
                _driver.Driver.GoToUrl("https://accounts.google.com/v3/signin/identifier?flowName=GlifWebSignIn");
                await Task.Delay(1000, token).ConfigureAwait(false);

                var emailElm = _driver.Driver.FindElement("#identifierId", timeout, token);
                _driver.Driver.SendkeysRandom(emailElm, ProfileInfo.Email, true, true, timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var passwordElm = _driver.Driver.FindElement(@"[autocomplete=""current-password""]", timeout, token);
                _driver.Driver.SendkeysRandom(passwordElm, ProfileInfo.Password, true, true, timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                try
                {
                    _ = _driver.Driver.FindElement(@"[data-p*=""myaccount.google.com""]", timeout, token);
                    return true;
                }
                catch
                {
                    var challenge = _driver.Driver.FindElement(@"[data-challengetype=""12""]", 5, token);
                    _driver.Driver.ClickByJS(@"[data-challengetype=""12""]", timeout, token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    var recoveryMailElm = _driver.Driver.FindElement(@"[name=""knowledgePreregisteredEmailResponse""]", timeout, token);
                    _driver.Driver.SendkeysRandom(recoveryMailElm, ProfileInfo.RecoveryMail, true, true, timeout, token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    _driver.Driver.GoToUrl("https://myaccount.google.com");
                    await Task.Delay(1000, token).ConfigureAwait(false);
                    _ = _driver.Driver.FindElement(@"[data-p*=""myaccount.google.com""]", timeout, token);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while login account first time for {_profile}.", ex);
                return false;
            }
        }

        private async Task<bool> LoginGoogle(int timeout, CancellationToken token)
        {
            if (_driver.Driver.Url.Contains("google.com"))
            {
                try
                {
                    if (_driver.Driver.Url.Contains("oauthchooseaccount"))
                    {
                        _driver.Driver.Click("ul li:nth-last-child(1)", timeout, token);
                        await Task.Delay(1000, token).ConfigureAwait(false);
                    }

                    var emailElm = _driver.Driver.FindElement("#identifierId", timeout, token);
                    _driver.Driver.SendkeysRandom(emailElm, ProfileInfo.Email, true, true, timeout, token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    var passwordElm = _driver.Driver.FindElement(@"[autocomplete=""current-password""]", timeout, token);
                    _driver.Driver.SendkeysRandom(passwordElm, ProfileInfo.Password, true, true, timeout, token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    try
                    {
                        _ = _driver.Driver.FindElement(".account-name", timeout, token);
                        return true;
                    }
                    catch
                    {
                        var challenge = _driver.Driver.FindElement(@"[data-challengetype=""12""]", 5, token);
                        _driver.Driver.ClickByJS(@"[data-challengetype=""12""]", timeout, token);
                        await Task.Delay(1000, token).ConfigureAwait(false);

                        var recoveryMailElm = _driver.Driver.FindElement(@"[name=""knowledgePreregisteredEmailResponse""]", timeout, token);
                        _driver.Driver.SendkeysRandom(recoveryMailElm, ProfileInfo.RecoveryMail, true, true, timeout, token);
                        await Task.Delay(1000, token).ConfigureAwait(false);

                        _ = _driver.Driver.FindElement(".account-name", timeout, token);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Got exception while login account for {_profile}.", ex);
                    return false;
                }
            }
            return true;
        }

        private async Task ActivateAddonTask(int timeout, CancellationToken token)
        {
            try
            {
                var activeTimes = 0;
                if (string.IsNullOrWhiteSpace(_extensionId))
                {
                    _extensionId = _driver.Driver.GetExtensionId("AddonMoney", "AddonMoney", timeout, token);
                    if (string.IsNullOrWhiteSpace(_extensionId)) throw new Exception("Can not find add-on Id");
                    await Task.Delay(1000, token).ConfigureAwait(false);
                }

                while (true)
                {
                    try
                    {
                        _driver.Driver.GoToUrl($"chrome-extension://{_extensionId}/window.html");
                        await Task.Delay(1000, token).ConfigureAwait(false);

                        var statusElm = _driver.Driver.FindElement("#status-addon", timeout, token);
                        if (_firstTimeActive)
                        {
                            await Task.Delay(1000, token).ConfigureAwait(false);
                            _driver.Driver.Click("#status-addon", timeout, token);
                            _firstTimeActive = false;
                        }

                        await Task.Delay(1000, token).ConfigureAwait(false);
                        statusElm = _driver.Driver.FindElement("#status-addon", timeout, token);
                        if (!statusElm.GetAttribute("class").Contains("active"))
                        {
                            await Task.Delay(1000, token).ConfigureAwait(false);
                            _driver.Driver.Click("#status-addon", timeout, token);
                            statusElm = _driver.Driver.FindElement("#status-addon", timeout, token);

                            await Task.Delay(1000, token).ConfigureAwait(false);
                            if (!statusElm.GetAttribute("class").Contains("active")) throw new Exception("Can not activate AddonMoney extension");
                        }
                        await Task.Delay(1000, token).ConfigureAwait(false);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;
                        Log.Error($"Got exception while checking active extension for {_profile}.", ex);
                        activeTimes++;
                        if (activeTimes == 2) throw;
                        _driver.Driver.GoToUrl("https://addon.money/auth/index.php?social=yt");
                    }
                    finally
                    {
                        await Task.Delay(1000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while activating extension for {_profile}.", ex);
                await ApiService.SendError($"Got exception while activating extension for {_profile}. Error: {ex.Message}.").ConfigureAwait(false);
            }
        }

        public async Task Close()
        {
            try
            {
                if (_driver?.Driver == null) return;
                await Task.Run(() => _driver.Close()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while closing profile {_profile}.", ex);
            }
            finally
            {
                _driver = null!;
            }
        }
    }
}
