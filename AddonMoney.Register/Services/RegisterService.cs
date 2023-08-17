using AddonMoney.Register.Models;
using AddonMoney.Register.Windows;
using ChromeDriverLibrary;
using OpenQA.Selenium;
using SeleniumUndetectedChromeDriver;
using Serilog;

namespace AddonMoney.Register.Services
{
    public class RegisterService
    {
        private static readonly string _logPrefix = "[RegisterService]";
        public static int Timeout { get; set; } = 30;
        public static DateTime StartTime { get; set; }
        public static int RegistedAccount { get; set; } = 0;
        private static readonly object _lockRef = new();
        private static readonly object _lockIndex = new();

        public static int Index { get; set; } = 0;

        public static async Task StartRegister(Action successCallback, Action failedCallback, CancellationToken token)
        {
            var x = 0;
            var y = 0;
            lock (_lockIndex)
            {
                x = Index % 4;
                y = Index / 4;
                Index++;
            }

            while (!token.IsCancellationRequested)
            {
                Account account = null!;
                MyChromeDriver myDriver = null!;
                lock (Account.Accounts)
                {
                    if (Account.Accounts.Count == 0) return;
                    account = Account.Accounts.Dequeue();
                    if (account == null) return;
                }

                try
                {
                    try
                    {
                        myDriver = await Task.Run(() => ChromeDriverInstance.GetInstance(500 * x, 300 * y, isMaximize: false,
                            privateMode: false, isHeadless: false, disableImg: true,
                            token: token, isDeleteProfile: true, keepOneWindow: true,
                            proxy: account.Proxy.ToString())).ConfigureAwait(false);
                        if (myDriver.Driver == null) throw new Exception("null driver");

                        var referalLink = GetReferalLink();
                        if (!string.IsNullOrEmpty(referalLink))
                        {
                            myDriver.Driver.GoToUrl(referalLink);
                            var success = false;
                            var endTime = DateTime.Now.AddSeconds(Timeout);
                            while (DateTime.Now < endTime)
                            {
                                try
                                {
                                    success = (bool)myDriver.Driver.ExecuteScript("return document.cookie.includes('partner=');");
                                    if (success) break;
                                }
                                catch { }
                                finally
                                {
                                    await Task.Delay(1000, token).ConfigureAwait(false);
                                }
                            }
                            if (!success) throw new Exception("can not go to referal link");
                        }
                        myDriver.Driver.GoToUrl("https://addon.money/auth/index.php?social=yt");
                    }
                    catch
                    {
                        lock (Account.Accounts)
                        {
                            Account.Accounts.Enqueue(account);
                        }
                        continue;
                    }

                    var googleLinkSuccess = await LinkGoogle(myDriver.Driver, account, token).ConfigureAwait(false);
                    if (!googleLinkSuccess)
                    {
                        if (token.IsCancellationRequested)
                        {
                            lock (Account.Accounts)
                            {
                                Account.Accounts.Enqueue(account);
                            }
                            continue;
                        }
                        DataService.WriteError(account, StartTime);
                        failedCallback();
                        continue;
                    }

                    myDriver.Driver.GoToUrl("https://addon.money/auth/index.php?social=yt");
                    var endGetCookieTime = DateTime.Now.AddSeconds(Timeout);
                    while (DateTime.Now < endGetCookieTime)
                    {
                        try
                        {
                            account.Cookie = (string)myDriver.Driver.ExecuteScript("return document.cookie;");
                            break;
                        }
                        catch
                        {
                            await Task.Delay(1000, token).ConfigureAwait(false);
                        }
                    }
                    if (string.IsNullOrEmpty(account.Cookie))
                    {
                        if (token.IsCancellationRequested)
                        {
                            lock (Account.Accounts)
                            {
                                Account.Accounts.Enqueue(account);
                            }
                            continue;
                        }
                        account.Error = "Get cookie failed";
                        DataService.WriteError(account, StartTime);
                        failedCallback();
                        continue;
                    }

                    DataService.WriteSuccess(account, StartTime);
                    if (string.IsNullOrEmpty(FrmMain.ReferLinkFirst) || string.IsNullOrEmpty(FrmMain.ReferLinkSecond))
                    {
                        try
                        {

                            var refLink = myDriver.Driver.FindElement("#reflink", Timeout, token).GetAttribute("value");
                            if (string.IsNullOrEmpty(FrmMain.ReferLinkFirst)) FrmMain.ReferLinkFirst = refLink;
                            else if (string.IsNullOrEmpty(FrmMain.ReferLinkSecond)) FrmMain.ReferLinkSecond = refLink;
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"{_logPrefix} Got exception while getting refer link. Error: {ex}");
                        }
                    }
                    successCallback();
                    continue;
                }
                catch (Exception ex)
                {
                    if (token.IsCancellationRequested && account != null)
                    {
                        lock (Account.Accounts)
                        {
                            Account.Accounts.Enqueue(account);
                        }
                        continue;
                    }
                    Log.Error($"{_logPrefix} Got exception while creating account. Error: {ex}");
                    if (account != null)
                    {
                        account.Error = ex.Message;
                        DataService.WriteError(account, StartTime);
                        failedCallback();
                        continue;
                    }
                }
                finally
                {
                    await ChromeDriverInstance.Close(myDriver);
                }
            }
        }

