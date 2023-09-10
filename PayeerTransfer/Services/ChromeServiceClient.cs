using ChromeDriverLibrary;
using PayeerTransfer.Models;
using Serilog;
using System.Text.RegularExpressions;

namespace PayeerTransfer.Services
{
    public class ChromeServiceClient
    {
        private static readonly string _logPrefix = "[ChromeServiceClient]";

        public static async Task StartSending(int taskIndex, Account account, string receiver, string code, int timeout, CancellationToken token)
        {
            MyChromeDriver myDriver = null!;
            try
            {
                account.Progress = "Đang tạo chrome";
                myDriver = await CreateDriver(taskIndex, token);
                if (myDriver?.Driver == null)
                {
                    account.Progress = "Tạo chrome thất bại";
                    account.Status = Status.Error;
                    return;
                }

                account.Progress = "Đang login";
                var success = await Login(myDriver, account, timeout, token);
                if (success == null)
                {
                    account.Progress = "Thử login lần 2";
                    success = await Login(myDriver, account, timeout, token);
                }

                if (success == false)
                {
                    account.Progress = "Sai thông tin đăng nhập";
                    account.Status = Status.LoginWrongInfo;
                    return;
                }
                else if (success == null)
                {
                    account.Progress = "Login thất bại do lỗi";
                    account.Status = Status.LoginException;
                    return;
                }
                else
                {
                    account.Progress = "Login thành công";
                    account.Status = Status.LoginSuccess;
                }

                account.Progress = "Đang chuyển";
                var sendSuccess = await Send(myDriver, receiver, code, timeout, token);
                if (sendSuccess == false)
                {
                    account.Progress = "Chuyển tiền thất bại";
                    account.Status = Status.TransferError;
                    return;
                }
                else if (sendSuccess == null)
                {
                    account.Progress = "Không đủ số dư tối thiểu";
                    account.Status = Status.TransferNotEnough;
                    return;
                }
                else
                {
                    account.Progress = "Chuyển tiền thành công";
                    account.Status = Status.TransferSuccess;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Start sending error: {ex}");
                account.Status = Status.Error;
            }
            finally
            {
                myDriver?.Close();
            }
        }

        private static async Task<bool?> Login(MyChromeDriver myDriver, Account account, int timeout, CancellationToken token)
        {
            try
            {
                myDriver.Driver.GoToUrl("https://payeer.com/en/auth/");

                var emailElm = myDriver.Driver.FindElement(@"[name=""email""]", timeout, token);
                myDriver.Driver.Sendkeys(emailElm, account.Username, true, timeout, token);
                await Task.Delay(1000, token);

                var passElm = myDriver.Driver.FindElement(@"[name=""password""]", timeout, token);
                myDriver.Driver.Sendkeys(passElm, account.Password, true, timeout, token);
                await Task.Delay(1000, token);

                myDriver.Driver.Click(".login-form__login-btn.step1", timeout, token);
                var endTime = DateTime.Now.AddSeconds(timeout);
                while (endTime > DateTime.Now)
                {
                    token.ThrowIfCancellationRequested();
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

        private static async Task<bool?> Send(MyChromeDriver myDriver, string receiver, string code, int timeout, CancellationToken token)
        {
            try
            {
                var first = myDriver.Driver.FindElement("div.balance__cache.curr-RUB span.int", timeout, token);
                var firstText = myDriver.Driver.GetInnerText(first);

                var second = myDriver.Driver.FindElement("div.balance__cache.curr-RUB span.pr", timeout, token);
                var secondText = myDriver.Driver.GetInnerText(second);

                var balanceText = firstText + secondText;
                var balance = double.Parse(balanceText);
                if (balance < 1.01) return null;

                myDriver.Driver.GoToUrl("https://payeer.com/en/account/send/?currPS=RUB");
                var accountInput = myDriver.Driver.FindElement(@"input[name=""param_ACCOUNT_NUMBER""]", timeout, token);
                myDriver.Driver.Sendkeys(accountInput, receiver, true, timeout, token);
                await Task.Delay(1000, token);
                myDriver.Driver.ExecuteScript("document.body.style.zoom='50%'");

                if (!string.IsNullOrWhiteSpace(code))
                {
                    myDriver.Driver.ExecuteScript("showInputPS();");
                    var codeInput = myDriver.Driver.FindElement(@"input[name=""protect_code""]", timeout, token);
                    myDriver.Driver.Sendkeys(codeInput, code, true, timeout, token);
                    await Task.Delay(1000, token);
                }
                while (balanceText.StartsWith("0"))
                {
                    balanceText = balanceText.Remove(0, 1);
                }

                var amountInput = myDriver.Driver.FindElement(@"input[name=""sum_pay""]", timeout, token);
                amountInput.SendKeys(OpenQA.Selenium.Keys.Backspace);
                myDriver.Driver.Sendkeys(amountInput, balanceText, false, timeout, token);
                await Task.Delay(3000, token);

                myDriver.Driver.ExecuteScript("formSend08_18();");
                var endTime = DateTime.Now.AddSeconds(timeout);
                while (endTime > DateTime.Now)
                {
                    try
                    {
                        var noteElm = myDriver.Driver.FindElement(".note_txt", 3, token);
                        var note = myDriver.Driver.GetInnerText(noteElm);
                        var success = Regex.Match(note, "\\s[#]\\d{1,}\\s").Success;
                        return success;
                    }
                    catch
                    {
                        await Task.Delay(1000, token);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Send error: {ex}");
                return false;
            }
        }

        private static readonly object _startLocker = new();

        private static async Task<MyChromeDriver> CreateDriver(int browserIndex, CancellationToken token)
        {
            var x = browserIndex % 4;
            var y = browserIndex / 4;
            MyChromeDriver myDriver = null!;
            try
            {
                int createInstanceTimes = 0;
                while (myDriver?.Driver == null)
                {
                    if (token.IsCancellationRequested) break;
                    try
                    {
                        myDriver = await Task.Run(() => ChromeDriverInstance.GetInstance(500 * x, 300 * y,
                            width: 300, height: 300,
                            privateMode: false, isHeadless: false, disableImg: false, token: token,
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
