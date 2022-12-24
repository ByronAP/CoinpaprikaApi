using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class ContractItem
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