        private static async Task<bool> LinkGoogle(UndetectedChromeDriver driver, Account account, CancellationToken token)
        {
            try
            {
                var emailElm = driver.FindElement("#identifierId", Timeout, token);
                driver.Sendkeys(emailElm, account.Email, true, Timeout, token);
                driver.ClickByJS("#identifierNext button", Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var passwordElm = driver.FindElement(@"[autocomplete=""current-password""]", Timeout, token);
                driver.Sendkeys(passwordElm, account.Password, true, Timeout, token);
                driver.ClickByJS("#passwordNext button", Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var endTime = DateTime.Now.AddSeconds(Timeout);
                var success = false;
                while (DateTime.Now < endTime)
                {
                    try
                    {
                        try
                        {
                            _ = driver.FindElement(".account-name", 3, token);
                            success = true;
                        }
                        catch
                        {
                            //first time login will get this notification
                            driver.ClickByJS("#confirm", 3, token);
                            success = true;
                        }
                    }
                    catch
                    {
                        success = await HandleRecoveryMail(driver, account, token)
                            .ConfigureAwait(false);
                    }
                    if (success) break;
                    else await Task.Delay(1000, token).ConfigureAwait(false);
                }
                if (!success)
                {
                    account.Error = "Can not login Gmail";
                    return false;
                }

                endTime = DateTime.Now.AddSeconds(Timeout);
                while (DateTime.Now < endTime)
                {
                    try
                    {
                        try
                        {
                            _ = driver.FindElement(".account-name", 3, token);
                            return true;
                        }
                        catch
                        {
                            //first time login will get this notification
                            driver.ClickByJS("#confirm", 3, token);
                            return true;
                        }
                    }
                    catch
                    {
                        if (driver.Url.Contains("gds.google.com")) return true;
                        else await Task.Delay(1000, token).ConfigureAwait(false);
                    }
                }
                account.Error = "Can not login Gmail";
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception while link account for {account.Email}. Error: {ex}");
                account.Error = ex.Message;
                return false;
            }
        }

        private static async Task<bool> HandleRecoveryMail(UndetectedChromeDriver driver, Account account, CancellationToken token)
        {
            try
            {
                _ = driver.FindElement(@"[data-challengetype=""12""]", 3, token);
                driver.ClickByJS(@"[data-challengetype=""12""]", Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var recoveryMailElm = driver.FindElement(@"[name=""knowledgePreregisteredEmailResponse""]", Timeout, token);
                driver.Sendkeys(recoveryMailElm, account.RecoveryMail, true, Timeout, token);
                recoveryMailElm.SendKeys(OpenQA.Selenium.Keys.Enter);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GetReferalLink()
        {
            lock (_lockRef)
            {
                if (RegistedAccount % 16 == 0)
                {
                    FrmMain.ReferLinkFirst = null!;
                    FrmMain.ReferLinkSecond = null!;
                }

                if (!string.IsNullOrEmpty(FrmMain.ReferLinkRoot))
                {
                    if (FrmMain.OnlyRootLink)
                    {
                        return FrmMain.ReferLinkRoot;
                    }
                    else if (!string.IsNullOrEmpty(FrmMain.ReferLinkFirst))
                    {
                        if (!string.IsNullOrEmpty(FrmMain.ReferLinkSecond))
                        {
                            return FrmMain.ReferLinkSecond;
                        }
                        else
                        {
                            return FrmMain.ReferLinkFirst;
                        }
                    }
                    else
                    {
                        return FrmMain.ReferLinkRoot;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
