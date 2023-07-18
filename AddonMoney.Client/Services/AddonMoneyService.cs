using AddonMoney.Client.Models;
using ChromeDriverLibrary;
using OpenQA.Selenium;
using Serilog;
using System.Text.RegularExpressions;

namespace AddonMoney.Client.Services
{
    public class AddonMoneyService
    {
        private MyChromeDriver _driver = null!;
        private readonly string _userDataDir = null!;
        private readonly string _profile = null!;
        private string _extensionId = null!;
        private readonly object _lock = new();
        public ProfileInfo ProfileInfo { get; private set; }
        public string Profile { get { return _profile; } }
        private string _referral = string.Empty;

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
                if (!string.IsNullOrEmpty(FrmMain.ReferLinkFirst))
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
                    Success = false
                };
                try
                {
                    CreateDriverTask(token).Wait(token);
                    if (_driver?.Driver == null) return account;
                    Task.Delay(3000, token).Wait(token);

                    var timeout = FrmMain.Timeout;
                    if (needToScan)
                    {
                        GetDataTask(account, timeout, token).Wait(token);
                        Task.Delay(3000, token).Wait(token);
                    }
                    else account.Success = false;

                    ActivateAddonTask(timeout, token).Wait(token);
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
                    }
                    finally
                    {
                        await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
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
                var loginAccount = false;
                while (true)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(_referral))
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
                                    await Task.Delay(3000, token).ConfigureAwait(false);
                                }
                            }
                        }

                        if (!loginAccount)
                        {
                            _driver.Driver.GoToUrl("https://addon.money/auth/index.php?social=yt");
                            await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
                        }

                        loginAccount = false;
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
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;
                        loginAccount = await LoginGoogle(timeout, token).ConfigureAwait(false);
                        await Task.Delay(3000, token).ConfigureAwait(false);

                        getDataTimes++;
                        if (getDataTimes == 2) throw;
                        if (!loginAccount)
                        {
                            Log.Error($"Got exception while getting balance in the addon web for {_profile}.", ex);
                            _driver.Driver.GoToUrl("about:blank");
                        }
                    }
                    finally
                    {
                        await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while getting account info for {_profile}.", ex);
                await ApiService.SendError($"Got exception while getting account info for {_profile}. Error: {ex.Message}.").ConfigureAwait(false);
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
                        await Task.Delay(3000, token).ConfigureAwait(false);
                    }

                    var emailElm = _driver.Driver.FindElement("#identifierId", timeout, token);
                    _driver.Driver.SendkeysRandom(emailElm, ProfileInfo.Email, true, true, timeout, token);
                    await Task.Delay(5000, token).ConfigureAwait(false);

                    var passwordElm = _driver.Driver.FindElement(@"[autocomplete=""current-password""]", timeout, token);
                    _driver.Driver.SendkeysRandom(passwordElm, ProfileInfo.Password, true, true, timeout, token);
                    await Task.Delay(5000, token).ConfigureAwait(false);

                    _ = _driver.Driver.FindElement(".account-name", timeout * 2, token);
                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error($"Got exception while login account for {_profile}.", ex);
                    await ApiService.SendError($"Got exception while logining account for {_profile}. Error: {ex.Message}.").ConfigureAwait(false);
                }
            }
            return false;
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
                        _driver.Driver.GoToUrl("https://addon.money/dashboard/");
                    }
                    finally
                    {
                        await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
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
