using ChromeDriverLibrary;
using Serilog;

namespace PayeerTransfer.Services
{
    public class ChromeServiceClient
    {
        private static readonly string _logPrefix = "[ChromeServiceClient]";

        public static async Task StartSending(int timeout, CancellationToken token)
        {
            MyChromeDriver myDriver = null!;
            try
            {
                myDriver = await CreateDriver(token);
                await Login(myDriver, timeout, token);
                await Send(myDriver, timeout, token);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Start sending error: {ex}");
            }
            finally
            {
                myDriver?.Close();
            }
        }

        private static async Task<bool?> Login(MyChromeDriver myDriver, int timeout, CancellationToken token)
        {
            try
            {
                myDriver.Driver.GoToUrl("https://payeer.com/en/auth/");

                var emailElm = myDriver.Driver.FindElement(@"[name=""email""]", timeout, token);
                myDriver.Driver.Sendkeys(emailElm, "P1099043173", true, timeout, token);
                await Task.Delay(1000, token);

                var passElm = myDriver.Driver.FindElement(@"[name=""password""]", timeout, token);
                myDriver.Driver.Sendkeys(passElm, "Thanhthan1!", true, timeout, token);
                await Task.Delay(1000, token);

                myDriver.Driver.ClickByJS(".login-form__login-btn.step1", timeout, token);
                var endTime = DateTime.Now.AddSeconds(timeout);
                while (endTime > DateTime.Now)
                {
                    try
                    {
                        _ = myDriver.Driver.FindElement("#btn-account", 3, token);
                        return true;
                    }
                    catch { }
                    try
                    {
                        emailElm = myDriver.Driver.FindElement(@"[name=""email""]", 3, token);
                        var err = emailElm.GetAttribute("class").Contains("error", StringComparison.OrdinalIgnoreCase);
                        if (err) return false;
                    }
                    catch { }
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Login error: {ex}");
                return null;
            }
        }

        private static async Task Send(MyChromeDriver _myDriver, int timeout, CancellationToken token)
        {
            try
            {
                _myDriver.Driver.GoToUrl("https://payeer.com/en/account/send/?currPS=RUB");
                var accountInput = _myDriver.Driver.FindElement(@"input[name=""param_ACCOUNT_NUMBER""]", timeout, token);
                _myDriver.Driver.Sendkeys(accountInput, "", true, timeout, token);
                await Task.Delay(1000, token);

                var codeInput = _myDriver.Driver.FindElement(@"input[name=""protect_code""]", timeout, token);
                _myDriver.Driver.Sendkeys(codeInput, "", true, timeout, token);
                await Task.Delay(1000, token);

                var amountInput = _myDriver.Driver.FindElement(@"input[name=""sum_pay""]", timeout, token);
                _myDriver.Driver.Sendkeys(amountInput, "", true, timeout, token);
                await Task.Delay(1000, token);

                _myDriver.Driver.Click("button > .b_sum_pay", timeout, token);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Send error: {ex}");
            }
        }

        private static async Task<MyChromeDriver> CreateDriver(CancellationToken token)
        {
            MyChromeDriver myDriver = null!;
            try
            {
                int createInstanceTimes = 0;
                while (myDriver?.Driver == null)
                {
                    if (token.IsCancellationRequested) break;
                    try
                    {
                        myDriver = await Task.Run(() => ChromeDriverInstance.GetInstance(0, 0,
                            privateMode: true, isHeadless: false, disableImg: false, token: token,
                            isDeleteProfile: true)).ConfigureAwait(false);

                        if (myDriver?.Driver == null) throw new Exception("driver is null");
                        myDriver.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) break;
                        createInstanceTimes++;
                        if (createInstanceTimes == 2) throw;
                        await Task.Delay(1000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Creating web driver error: {ex}");
                myDriver?.Close();
                myDriver = null!;
            }
            finally
            {
                if (token.IsCancellationRequested)
                {
                    myDriver?.Close();
                    myDriver = null!;
                }
            }
            return myDriver;
        }
    }
}
