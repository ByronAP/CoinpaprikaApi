using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class TagItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coin_counter", NullValueHandling = NullValueHandling.Ignore)]
        public int CoinCounter { get; set; }

        [JsonProperty("ico_counter", NullValueHandling = NullValueHandling.Ignore)]
        public int IcoCounter { get; set; }

        [JsonProperty("coins", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Coins { get; set; }

        [JsonProperty("icos", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Icos { get; set; }
    }
}
