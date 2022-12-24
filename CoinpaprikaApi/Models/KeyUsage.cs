using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class KeyUsage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("current_month")]
        public KeyUsageCurrMonth CurrentMonth { get; set; }
    }
}
