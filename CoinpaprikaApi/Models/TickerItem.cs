using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoinpaprikaApi.Models
{
    public class TickerItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("circulating_supply")]
        public double CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public double TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public double MaxSupply { get; set; }

        [JsonProperty("beta_value")]
        public double BetaValue { get; set; }

        [JsonProperty("first_data_at")]
        public DateTimeOffset FirstDataAt { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, TickerQuote> Quotes { get; set; }
    }
}
