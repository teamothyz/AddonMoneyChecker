using AddonMoney.Client.Models;
using ChromeDriverLibrary;
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

        public string Profile { get { return _profile; } }

        public AddonMoneyService(string profile)
        {
            _profile = Path.GetFileName(profile);
            _userDataDir = Path.GetDirectoryName(profile) ?? null!;
        }

        public async Task<AccountInfo> ScanInfo(bool needToScan, CancellationToken token)
        {
            AccountInfo account = new()
            {
                Profile = _profile,
                Success = false
            };
            try
            {
                await CreateDriverTask(token);
                if (_driver?.Driver == null) return account;

                var timeout = FrmMain.Timeout;
                if (needToScan) await GetDataTask(account, timeout, token).ConfigureAwait(false);
                else account.Success = false;

                await ActivateAddonTask(timeout, token).ConfigureAwait(false);
                return account;
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while scanning info for {_profile}.", ex);
                return account;
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
                            privateMode: false, isHeadless: false, disableImg: false, token: token, isDeleteProfile: false,
                            keepOneWindow: false, userDataDir: _userDataDir, profile: _profile)).ConfigureAwait(false);

                        if (_driver?.Driver == null) throw new Exception("driver is null");
                        else await Task.Delay(5000, token).ConfigureAwait(false);
                        _driver.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(FrmMain.Timeout);
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;

                        Log.Error($"Got exception while creating driver for {_profile}.", ex);
                        createInstanceTimes++;
                        if (createInstanceTimes == 2) throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while creating web driver for {_profile}.", ex);
                await ApiService.SendError($"Create chrome driver failed for {_profile}. Error: {ex.Message}.");
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
                    GotoUrl("https://addon.money/dashboard/", token);
                    await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
                    try
                    {
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

                        account.Success = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;
                        Log.Error($"Got exception while getting balance in the addon web for {_profile}.", ex);
                        getDataTimes++;
                        if (getDataTimes == 2) throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while getting account info for {_profile}.", ex);
                await ApiService.SendError($"Got exception while getting account info for {_profile}. Error: {ex.Message}.");
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
                }
                
                while (true)
                {
                    GotoUrl($"chrome-extension://{_extensionId}/window.html", token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    try
                    {
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
                        GotoUrl("https://addon.money/dashboard/", token);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while activating extension for {_profile}.", ex);
                await ApiService.SendError($"Got exception while activating extension for {_profile}. Error: {ex.Message}.");
            }
        }

        private async void GotoUrl(string url, CancellationToken token)
        {
            try
            {
                _driver.Driver.GoToUrl(url);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The HTTP request to the remote WebDriver server for URL")
                    || ex.Message.Contains("no such window"))
                {
                    await Close();
                    await Task.Delay(5000, token);
                    await CreateDriverTask(token);
                    await ActivateAddonTask(FrmMain.Timeout, token);
                }
                throw;
            }
        }

        public async Task Close()
        {
            try
            {
                if (_driver?.Driver == null) return;
                await Task.Run(() => _driver.Close());
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while closing profile {_profile}.", ex);
            }
            finally { _driver = null!; }
        }
    }
}
