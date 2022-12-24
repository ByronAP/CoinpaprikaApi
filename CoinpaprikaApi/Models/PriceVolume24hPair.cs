using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class PriceVolume24hPair
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24H { get; set; }
    }
}
