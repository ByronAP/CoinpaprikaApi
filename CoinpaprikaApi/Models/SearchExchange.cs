using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class SearchExchange
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }
    }
}
