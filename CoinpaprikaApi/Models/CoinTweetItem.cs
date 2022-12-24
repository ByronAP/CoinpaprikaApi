using Newtonsoft.Json;
using System;

namespace CoinpaprikaApi.Models
{
    public class CoinTweetItem
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("user_image_link")]
        public string UserImageLink { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_retweet")]
        public bool IsRetweet { get; set; }

        [JsonProperty("retweet_count")]
        public int? RetweetCount { get; set; }

        [JsonProperty("like_count")]
        public int? LikeCount { get; set; }

        [JsonProperty("status_link")]
        public string StatusLink { get; set; }

        [JsonProperty("status_id")]
        public string StatusId { get; set; }

        [JsonProperty("media_link", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaLink { get; set; }

        [JsonProperty("youtube_link", NullValueHandling = NullValueHandling.Ignore)]
        public string YoutubeLink { get; set; }
    }
}
