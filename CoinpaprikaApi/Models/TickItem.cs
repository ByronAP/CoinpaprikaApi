using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class TickItem
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public long Volume24H { get; set; }

        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }
    }
}
