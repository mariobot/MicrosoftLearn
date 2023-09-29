using Newtonsoft.Json;

namespace TwitterXScheduler.Models
{
    public class PostScheduleTweetRequestDto
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
        public DateTime ScheduleFor { get; set; }
    }
}
