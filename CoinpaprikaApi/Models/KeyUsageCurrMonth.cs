using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class KeyUsageCurrMonth
    {
        [JsonProperty("requests_made")]
        public int? RequestsMade { get; set; }

        [JsonProperty("requests_left")]
        public int? RequestsLeft { get; set; }
    }
}
