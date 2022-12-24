using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class NameSymbolPair
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
