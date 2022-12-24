using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class PriceConverterResponse
    {
        [JsonProperty("base_currency_id")]
        public string BaseCurrencyId { get; set; }

        [JsonProperty("base_currency_name")]
        public string BaseCurrencyName { get; set; }

        [JsonProperty("base_price_last_updated")]
        public DateTimeOffset BasePriceLastUpdated { get; set; }

        [JsonProperty("quote_currency_id")]
        public string QuoteCurrencyId { get; set; }

        [JsonProperty("quote_currency_name")]
        public string QuoteCurrencyName { get; set; }

        [JsonProperty("quote_price_last_updated")]
        public DateTimeOffset QuotePriceLastUpdated { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
