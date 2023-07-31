﻿using AddonMoney.Register.Models;
using AddonMoney.Register.Windows;
using ChromeDriverLibrary;
using SeleniumUndetectedChromeDriver;
using Serilog;

namespace AddonMoney.Register.Services
{
    public class RegisterService
    {
        private static readonly string _logPrefix = "[RegisterService]";
        public static int Timeout { get; set; } = 30;
        public static DateTime StartTime { get; set; }

        public static async Task<bool?> StartRegister(CancellationToken token)
        {
            Account account = null!;
            MyChromeDriver myDriver = null!;
            try
            {
                lock (Account.Accounts)
                {
                    if (Account.Accounts.Count == 0) return null;
                    account = Account.Accounts.Dequeue();
                    if (account == null) return null;
                }
                try
                {
                    myDriver = await Task.Run(() => ChromeDriverInstance.GetInstance(0, 0, isMaximize: true,
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
                    return null;
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
                        return null;
                    }
                    DataService.WriteError(account, StartTime);
                    return false;
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
                        return null;
                    }
                    account.Error = "Get cookie failed";
                    DataService.WriteError(account, StartTime);
                    return false;
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
                return true;
            }
            catch (Exception ex)
            {
                if (token.IsCancellationRequested && account != null)
                {
                    lock (Account.Accounts)
                    {
                        Account.Accounts.Enqueue(account);
                    }
                    return null;
                }
                Log.Error($"{_logPrefix} Got exception while creating account. Error: {ex}");
                if (account != null)
                {
                    account.Error = ex.Message;
                    DataService.WriteError(account, StartTime);
                    return false;
                }
                return null;
            }
            finally
            {
                await ChromeDriverInstance.Close(myDriver);
            }
        }

        private static async Task<bool> LinkGoogle(UndetectedChromeDriver driver, Account account, CancellationToken token)
        {
            try
            {
                var emailElm = driver.FindElement("#identifierId", Timeout, token);
                driver.SendkeysRandom(emailElm, account.Email, true, true, Timeout, token);
                await Task.Delay(1000, token).ConfigureAwait(false);

                var passwordElm = driver.FindElement(@"[autocomplete=""current-password""]", Timeout, token);
                driver.SendkeysRandom(passwordElm, account.Password, true, true, Timeout, token);
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
                driver.SendkeysRandom(recoveryMailElm, account.RecoveryMail, true, true, Timeout, token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GetReferalLink()
        {
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