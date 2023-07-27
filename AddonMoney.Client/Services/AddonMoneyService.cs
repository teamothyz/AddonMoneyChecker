using AddonMoney.Client.Models;
using ChromeDriverLibrary;
using Serilog;
using System.Text.RegularExpressions;

namespace AddonMoney.Client.Services
{
    public class AddonMoneyService
    {
        private readonly object _lock = new();

        private MyChromeDriver _driver = null!;
        private string _extensionId = null!;
        public readonly string ProfileName = null!;

        private bool _loginAccountSuccess = false;
        private bool _firstTimeActive = true;
        private bool _firstTimeCookie = true;
        private readonly string _proxy = null!;
        public ProfileInfo ProfileInfo { get; private set; }

        public AddonMoneyService(ProfileInfo profileInfo, int index)
        {
            ProfileName = $"Profile {index}";
            ProfileInfo = profileInfo;
            _proxy = FrmMain.ProxyPrefix + ProfileInfo.Proxy;
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
                    Log.Error($"Keep alive exception of {ProfileName}. Error: {ex}");
                }
                finally
                {
                    Task.Delay(15000).Wait();
                }
            }
        }

        public AccountInfo ScanInfo(bool needToScan, CancellationToken token)
        {
            lock (_lock)
            {
                AccountInfo account = new()
                {
                    Profile = ProfileName,
                    Success = false,
                    Email = ProfileInfo.Email
                };
                try
                {
                    CreateDriverTask(token).Wait(token);
                    if (_driver?.Driver == null) return account;
                    Task.Delay(500, token).Wait(token);
                    
                    var endTime = DateTime.Now.AddSeconds(FrmMain.Timeout);
                    while (_firstTimeCookie)
                    {
                        try
                        {
                            _ = _driver.Driver.ExecuteScript($"var cookieString = '{ProfileInfo.Cookies}';" +
                            "var cookies = cookieString.split(';');" +
                            "cookies.forEach(function(cookie) { var parts = cookie.split('='); " +
                            "var key = parts[0].trim(); var value = parts[1].trim(); " +
                            "document.cookie = key + '=' + value + ';path=/';});");
                            _firstTimeCookie = false;
                        }
                        catch
                        {
                            if (endTime > DateTime.Now) throw;
                            else Task.Delay(500, token).Wait(token);
                        }
                    }

                    var timeout = FrmMain.Timeout;
                    if (needToScan)
                    {
                        GetDataTask(account, timeout, token).Wait(token);
                        Task.Delay(1000, token).Wait(token);
                    }
                    else account.Success = false;
                    if (_loginAccountSuccess)
                    {
                        ActivateAddonTask(timeout, token).Wait(token);
                    }
                    return account;
                }
                catch (Exception ex)
                {
                    Log.Error($"Got exception while scanning info for {ProfileName}.", ex);
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
                            privateMode: false, isHeadless: false, disableImg: true, token: token, 
                            isDeleteProfile: true, keepOneWindow: false, proxy: _proxy))
                            .ConfigureAwait(false);

                        if (_driver?.Driver == null) throw new Exception("driver is null");
                        _driver.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;

                        Log.Error($"Got exception while creating driver for {ProfileName}.", ex);
                        createInstanceTimes++;
                        if (createInstanceTimes == 2) throw;
                        await Task.Delay(1000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while creating web driver for {ProfileName}.", ex);
                await ApiService.SendError($"Create chrome driver failed for {ProfileName}. Error: {ex.Message}.").ConfigureAwait(false);
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
                        account.Success = true;
                        break;
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return;
                        getDataTimes++;
                        if (getDataTimes == 2) throw;

                        if (_driver.Driver.Url.Contains("google.com"))
                        {
                            _loginAccountSuccess = false;
                            await ApiService.SendError($"Login account by cookies failed {ProfileName}.").ConfigureAwait(false);
                            return;
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
                Log.Error($"Got exception while getting account info for {ProfileName}.", ex);
                await ApiService.SendError($"Got exception while getting account info for {ProfileName}. Error: {ex.Message}.").ConfigureAwait(false);
            }
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
                        Log.Error($"Got exception while checking active extension for {ProfileName}.", ex);
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
                Log.Error($"Got exception while activating extension for {ProfileName}.", ex);
                await ApiService.SendError($"Got exception while activating extension for {ProfileName}. Error: {ex.Message}.").ConfigureAwait(false);
            }
        }

        public async Task Close()
        {
            try
            {
                await Task.Run(() => _driver.Close()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while closing profile {ProfileName}.", ex);
            }
            finally
            {
                _driver = null!;
            }
        }
    }
}
