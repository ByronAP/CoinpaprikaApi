using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class MarketQuote
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24H { get; set; }
    }
}
