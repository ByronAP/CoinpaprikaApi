using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class KeyInfoResponse
    {
        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("plan_started_at")]
        public DateTimeOffset? PlanStartedAt { get; set; }

        [JsonProperty("plan_status")]
        public string PlanStatus { get; set; }

        [JsonProperty("portal_url")]
        public string PortalUrl { get; set; }

        [JsonProperty("usage")]
        public KeyUsage Usage { get; set; }
    }
}
