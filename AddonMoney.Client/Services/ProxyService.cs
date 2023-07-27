using AddonMoney.Client.Models;
using System.Net;

namespace AddonMoney.Client.Services
{
    public class ProxyService
    {
        public static async Task Check(List<ProfileInfo> profiles, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                foreach (var profile in profiles)
                {
                    var success = false;
                    try
                    {
                        var prefix = string.Empty;
                        var proxyRaw = FrmMain.ProxyPrefix + profile.Proxy;
                        if (proxyRaw.Contains("http://") || proxyRaw.Contains("https://"))
                        {
                            proxyRaw = proxyRaw.Replace("http://", "");
                            prefix = "http://";
                        }
                        else if (proxyRaw.Contains("socks5://"))
                        {
                            proxyRaw = proxyRaw.Replace("socks5://", "");
                            prefix = "socks5://";
                        }
                        else throw new Exception("unsupported proxy type");

                        var details = proxyRaw.Split(':');
                        var proxy = new WebProxy($"{prefix}{details[0]}:{details[1]}");
                        if (details.Length == 4) proxy.Credentials = new NetworkCredential(details[2], details[3]);
                        var handler = new HttpClientHandler
                        {
                            Proxy = proxy,
                            UseProxy = true
                        };
                        using var client = new HttpClient(handler);
                        var rs = await client.GetStringAsync("http://ip-api.com/json", token);
                        success = rs.Contains(details[0]);
                    }
                    catch (Exception ex)
                    {
                        if (ex is not OperationCanceledException) success = false;
                    }
                    finally
                    {
                        if (!token.IsCancellationRequested)
                        {
                            await ApiService.SendProxyStatus(new Data.API.UpdateProxyStatusRequest
                            {
                                Email = profile.Email,
                                ProxyDie = !success
                            });
                            await Task.Delay(1000, CancellationToken.None);
                        }
                    }
                }
                try
                {
                    await Task.Delay(60 * 1000, token);
                }
                catch { }
            }
        }
    }
}
