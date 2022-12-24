using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class CoinWhitepaper
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
