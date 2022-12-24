using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class GlobalResponse
    {
        [JsonProperty("market_cap_usd")]
        public long MarketCapUsd { get; set; }

        [JsonProperty("volume_24h_usd")]
        public long Volume24HUsd { get; set; }

        [JsonProperty("bitcoin_dominance_percentage")]
        public decimal BitcoinDominancePercentage { get; set; }

        [JsonProperty("cryptocurrencies_number")]
        public int CryptocurrenciesNumber { get; set; }

        [JsonProperty("market_cap_ath_value")]
        public long MarketCapAthValue { get; set; }

        [JsonProperty("market_cap_ath_date")]
        public DateTimeOffset? MarketCapAthDate { get; set; }

        [JsonProperty("volume_24h_ath_value")]
        public long Volume24HAthValue { get; set; }

        [JsonProperty("volume_24h_ath_date")]
        public DateTimeOffset? Volume24HAthDate { get; set; }

        [JsonProperty("volume_24h_percent_from_ath")]
        public decimal Volume24HPercentFromAth { get; set; }

        [JsonProperty("volume_24h_percent_to_ath")]
        public decimal Volume24HPercentToAth { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public decimal MarketCapChange24H { get; set; }

        [JsonProperty("volume_24h_change_24h")]
        public decimal Volume24HChange24H { get; set; }

        [JsonProperty("last_updated")]
        public long LastUpdated { get; set; }
    }
}
