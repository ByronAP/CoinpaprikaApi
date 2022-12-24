using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class SearchIco
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }
    }
}
