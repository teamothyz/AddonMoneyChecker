using AddonMoney.Transfer.Models;
using Serilog;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TL;
using WTelegram;
using xNetStandard;

namespace AddonMoney.Transfer.Services
{
    public class TeleService
    {
        private static readonly string _logPrefix = "[TeleService]";

        public static async Task<Tuple<bool, string>> GetOTP(Account account, DateTime offset, CancellationToken token)
        {
            try
            {
                var sessionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "sessions",
                    account.TeleSession.Replace(".session", ""),
                    account.TeleSession);

                if (!File.Exists(sessionPath))
                {
                    Log.Error($"Not found session file {sessionPath}.");
                    return new Tuple<bool, string>(false, $"Not found session file {sessionPath}.");
                }

                using var client = new Client(account.ApiId, account.ApiHash, sessionPath);
                var myProxy = account.Proxy;
                if (myProxy != null)
                {
                    if (MyProxy.Type == Models.ProxyType.Socks5)
                    {
                        client.TcpHandler = async (address, port) =>
                        {
                            if (myProxy.Username != null && myProxy.Password != null)
                            {
                                var proxy = new Socks5ProxyClient(myProxy.Host, myProxy.Port, myProxy.Username, myProxy.Password);
                                return await Task.Run(() => proxy.CreateConnection(address, port));
                            }
                            else
                            {
                                var proxy = new Socks5ProxyClient(myProxy.Host, myProxy.Port);
                                return await Task.Run(() => proxy.CreateConnection(address, port));
                            }
                        };
                    }
                    else if (MyProxy.Type == Models.ProxyType.Http)
                    {
                        client.TcpHandler = async (address, port) =>
                        {
                            if (myProxy.Username != null && myProxy.Password != null)
                            {
                                var proxy = new HttpProxyClient(myProxy.Host, myProxy.Port, myProxy.Username, myProxy.Password);
                                return await Task.Run(() => proxy.CreateConnection(address, port));
                            }
                            else
                            {
                                var proxy = new HttpProxyClient(myProxy.Host, myProxy.Port);
                                return await Task.Run(() => proxy.CreateConnection(address, port));
                            }
                        };
                    }
                }

                var config = await client.Login(account.Phone).ConfigureAwait(false);
                if (config != null || client.User == null)
                {
                    Log.Warning($"{_logPrefix} Can not authenticate tele account {account.Phone}.");
                    return new Tuple<bool, string>(false, $"Can not authenticate tele account {account.Phone}.");
                }

                var notiBot = await client.Contacts_ResolveUsername(AppConfig.BotUsername).ConfigureAwait(false);
                var endTime = DateTime.Now.AddSeconds(TransferService.Timeout);
                while (DateTime.Now < endTime)
                {
                    var messageContainer = await client.Messages_GetHistory(notiBot, limit: 1).ConfigureAwait(false);
                    if (messageContainer?.Count > 0)
                    {
                        var messageBase = messageContainer.Messages.MaxBy(m => m.Date);
                        if (messageBase is not TL.Message message
                            || message.Date.ToUniversalTime() < offset.ToUniversalTime()
                            || string.IsNullOrEmpty(message.message)
                            || !message.message.ToLower().Contains("code"))
                        {
                            await Task.Delay(5000, token).ConfigureAwait(false);
                            continue;
                        }
                        var matched = Regex.Match(message.message, "(\\d{6})");
                        if (!matched.Success)
                        {
                            await Task.Delay(5000, token).ConfigureAwait(false);
                            continue;
                        }
                        return new Tuple<bool, string>(true, matched.Value);
                    }
                    else
                    {
                        await Task.Delay(5000, token).ConfigureAwait(false);
                        continue;
                    }
                }
                Log.Error($"{_logPrefix} Get otp time out after {TransferService.Timeout}s. Account {account.Phone}.");
                return new Tuple<bool, string>(false, "Not found OTP. OTP time out.");
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while waiting otp for {account.Phone}. Error: {ex}");
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        //session-appId-appHash-timeStampUTC-timeout-proxy?
        public static async Task<Tuple<bool, string>> GetOTPByPy(Account account, DateTime offsetDate, CancellationToken token)
        {
            string input = string.Empty;
            try
            {
                var sessionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "sessions",
                    account.TeleSession.Replace(".session", ""),
                    account.TeleSession);

                if (!File.Exists(sessionPath))
                {
                    Log.Error($"Not found session file {sessionPath}.");
                    return new Tuple<bool, string>(false, $"Not found session file {sessionPath}.");
                }
                string? proxy = account.Proxy?.ToString();
                var offset = ((DateTimeOffset)offsetDate.ToUniversalTime()).ToUnixTimeSeconds();
                var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "helpers", "ReadOTPCode.exe");
                if (proxy == null)
                {
                    input = $"{sessionPath} {account.ApiId} {account.ApiHash} {offset} {TransferService.Timeout}";
                }
                else
                {
                    input = $"{sessionPath} {account.ApiId} {account.ApiHash} {offset} {TransferService.Timeout} {proxy}";
                }
                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = exePath,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        Arguments = input
                    }
                };
                process.Start();
                var success = process.WaitForExit((TransferService.Timeout + 3) * 1000);
                if (!success)
                {
                    Log.Error($"{_logPrefix} [{input}] Timeout while waiting otp for {account.Phone}.");
                    return new Tuple<bool, string>(false, $"Not found code.");
                }

