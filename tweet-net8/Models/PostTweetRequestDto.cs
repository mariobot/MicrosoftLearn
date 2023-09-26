using Newtonsoft.Json;

namespace TwitterXScheduler.Models
{
    public class PostTweetRequestDto
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
    }
}
