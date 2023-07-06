using CaptchaResolver.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CaptchaResolver.Clients
{
    public class NormalCaptchaClient
    {
        private static string APIKey = string.Empty;

        public static void InitKey(string apiKey)
        {
            APIKey = apiKey;
        }

        public static async Task<string> GetToken(byte[] raw, CancellationToken token)
        {
            var client = new HttpClient();
            var createResponse = await Request(client, raw, token);
            if (createResponse == null || createResponse.Status != 1)
                throw new Exception("[NormalCaptchaClient] Create captcha request failed.");

            var stoppedTime = DateTime.Now.AddMinutes(2);
            var tokenResponse = await Response(client, createResponse.Request, token);
            while (DateTime.Now < stoppedTime)
            {
                if (tokenResponse == null || tokenResponse.Status != 1) await Task.Delay(3000, token);
                tokenResponse = await Response(client, createResponse.Request, token);

                if (tokenResponse != null && tokenResponse.Status == 1) return tokenResponse.Request;
                if (tokenResponse?.Status == 0) continue;
                throw new Exception("[NormalCaptchaClient] Captcha response error.");
            }
            throw new Exception("[NormalCaptchaClient] Captcha response time out.");
        }

        private static async Task<CaptchaResponseModel?> Request(HttpClient client, byte[] raw, CancellationToken token)
        {
            var base64File = Convert.ToBase64String(raw);
            var body = JsonConvert.SerializeObject(new
            {
                json = 1,
                method = "base64",
                body = base64File,
                key = APIKey
            });
            var response = await client.PostAsync("http://2captcha.com/in.php", 
                new StringContent(body, Encoding.UTF8, "application/json"), token);
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
