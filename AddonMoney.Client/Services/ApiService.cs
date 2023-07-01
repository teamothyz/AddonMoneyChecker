using AddonMoney.Data.API;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace AddonMoney.Client.Services
{
    public class ApiService
    {
        public static string BaseUrl { get; set; } = null!;

        static ApiService()
        {
            BaseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build()["BaseUrl"] ?? string.Empty;
        }

        public static async Task SendError(UpdateErrorRequest model)
        {
            try
            {
                using var client = new HttpClient()
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PostAsync($"{BaseUrl}/api/addonmoney/error", body);
                if (res.StatusCode != System.Net.HttpStatusCode.OK) 
                {
                    Log.Error($"Send error to server got exception. Data: {JsonConvert.SerializeObject(model)}. Status code: {res.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Send error to server got exception.", ex);
            }
        }

        public static async Task SendBalance(UpdateBalanceRequest model)
        {
            try
            {
                using var client = new HttpClient()
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await client.PostAsync($"{BaseUrl}/api/addonmoney/balance", body);
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Log.Error($"Send balance to server got exception. Data: {JsonConvert.SerializeObject(model)}. Status code: {res.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Send balance to server got exception.", ex);
            }
        }
    }
}
