using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class SearchPerson
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teams_count")]
        public int TeamsCount { get; set; }
    }
}
