using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinExchangeItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("adjusted_volume_24h_share")]
        public double AdjustedVolume24HShare { get; set; }

        [JsonProperty("fiats")]
        public NameSymbolPair[] Fiats { get; set; }
    }
}
