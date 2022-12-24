using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CoinpaprikaApi.Models
{
    public class ExchangeItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("website_status")]
        public bool WebsiteStatus { get; set; }

        [JsonProperty("api_status")]
        public bool ApiStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("links")]
        public Dictionary<string, string[]> Links { get; set; }

        [JsonProperty("markets_data_fetched")]
        public bool MarketsDataFetched { get; set; }

        [JsonProperty("adjusted_rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? AdjustedRank { get; set; }

        [JsonProperty("reported_rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? ReportedRank { get; set; }

        [JsonProperty("currencies")]
        public int Currencies { get; set; }

        [JsonProperty("markets")]
        public int Markets { get; set; }

        [JsonProperty("fiats")]
        public ExchangeFiat[] Fiats { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, QuoteData> Quotes { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("confidence_score")]
        public double ConfidenceScore { get; set; }

        [JsonProperty("sessions_per_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? SessionsPerMonth { get; set; }
    }
}
