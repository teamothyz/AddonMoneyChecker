using System.Net;

namespace PayeerTransfer.Services
{
    public class PayeerService
    {
        private static readonly object _locker = new();

        public static async Task Login(string username, string password, CancellationToken token)
        {
            var container = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = container,
                UseCookies = false
            };
            using var client = new HttpClient(handler)
            {
                DefaultRequestVersion = HttpVersion.Version11
            };
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.188");
            var authHtmlRes = await client.GetAsync("https://payeer.com/en/auth/", token);
            var authHtml = await authHtmlRes.Content.ReadAsStringAsync(token);
            HtmlAgilityPack.HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(authHtml);
            var sessid = htmlDocument.GetElementbyId("sessid").GetAttributeValue("value", null!);
            var sign = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='sign']")?
                .GetAttributeValue("value", string.Empty) ?? null!;


            var captchaToken = string.Empty;
            var resolveCaptchaTimes = 1;
            while (string.IsNullOrEmpty(captchaToken))
            {
                lock (_locker)
                {
                    captchaToken = RecaptchaV3Service.GetToken(30, CancellationToken.None).Result;
                }
                if (string.IsNullOrEmpty(captchaToken))
                {
                    resolveCaptchaTimes++;
                    if (resolveCaptchaTimes == 3) throw new Exception("resolve capthca failed");
                    await Task.Delay(1000, CancellationToken.None);
                }
            }
            var dictParas = new Dictionary<string, string>
            {
                {"action", "authorization"},
                {"block", "0"},
                {"sessid", sessid},
                {"sign", sign},
                {"email", username},
                {"password", password},
                {"g-recaptcha-response", ""},
                {"backurl", "/en/account/"},
                {"security_code", ""},
                {"recaptcha_v3", captchaToken}
            };
            client.DefaultRequestHeaders.Add("Origin", "https://payeer.com");
            client.DefaultRequestHeaders.Add("Referer", "https://payeer.com/en/auth/");
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua", @"""Not/A)Brand"";v=""99"", ""Microsoft Edge"";v=""115"", ""Chromium"";v=""115""");
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", @"""Windows""");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

            client.DefaultRequestHeaders.Add("Cookie", "PHPSESSID=pfnl3kgc4nt8j4vqtm2lemp19ih0k2hs2op150lktsf9pnid56mbobhq7tku4qbid0rbenr9440789l72ha0hb40tefieo26sktkcp1");
            var body = new FormUrlEncodedContent(dictParas);
            var res = await client.PostAsync("https://payeer.com/bitrix/components/auth/system.auth.authorize/templates/.default/ajax.php", body, token);
            var content = await res.Content.ReadAsStringAsync(CancellationToken.None);
        }
    }
}
