using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinTagItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coin_counter")]
        public int? CoinCounter { get; set; }

        [JsonProperty("ico_counter")]
        public int? IcoCounter { get; set; }
    }
}
