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

        public static async Task<Tuple<bool, string?>> Transfer(Account account, CancellationToken token)
        {
            var myDriver = await CreateDriver(account.Proxy?.ToString(), token).ConfigureAwait(false);
            if (myDriver?.Driver == null) return new Tuple<bool, string?>(false, "Cant create chrome driver");

            try
            {
                var endTime = DateTime.Now.AddSeconds(Timeout);
                while (true)
                {
                    try
                    {
                        myDriver.Driver.GoToUrl("https://addon.money");
                        _ = myDriver.Driver.ExecuteScript($"var cookieString = '{account.Cookies}';" +
                            "var cookies = cookieString.split(';');" +
                            "cookies.forEach(function(cookie) { var parts = cookie.split('='); " +
                            "var key = parts[0].trim(); var value = parts[1].trim(); " +
                            "document.cookie = key + '=' + value + ';path=/';});");
                        break;
                    }
                    catch
                    {
                        if (endTime > DateTime.Now) throw;
                        else Task.Delay(500, token).Wait(token);
                    }
                }

                myDriver.Driver.GoToUrl("https://addon.money/dashboard");
                await Task.Delay(3000, CancellationToken.None).ConfigureAwait(false);

                var accountIdElm = myDriver.Driver.FindElement(".account-login", Timeout, token);
                var accountIdStr = myDriver.Driver.GetInnerText(accountIdElm);
                var matchId = Regex.Match(accountIdStr, "(\\d{1,})");
                if (!matchId.Success) throw new InvalidDataException($"Invalid Account Id: {accountIdStr}.");
                var accountId = int.Parse(matchId.Value);

                var limit = int.Parse(myDriver.Driver.FindElement(".my-payout-limit b", Timeout, token).Text);
                var balance = int.Parse(myDriver.Driver.FindElement("#balance", Timeout, token).Text);
                var withdrawAmount = (balance > limit ? limit : balance) / 100 * 100;
                if (withdrawAmount < 100)
                {
                    Log.Error($"{_logPrefix} Not enough balance of {accountId}.");
                    return new Tuple<bool, string?>(false, $"Not enough balance: {balance}");
                }
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

            SUBMIT_CAPTCHA:
                var captchaToken = await GetCaptchaResponse(token);
                var captchaResElm = myDriver.Driver.FindElement("#g-recaptcha-response", Timeout, token);
                myDriver.Driver.SetInnerHtml(captchaResElm, captchaToken, true, Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var sendTime = DateTime.Now;
                myDriver.Driver.Click("#payout-action", Timeout, token);
                var messageStatus = myDriver.Driver.FindElement(".payout-form-error.active", Timeout, token).Text;
                if (messageStatus.Contains("code to your telegram to confirm the payment"))
                {
                    var code = await TeleService.GetOTPByPy(account, sendTime, token);
                    if (code == null)
                    {
                        Log.Error($"{_logPrefix} Can not find the otp code from telegram for withdraw to payeer {account.PayeerId}.");
                        return new Tuple<bool, string?>(false, "Can not find the otp code from telegram");
                    }

                    var codeElm = myDriver.Driver.FindElement(@"[name=""code""]", Timeout, token);
                    myDriver.Driver.Sendkeys(codeElm, code, true, Timeout, token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    myDriver.Driver.Click(".close-pay.close-pay-aprove", Timeout, token);

                    endTime = DateTime.Now.AddSeconds(Timeout);
                    while (endTime > DateTime.Now)
                    {
                        var status = myDriver.Driver.FindElement(".payout-form-error.active", Timeout, token).GetAttribute("class");
                        if (status.Contains("good")) return new Tuple<bool, string?>(true, null);
                        else if (status.Contains("bad"))
                        {
                            var msg = myDriver.Driver.FindElement(".payout-form-error", Timeout, token).Text;
                            return new Tuple<bool, string?>(false, msg);
                        }
                        await Task.Delay(1000, token).ConfigureAwait(false);
                    }
                }
                else if (messageStatus.Contains("you need to link your telegram account"))
                {
                    var link = myDriver.Driver.FindElement("a.close-pay", Timeout, token).GetAttribute("href");
                    var linkToken = link.Split("=")[1];
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    var success = await TeleService.LinkAccount(account, linkToken);
                    if (!success) return new Tuple<bool, string?>(false, "link account failed");

                    myDriver.Driver.ClickByJS("button.close-pay", Timeout, token);
                    await Task.Delay(1000, token).ConfigureAwait(false);

                    goto SUBMIT_CAPTCHA;
                }
                else
                {
                    return new Tuple<bool, string?>(false, messageStatus);
                }
                return new Tuple<bool, string?>(false, $"waiting for result timeout after {Timeout}s");
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while transfer balance to payeer {account.PayeerId}. Error: {ex}");
                return new Tuple<bool, string?>(false, ex.Message);
            }
            finally
            {
                await ChromeDriverInstance.Close(myDriver);
            }
        }

        private static async Task<MyChromeDriver?> CreateDriver(string? proxy, CancellationToken token)
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
                            privateMode: false, isHeadless: false, disableImg: true, token: token,
                            isDeleteProfile: true, keepOneWindow: true, proxy: proxy))
                            .ConfigureAwait(false);

                        if (_driver?.Driver == null) throw new Exception("driver is null");
                        _driver.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
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
                Log.Error($"{_logPrefix} Got exception while creating web driver. Error: {ex}");
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