                var output = await process.StandardOutput.ReadToEndAsync();
                var error = await process.StandardError.ReadToEndAsync();
                Log.Information($"{_logPrefix} [{input}] {output} {error}");
                var matched = Regex.Match(output, "(\\d{6})");
                if (matched.Success && output.ToLower().Contains("code"))
                {
                    return new Tuple<bool, string>(true, matched.Value);
                }
                Log.Error($"{_logPrefix} [{input}] Not found otp for {account.Phone}. Message: {output}");
                return new Tuple<bool, string>(false, output + " " + error);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} [{input}] Waiting otp for {account.Phone} error: {ex}");
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        //session-appId-appHash-token-proxy?
        public static async Task<Tuple<bool, string>> LinkAccount(Account account, string token)
        {
            var input = string.Empty;
            try
            {
                var sessionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "sessions",
                    account.TeleSession.Replace(".session", ""),
                    account.TeleSession);

                if (!File.Exists(sessionPath))
                {
                    Log.Error($"Not found session file {sessionPath}.");
                    return new Tuple<bool, string>(false, $"Not found session file {sessionPath}.");
                }
                string? proxy = account.Proxy?.ToString();
                var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "helpers", "LinkAccount.exe");
                if (proxy == null)
                {
                    input = $"{sessionPath} {account.ApiId} {account.ApiHash} {token}";
                }
                else
                {
                    input = $"{sessionPath} {account.ApiId} {account.ApiHash} {token} {proxy}";
                }
                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = exePath,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        Arguments = input,
                    }
                };
                process.Start();
                var success = process.WaitForExit(60 * 1000);
                if (!success)
                {
                    Log.Error($"{_logPrefix} [{input}] Timeout while linking account for {account.Phone}.");
                    return new Tuple<bool, string>(false, $"Timeout while linking account for {account.Phone}.");
                }

                var output = await process.StandardOutput.ReadToEndAsync();
                var error = await process.StandardError.ReadToEndAsync();
                Log.Information($"{_logPrefix} [{input}] {output} {error}");
                if (output.ToLower().Contains("error") || !string.IsNullOrEmpty(error))
                {
                    return new Tuple<bool, string>(false, output + " " + error);
                }
                return new Tuple<bool, string>(true, string.Empty);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} [{input}] Link account {account.Phone} error: {ex}");
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}
