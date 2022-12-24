using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class SearchResponse
    {
        [JsonProperty("currencies")]
        public SearchCurrency[] Currencies { get; set; }

        [JsonProperty("exchanges")]
        public SearchExchange[] Exchanges { get; set; }

        [JsonProperty("icos")]
        public SearchIco[] Icos { get; set; }

        [JsonProperty("people")]
        public SearchPerson[] People { get; set; }

        [JsonProperty("tags")]
        public SearchTag[] Tags { get; set; }
    }
}
