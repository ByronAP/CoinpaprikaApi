using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class ExchangeFiat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
