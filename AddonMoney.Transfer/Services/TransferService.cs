using AddonMoney.Transfer.Models;
using CaptchaResolver.Clients;
using ChromeDriverLibrary;
using Serilog;
using System.Text.RegularExpressions;

namespace AddonMoney.Transfer.Services
{
    public class TransferService
    {
        private static readonly string _logPrefix = "[TransferService]";
        public static int Timeout { get; set; } = 30;

        public static async Task<Tuple<bool, string?>> Transfer(DriverProfile profile, CancellationToken token)
        {
            try
            {
                var myDriver = await CreateDriver(profile, token).ConfigureAwait(false);
                if (myDriver?.Driver == null) return new Tuple<bool, string?>(false, "Cant create chrome driver");

                myDriver.Driver.GoToUrl("https://addon.money/dashboard/");
                await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);

                var accountIdElm = myDriver.Driver.FindElement(".account-login", Timeout, token);
                var accountIdStr = myDriver.Driver.GetInnerText(accountIdElm);
                var matchId = Regex.Match(accountIdStr, "(\\d{1,})");
                if (!matchId.Success) throw new InvalidDataException($"Invalid Account Id: {accountIdStr}.");
                var accountId = int.Parse(matchId.Value);

                var account = Account.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                if (account == null)
                {
                    Log.Error($"{_logPrefix} Not found account {accountId} from the input data.");
                    return new Tuple<bool, string?>(false, $"Not found account {accountId} from the input data");
                }

                var limit = int.Parse(myDriver.Driver.FindElement(".my-payout-limit b", Timeout, token).Text);
                var balance = int.Parse(myDriver.Driver.FindElement("#balance", Timeout, token).Text);
                var withdrawAmount = (balance > limit ? limit : balance) / 100 * 100;

                myDriver.Driver.Click(@".payeer[for=""payout6""]", Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var payoutAccountElm = myDriver.Driver.FindElement("#payout-account", Timeout, token);
                if (payoutAccountElm.GetAttribute("placeholder") != "P1000000000")
                {
                    myDriver.Driver.ClickByJS(@".payeer[for=""payout6""]", Timeout, token);
                }
                myDriver.Driver.Sendkeys(payoutAccountElm, account.PayeerId, true, Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var amountElm = myDriver.Driver.FindElement("#payout-value", Timeout, token);
                myDriver.Driver.Sendkeys(amountElm, withdrawAmount.ToString(), true, Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var captchaToken = await GetCaptchaResponse(token);
                var captchaResElm = myDriver.Driver.FindElement("#g-recaptcha-response", Timeout, token);
                myDriver.Driver.SetInnerHtml(captchaResElm, captchaToken, true, Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var sendTime = DateTime.Now;
                myDriver.Driver.Click("#payout-action", Timeout, token);

                var code = await TeleService.GetOTP(account, sendTime, token);
                if (code == null)
                {
                    Log.Error($"{_logPrefix} Can not find the otp code from telegram for {profile.Profile}.");
                    return new Tuple<bool, string?>(false, "Can not find the otp code from telegram");
                }

                var codeElm = myDriver.Driver.FindElement(@"[name=""code""]", Timeout, token);
                myDriver.Driver.Sendkeys(codeElm, code, true, Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                myDriver.Driver.Click(".close-pay.close-pay-aprove", Timeout, token);
                return new Tuple<bool, string?>(true, null);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while transfer balance for {profile.Profile}. Error: {ex}");
                return new Tuple<bool, string?>(false, ex.Message);
            }
        }

        private static async Task<MyChromeDriver?> CreateDriver(DriverProfile profile, CancellationToken token)
        {
            MyChromeDriver? _driver = null;
            try
            {
                int createInstanceTimes = 0;
                while (_driver?.Driver == null)
                {
                    if (token.IsCancellationRequested) return null;
                    try
                    {
                        _driver = await Task.Run(() => ChromeDriverInstance.GetInstance(0, 0, isMaximize: true,
                            privateMode: false, isHeadless: false, disableImg: false, token: token, isDeleteProfile: false,
                            keepOneWindow: false, userDataDir: profile.UserDataDir, profile: profile.Profile))
                            .ConfigureAwait(false);

                        if (_driver?.Driver == null) throw new Exception("driver is null");
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return null;
                        createInstanceTimes++;
                        if (createInstanceTimes == 2) throw;
                    }
                    finally
                    {
                        await Task.Delay(5000, token).ConfigureAwait(false);
                    }
                }
                return _driver;
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while creating web driver for {profile.Profile}. Error: {ex}");
                return null;
            }
        }

        private static async Task<string> GetCaptchaResponse(CancellationToken token)
        {
            var resolveTimes = 0;
            while (true)
            {
                try
                {
                    return await CaptchaV2Client.GetToken(token);
                }
                catch
                {
                    resolveTimes++;
                    if (resolveTimes == 2) throw;
                    await Task.Delay(1000, token).ConfigureAwait(false);
                }
            }
        }
    }
}
