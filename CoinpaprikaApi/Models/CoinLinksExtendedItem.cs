using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinLinksExtendedItem
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("stats", NullValueHandling = NullValueHandling.Ignore)]
        public CoinLinksExtendedItemStats Stats { get; set; }
    }
}
