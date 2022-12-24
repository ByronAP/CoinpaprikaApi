using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinTeamItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
    }
}
