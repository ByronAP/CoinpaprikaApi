using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class PersonLink
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("followers")]
        public int? Followers { get; set; }
    }
}
