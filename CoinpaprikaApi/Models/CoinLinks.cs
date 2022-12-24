using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinLinks
    {
        [JsonProperty("explorer")]
        public string[] Explorer { get; set; }

        [JsonProperty("facebook")]
        public string[] Facebook { get; set; }

        [JsonProperty("reddit")]
        public string[] Reddit { get; set; }

        [JsonProperty("source_code")]
        public string[] SourceCode { get; set; }

        [JsonProperty("website")]
        public string[] Website { get; set; }

        [JsonProperty("youtube")]
        public string[] Youtube { get; set; }

        [JsonProperty("medium")]
        public string[] Medium { get; set; }
    }
}
