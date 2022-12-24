using Newtonsoft.Json;

namespace CoinpaprikaApi.Models
{
    public class PersonLinks
    {
        [JsonProperty("github")]
        public PersonLink[] Github { get; set; }

        [JsonProperty("linkedin")]
        public PersonLink[] Linkedin { get; set; }

        [JsonProperty("medium")]
        public PersonLink[] Medium { get; set; }

        [JsonProperty("twitter")]
        public PersonLink[] Twitter { get; set; }
    }
}
