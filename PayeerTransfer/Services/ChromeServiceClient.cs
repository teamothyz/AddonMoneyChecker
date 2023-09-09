using ChromeDriverLibrary;
using Serilog;

namespace PayeerTransfer.Services
{
    public class ChromeServiceClient
    {
        private static readonly string _logPrefix = "[ChromeServiceClient]";
        private static MyChromeDriver _myDriver = null!;

        public static async Task Login(int timeout, CancellationToken token)
        {
            try
            {
                await CreateDriver(token);
                _myDriver.Driver.GoToUrl("https://payeer.com/en/auth/");

                var emailElm = _myDriver.Driver.FindElement(@"[name=""email""]", timeout, token);
                _myDriver.Driver.Sendkeys(emailElm, "P1099043173", true, timeout, token);

                var passElm = _myDriver.Driver.FindElement(@"[name=""password""]", timeout, token);
                _myDriver.Driver.Sendkeys(passElm, "Thanhthan1!", true, timeout, token);

                _myDriver.Driver.ClickByJS(".login-form__login-btn.step1", timeout, token);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while getting recaptcha v3 token. Error: {ex}");
                _myDriver?.Close();
                _myDriver = null!;
            }
        }

        private static async Task CreateDriver(CancellationToken token)
        {
            try
            {
                int createInstanceTimes = 0;
                while (_myDriver?.Driver == null)
                {
                    if (token.IsCancellationRequested) return;
                    try
                    {
                        _myDriver = await Task.Run(() => ChromeDriverInstance.GetInstance(0, 0,
                            privateMode: true, isHeadless: false, disableImg: false, token: token,
                            profile: "Profile 26",
                            userDataDir: "C:\\Users\\Tuan\\AppData\\Local\\Google\\Chrome\\User Data",
                            isDeleteProfile: true)).ConfigureAwait(false);

                        if (_myDriver?.Driver == null) throw new Exception("driver is null");
                        _myDriver.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                    }
                    catch
                    {
                        if (token.IsCancellationRequested) return;
                        createInstanceTimes++;
                        if (createInstanceTimes == 2) throw;
                        await Task.Delay(1000, CancellationToken.None).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while creating web driver. Error: {ex}");
                _myDriver?.Close();
            }
        }
    }
}
