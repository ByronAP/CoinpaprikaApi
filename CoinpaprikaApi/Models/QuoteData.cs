using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class QuoteData
    {
        [JsonProperty("reported_volume_24h")]
        public double ReportedVolume24H { get; set; }

        [JsonProperty("adjusted_volume_24h")]
        public double AdjustedVolume24H { get; set; }

        [JsonProperty("reported_volume_7d")]
        public double ReportedVolume7D { get; set; }

        [JsonProperty("adjusted_volume_7d")]
        public double AdjustedVolume7D { get; set; }

        [JsonProperty("reported_volume_30d")]
        public double ReportedVolume30D { get; set; }

        [JsonProperty("adjusted_volume_30d")]
        public double AdjustedVolume30D { get; set; }
    }
}
