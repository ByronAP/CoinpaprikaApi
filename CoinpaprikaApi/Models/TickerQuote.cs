using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class TickerQuote
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24H { get; set; }

        [JsonProperty("volume_24h_change_24h")]
        public double Volume24HChange24H { get; set; }

        [JsonProperty("market_cap")]
        public long MarketCap { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public double MarketCapChange24H { get; set; }

        [JsonProperty("percent_change_15m")]
        public double PercentChange15M { get; set; }

        [JsonProperty("percent_change_30m")]
        public double PercentChange30M { get; set; }

        [JsonProperty("percent_change_1h")]
        public double PercentChange1H { get; set; }

        [JsonProperty("percent_change_6h")]
        public double PercentChange6H { get; set; }

        [JsonProperty("percent_change_12h")]
        public double PercentChange12H { get; set; }

        [JsonProperty("percent_change_24h")]
        public double PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")]
        public double PercentChange7D { get; set; }

        [JsonProperty("percent_change_30d")]
        public double PercentChange30D { get; set; }

        [JsonProperty("percent_change_1y")]
        public double PercentChange1Y { get; set; }

        [JsonProperty("ath_price")]
        public decimal? AthPrice { get; set; }

        [JsonProperty("ath_date")]
        public DateTimeOffset AthDate { get; set; }

        [JsonProperty("percent_from_price_ath")]
        public double PercentFromPriceAth { get; set; }
    }
}
