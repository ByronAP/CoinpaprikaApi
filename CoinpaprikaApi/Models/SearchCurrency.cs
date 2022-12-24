using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class SearchCurrency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }
    }
}
