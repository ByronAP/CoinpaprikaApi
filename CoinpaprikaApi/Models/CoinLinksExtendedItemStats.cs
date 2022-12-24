using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinLinksExtendedItemStats
    {
        [JsonProperty("subscribers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Subscribers { get; set; }

        [JsonProperty("contributors", NullValueHandling = NullValueHandling.Ignore)]
        public long? Contributors { get; set; }

        [JsonProperty("stars", NullValueHandling = NullValueHandling.Ignore)]
        public long? Stars { get; set; }

        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Followers { get; set; }
    }
}
