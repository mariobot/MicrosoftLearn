namespace TwitterXScheduler.Models
{
    public class PostScheduledTweetListRequestDto
    {
        public List<PostScheduledTweetListRequestDto> Tweets { get; set; } = new List<PostScheduledTweetListRequestDto>();
    }
}
