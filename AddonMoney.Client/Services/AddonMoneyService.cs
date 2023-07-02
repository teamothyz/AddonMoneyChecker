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
        private DateTime _nextScanTime;
        private bool _isActive = true;

        public string Profile { get { return _profile; } }

        public AddonMoneyService(string profile)
        {
            _profile = Path.GetFileName(profile);
            _userDataDir = Path.GetDirectoryName(profile) ?? null!;
            _nextScanTime = FrmMain.GetGMT7Now();
        }

        public async Task<AccountInfo?> ScanInfo(CancellationToken token)
        {
            if (_nextScanTime > FrmMain.GetGMT7Now() || !_isActive) return null;
            AccountInfo account = new()
            {
                Profile = Path.Combine(_userDataDir, _profile)
            };
            try
            {
                var timeout = FrmMain.Timeout;
                int createInstanceTimes = 0;
                while (_driver?.Driver == null)
                {
                    if (token.IsCancellationRequested) return null;
                    try
                    {
                        _driver = await Task.Run(() => ChromeDriverInstance.GetInstance(0, 0, isMaximize: true,
                            privateMode: false, isHeadless: false, disableImg: false, token: token, isDeleteProfile: false,
                            keepOneWindow: false, userDataDir: _userDataDir, profile: _profile)).ConfigureAwait(false);

                        if (_driver?.Driver == null)
                        {
                            await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
                            createInstanceTimes++;
                            if (createInstanceTimes == 3) throw new Exception("Create Chrome Driver Instance Failed.");
                            else continue;
                        }
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return null;
                        createInstanceTimes++;
                        if (createInstanceTimes == 3) throw;
                    }
                }

                try
                {
                    _isActive = false;
                    var activeTimes = 0;
                    var addonId = _driver.Driver.GetExtensionId("AddonMoney", "AddonMoney", timeout, token);
                    _driver.Driver.GoToUrl($"chrome-extension://{addonId}/window.html");
                    var statusElm = _driver.Driver.FindElement("#status-addon", timeout, token);

                    while (!statusElm.GetAttribute("class").Contains("active"))
                    {
                        if (activeTimes == 3) throw new Exception("Can not activate AddonMoney extension");
                        _driver.Driver.Click("#status-addon", timeout, token);
                        statusElm = _driver.Driver.FindElement("#status-addon", timeout, token);
                        activeTimes++;
                    }
                    _isActive = true;
                }
                catch (Exception ex)
                {
                    if (token.IsCancellationRequested) return null;
                    Log.Error($"Got exception while checking active extension for {_profile}.", ex);
                    throw new Exception("AddonMoney extension not active");
                }

                var gotoWebTimes = 0;
                while (true)
                {
                    try
                    {
                        _driver.Driver.GoToUrl("https://addon.money/dashboard/");
                        _nextScanTime = FrmMain.GetGMT7Now().AddMinutes(FrmMain.TimeSleep);
                        await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested) return null;
                        gotoWebTimes++;
                        if (gotoWebTimes == 3)
                        {
                            _nextScanTime = FrmMain.GetGMT7Now().AddMinutes(FrmMain.TimeSleep);
                            Log.Error($"Got exception while going to addon web for {_profile}.", ex);
                            throw new Exception("Can not go to Dashboard");
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
                        break;
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return null; 
                        getDataTimes++;
                        if (getDataTimes == 3) throw;
                    }
                }
                return account;
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while scanning info for {_profile}.", ex);
                if (token.IsCancellationRequested) return null;
                account.Success = false;
                account.ErrorMsg = ex.Message;
                return account;
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
        }
    }
}
