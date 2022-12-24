using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class CoinEventItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("date_to")]
        public DateTimeOffset? DateTo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_conference")]
        public bool IsConference { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("proof_image_link")]
        public string ProofImageLink { get; set; }
    }
}
