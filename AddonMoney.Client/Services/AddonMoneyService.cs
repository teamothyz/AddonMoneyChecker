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

        public string Profile { get { return _profile; } }

        public AddonMoneyService(string profile)
        {
            _profile = Path.GetFileName(profile);
            _userDataDir = Path.GetDirectoryName(profile) ?? null!;
            _nextScanTime = FrmMain.GetGMT7Now();
        }

        public async Task<AccountInfo?> ScanInfo(CancellationToken token)
        {
            if (_nextScanTime > FrmMain.GetGMT7Now()) return null;
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
                            privateMode: false, isHeadless: false, disableImg: false, token: token,
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

                _driver.Driver.GoToUrl("https://addon.money/dashboard/");
                await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);

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
                        getDataTimes++;
                        if (getDataTimes == 3) throw;
                    }
                }
                _nextScanTime = FrmMain.GetGMT7Now().AddMinutes(FrmMain.TimeSleep);
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
    }
}
