using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class CoinResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("is_new")]
        public bool IsNew { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("tags")]
        public CoinTagItem[] Tags { get; set; }

        [JsonProperty("team")]
        public CoinTeamItem[] Team { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("open_source")]
        public bool OpenSource { get; set; }

        [JsonProperty("started_at")]
        public DateTimeOffset? StartedAt { get; set; }

        [JsonProperty("development_status")]
        public string DevelopmentStatus { get; set; }

        [JsonProperty("hardware_wallet")]
        public bool HardwareWallet { get; set; }

        [JsonProperty("proof_type")]
        public string ProofType { get; set; }

        [JsonProperty("org_structure")]
        public string OrgStructure { get; set; }

        [JsonProperty("hash_algorithm")]
        public string HashAlgorithm { get; set; }

        [JsonProperty("links")]
        public CoinLinks Links { get; set; }

        [JsonProperty("links_extended")]
        public CoinLinksExtendedItem[] LinksExtended { get; set; }

        [JsonProperty("whitepaper")]
        public CoinWhitepaper Whitepaper { get; set; }

        [JsonProperty("first_data_at")]
        public DateTimeOffset? FirstDataAt { get; set; }

        [JsonProperty("last_data_at")]
        public DateTimeOffset? LastDataAt { get; set; }
    }
}
