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
                Profile = Path.Combine(_userDataDir, _profile),
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
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;

                        Log.Error($"Got exception while creating driver for {_profile}.", ex);
                        createInstanceTimes++;
                        if (createInstanceTimes == 3) throw;
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
                var gotoWebTimes = 0;
                while (true)
                {
                    try
                    {
                        _driver.Driver.GoToUrl("https://addon.money/dashboard/");
                        await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return;
                        Log.Error($"Got exception while going to addon web for {_profile}.", ex);
                        gotoWebTimes++;
                        if (gotoWebTimes == 3)
                        {
                            await ApiService.SendError($"Can not go to Dashboard for {_profile}.");
                            return;
                        }
                    }
                }

                int getDataTimes = 0;
                while (true)
                {
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
                        if (getDataTimes == 3) throw;
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
                while (true)
                {
                    try
                    {
                        var addonId = _driver.Driver.GetExtensionId("AddonMoney", "AddonMoney", timeout, token);
                        if (string.IsNullOrWhiteSpace(addonId)) throw new Exception("Can not find add-on Id");

                        _driver.Driver.GoToUrl($"chrome-extension://{addonId}/window.html");
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
                        if (activeTimes == 3) throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while activating extension for {_profile}.", ex);
                await ApiService.SendError($"Got exception while activating extension for {_profile}. Error: {ex.Message}.");
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
