using AddonMoney.Transfer.Models;
using Serilog;
using System.Text.RegularExpressions;
using TL;
using WTelegram;
using xNetStandard;

namespace AddonMoney.Transfer.Services
{
    public class TeleService
    {
        private static readonly string _logPrefix = "[TeleService]";

        public static async Task<string?> GetOTP(Account account, DateTime offset, MyProxy? myProxy, CancellationToken token)
        {
            try
            {
                var sessionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sessions", account.TeleSession);
                if (!File.Exists(sessionPath)) 
                {
                    Log.Error($"Not found session file {sessionPath}.");
                    return null;
                }

                using var client = new Client(account.ApiId, account.ApiHash, sessionPath);
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
                    return null;
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
                        return matched.Value;
                    }
                    else
                    {
                        await Task.Delay(5000, token).ConfigureAwait(false);
                        continue;
                    }
                }
                Log.Error($"{_logPrefix} Get otp time out after {TransferService.Timeout}s. Account {account.Phone}.");
                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while waiting otp for {account.Phone}. Error: {ex}");
                return null;
            }
        }
    }
}
