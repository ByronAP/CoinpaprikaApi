using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class PersonPosition
    {
        [JsonProperty("coin_id")]
        public string CoinId { get; set; }

        [JsonProperty("coin_name")]
        public string CoinName { get; set; }

        [JsonProperty("coin_symbol")]
        public string CoinSymbol { get; set; }

        [JsonProperty("position")]
        public string PositionPosition { get; set; }
    }
}
