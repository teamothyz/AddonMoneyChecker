using ChromeDriverLibrary;
using Serilog;

namespace PayeerTransfer.Services
{
    public class RecaptchaV3Service
    {
        private static readonly string _logPrefix = "[RecaptchaV3Service]";
        private static bool _isInPage = false;
        private static MyChromeDriver _myDriver = null!;

        public static async Task<string> GetToken(int timeout, CancellationToken token)
        {
            try
            {
                await CreateDriver(token);
                if (!_isInPage)
                {
                    _myDriver.Driver.GoToUrl("https://payeer.com/en/auth/");
                    _isInPage = true;
                }

                var emailElm = _myDriver.Driver.FindElement(@"[name=""email""]", timeout, token);
                _myDriver.Driver.Sendkeys(emailElm, "P1100737635", true, timeout, token);

                var passElm = _myDriver.Driver.FindElement(@"[name=""password""]", timeout, token);
                _myDriver.Driver.Sendkeys(passElm, "Tuan552001", true, timeout, token);

                _myDriver.Driver.ClickByJS(".login-form__login-btn.step1", timeout, token);

                var endTime = DateTime.Now.AddSeconds(timeout);
                while (endTime > DateTime.Now)
                {
                    try
                    {
                        var captchaToken = (string)_myDriver.Driver.ExecuteAsyncScript("var done = arguments[0];" +
                        "grecaptcha.enterprise.execute('6LdBMlYbAAAAAI4GL2slroFt9JLP32VguWiTQP9N'," +
                        "{action: 'authorization'})" +
                        ".then((res) => {return done(res);})");
                        if (string.IsNullOrEmpty(captchaToken)) throw new Exception();
                        return captchaToken;
                    }
                    catch
                    {
                        await Task.Delay(3000, token);
                    }
                }
                throw new Exception($"get captcha v3 token timed out after {timeout}s");
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while getting recaptcha v3 token. Error: {ex}");
                _myDriver?.Close();
                _myDriver = null!;
                _isInPage = false;
                return string.Empty;
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
                            privateMode: false, isHeadless: false, disableImg: true, token: token,
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
