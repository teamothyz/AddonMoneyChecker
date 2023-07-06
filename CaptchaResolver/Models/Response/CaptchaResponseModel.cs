using Newtonsoft.Json;

namespace CaptchaResolver.Models
{
    public class CaptchaResponseModel
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("request")]
        public string Request { get; set; }
    }
}
