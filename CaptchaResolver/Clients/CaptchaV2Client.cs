using CaptchaResolver.Models;
using Newtonsoft.Json;

namespace CaptchaResolver.Clients
{
    public class CaptchaV2Client
    {
        private static string _apiKey = string.Empty;
        private static string _siteUrl = "https://addon.money";
        private static string _siteKey = "6LeuIL4UAAAAAHgT1ir2kCjOaU6F1UAcTmWiFr5M";

        private static readonly string _method = "userrecaptcha";

        public static void InitKey(string apiKey, string siteUrl, string siteKey)
        {
            _apiKey = apiKey;
            _siteKey = siteKey;
            _siteUrl = siteUrl;
        }

        public static async Task<string> GetToken(CancellationToken token)
        {
            var client = new HttpClient();
            var createResponse = await Request(client, token);
            if (createResponse == null || createResponse.Status != 1)
                throw new Exception("[CaptchaV2Client] Create captcha request failed.");

            var stoppedTime = DateTime.Now.AddMinutes(2);
            var tokenResponse = await Response(client, createResponse.Request, token);
            while (DateTime.Now < stoppedTime)
            {
                if (tokenResponse == null || tokenResponse.Status != 1) await Task.Delay(3000, token);
                tokenResponse = await Response(client, createResponse.Request, token);

                if (tokenResponse != null && tokenResponse.Status == 1) return tokenResponse.Request;
                if (tokenResponse?.Status == 0) continue;
                throw new Exception("[CaptchaV2Client] Captcha response error.");
            }
            throw new Exception("[CaptchaV2Client] Captcha response time out.");
        }

        private static async Task<CaptchaResponseModel?> Request(HttpClient client, CancellationToken token)
        {
            var url = $"http://2captcha.com/in.php?key={_apiKey}&method={_method}&googlekey={_siteKey}&pageurl={_siteUrl}&json=1&invisible=0";
            var response = await client.GetAsync(url, token);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<CaptchaResponseModel>(content);
        }

        private static async Task<CaptchaResponseModel?> Response(HttpClient client, string id, CancellationToken token)
        {
            var url = $"http://2captcha.com/res.php?key={_apiKey}&action=get&id={id}&json=1";
            var response = await client.GetAsync(url, token);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<CaptchaResponseModel>(content);
        }
    }
}