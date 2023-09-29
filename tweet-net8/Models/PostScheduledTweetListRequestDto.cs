namespace TwitterXScheduler.Models
{
    public class PostScheduledTweetListRequestDto
    {
        public List<PostScheduleTweetRequestDto> Tweets { get; set; } = new List<PostScheduleTweetRequestDto>();
    }
}
