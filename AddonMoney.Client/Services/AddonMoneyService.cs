using AddonMoney.Client.Models;
using AddonMoney.Data.API;
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
        private bool _firstAttemp = true;

        public string Profile { get { return _profile; } }

        public AddonMoneyService(string profile)
        {
            _profile = Path.GetFileName(profile);
            _userDataDir = Path.GetDirectoryName(profile) ?? null!;
            _nextScanTime = FrmMain.GetGMT7Now();
        }

        public async Task<AccountInfo?> ScanInfo(CancellationToken token)
        {
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

                        if (_driver?.Driver == null) throw new Exception();
                        else await Task.Delay(5000, token).ConfigureAwait(false);
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return null;
                        createInstanceTimes++;
                        if (createInstanceTimes == 3) throw new Exception("Create Chrome Driver Instance Failed.");
                    }
                }

                if (_firstAttemp)
                {
                    try
                    {
                        _driver.Driver.GoToUrl("https://addon.money/dashboard/");
                        _firstAttemp = false;
                        await Task.Delay(1000, token);
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return null;
                    }
                }

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
                        if (token.IsCancellationRequested) return null;
                        activeTimes++;
                        Log.Error($"Got exception while checking active extension for {_profile}.", ex);
                        if (activeTimes == 3)
                        {
                            var errRq = new UpdateErrorRequest
                            {
                                Host = HostService.GetHostName(),
                                Message = "AddonMoney extension not active"
                            };
                            await ApiService.SendError(errRq);
                            break;
                        }
                    }
                }

                if (_nextScanTime > FrmMain.GetGMT7Now()) return null;
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
                _firstAttemp = true;
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
