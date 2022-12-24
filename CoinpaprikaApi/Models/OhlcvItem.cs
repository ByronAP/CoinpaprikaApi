using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class OhlcvItem
    {
        [JsonProperty("time_open")]
        public DateTimeOffset? TimeOpen { get; set; }

        [JsonProperty("time_close")]
        public DateTimeOffset? TimeClose { get; set; }

        [JsonProperty("open")]
        public decimal? Open { get; set; }

        [JsonProperty("high")]
        public decimal? High { get; set; }

        [JsonProperty("low")]
        public decimal? Low { get; set; }

        [JsonProperty("close")]
        public decimal? Close { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }
    }
}
