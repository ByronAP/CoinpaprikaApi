using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class PersonResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("teams_count")]
        public int TeamsCount { get; set; }

        [JsonProperty("links")]
        public PersonLinks Links { get; set; }

        [JsonProperty("positions")]
        public PersonPosition[] Positions { get; set; }
    }
}
