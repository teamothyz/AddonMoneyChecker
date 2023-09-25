using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaptchaResolver.Clients
{
    public class AnyCaptchaV2Client
    {
        private static string _apiKey = string.Empty;
        private static string _siteUrl = "https://addon.money";
        private static string _siteKey = "6LeuIL4UAAAAAHgT1ir2kCjOaU6F1UAcTmWiFr5M";

        public static void InitKey(string apiKey, string siteUrl, string siteKey)
        {
            _apiKey = apiKey;
            _siteKey = siteKey;
            _siteUrl = siteUrl;
        }

        public static async Task<string> GetToken(CancellationToken token)
        {
            var client = new HttpClient();
            var taskId = await Request(client, token);
            if (string.IsNullOrEmpty(taskId)) throw new Exception("[AnyCaptchaV2Client] Create captcha request failed.");

            var stoppedTime = DateTime.Now.AddMinutes(2);
            var tokenResponse = await Response(client, taskId, token);
            while (DateTime.Now < stoppedTime)
            {
                if (string.IsNullOrEmpty(tokenResponse))
                {
                    await Task.Delay(3000, token);
                    tokenResponse = await Response(client, taskId, token);
                }

                if (!string.IsNullOrEmpty(tokenResponse)) return tokenResponse;
            }
            throw new Exception("[AnyCaptchaV2Client] Captcha response time out.");
        }

        private static async Task<string?> Request(HttpClient client, CancellationToken token)
        {
            var url = $"https://api.1stcaptcha.com/recaptchav2?apikey={_apiKey}&sitekey={_siteKey}&siteurl={_siteUrl}&invisible=false";
            var response = await client.GetAsync(url, token);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<JObject>(content)?["TaskId"]?.ToString();
        }

        private static async Task<string?> Response(HttpClient client, string id, CancellationToken token)
        {
            var url = $"https://api.1stcaptcha.com/getresult?apikey={_apiKey}&taskid={id}";
            var response = await client.GetAsync(url, token);
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonConvert.DeserializeObject<JObject>(content)?.SelectToken("Data.Token")?.ToString();
        }
    }
}
