using CaptchaResolver.Models;
using Newtonsoft.Json;

namespace CaptchaResolver.Clients
{
    public class CaptchaV3Client
    {
        private static string APIKey = string.Empty;
        private static readonly string SiteUrl = "https://viettel.vn/thong-tin-don-hang-sim";
        private static readonly string SiteKey = "6Le_M9oiAAAAANmNTJ10U53S5bu7R8_2u4fKpPtq";
        private static readonly string Action = "buy_sim_submit";
        private static readonly string Method = "userrecaptcha";

        public static void InitKey(string apiKey)
        {
            APIKey = apiKey;
        }

        public static async Task<string> GetToken(CancellationToken token)
        {
            var client = new HttpClient();
            var createResponse = await Request(client, token);
            if (createResponse == null || createResponse.Status != 1)
                throw new Exception("[CaptchaV3Client] Create captcha request failed.");

            var stoppedTime = DateTime.Now.AddMinutes(2);
            var tokenResponse = await Response(client, createResponse.Request, token);
            while (DateTime.Now < stoppedTime)
            {
                if (tokenResponse == null || tokenResponse.Status != 1) await Task.Delay(3000, token);
                tokenResponse = await Response(client, createResponse.Request, token);

                if (tokenResponse != null && tokenResponse.Status == 1) return tokenResponse.Request;
                if (tokenResponse?.Status == 0) continue;
                throw new Exception("[CaptchaV3Client] Captcha response error.");
            }
            throw new Exception("[CaptchaV3Client] Captcha response time out.");
        }

        private static async Task<CaptchaResponseModel?> Request(HttpClient client, CancellationToken token)
        {
            var paras = new Dictionary<string, string>
            {
                {"key", APIKey},
                {"method", Method},
                {"version", "v3"},
                {"enterprise", "1"},
                {"googlekey", SiteKey},
                {"pageurl", SiteUrl},
                {"action", Action},
                {"json", "1"}
            };
            var body = new FormUrlEncodedContent(paras);
            var url = $"http://2captcha.com/in.php";
            var response = await client.PostAsync(url, body, token);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<CaptchaResponseModel>(content);
        }

        private static async Task<CaptchaResponseModel?> Response(HttpClient client, string id, CancellationToken token)
        {
            var url = $"http://2captcha.com/res.php?key={APIKey}&action=get&id={id}&json=1";
            var response = await client.GetAsync(url, token);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<CaptchaResponseModel>(content);
        }
    }
}
