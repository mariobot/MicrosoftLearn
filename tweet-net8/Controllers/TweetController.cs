﻿using Hangfire;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterXScheduler.Models;

namespace TwitterXScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private IConfiguration configuration;

        public TweetController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("bulk")]
        public IActionResult ScheduleTweets(PostScheduledTweetListRequestDto request)
        {
            var invalidTweets = new List<PostScheduleTweetRequestDto>();
            int scheduledTweets = 0;

            foreach (var tweet in request.Tweets)
            {
                TimeSpan delay = tweet.ScheduleFor - DateTime.UtcNow;

                if (delay <= TimeSpan.Zero)
                {
                    invalidTweets.Add(tweet);
                    continue;
                }

                BackgroundJob.Schedule(() => PostTweet(tweet.Adapt<PostTweetRequestDto>()), delay);
                scheduledTweets++;
            }

            string message;
            if (invalidTweets.Any())
            {
                message = $"{scheduledTweets} tweets scheduled successfully " +
                          $"{invalidTweets.Count} tweets had invalid dates and were not scheduled;";
            }
            else 
            {
                message = $"All tweets scheduled successfully";
            }

            return Ok(message);        
        }

        [HttpPost]
        [Route("schedule")]
        public IActionResult ScheduleTweet(PostScheduleTweetRequestDto newTweet)
        {
            var delay = newTweet.ScheduleFor - DateTime.UtcNow;

            if (delay > TimeSpan.Zero)
            {
                BackgroundJob.Schedule(() => PostTweet(newTweet.Adapt<PostTweetRequestDto>()), delay);
                return Ok("Tweet scheduled");
            }
            else 
            {
                return BadRequest("Please enter a valid date and tiem");            
            }        
        }

        [HttpPost]
        [AutomaticRetry(Attempts = 0)]
        public async Task<IActionResult> PostTweet(PostTweetRequestDto newTweet)
        {
            var apiKey = configuration.GetValue<string>("ApiKey");
            var apiKeySecret = configuration.GetValue<string>("ApiKeySecret");
            var apiToken = configuration.GetValue<string>("ApiToken");
            var apiTokenSecret = configuration.GetValue<string>("ApiTokenSecret");

            var client = new TwitterClient(apiKey,apiKeySecret,apiToken,apiTokenSecret);

            var result = await client.Execute.AdvanceRequestAsync(BuildTwitterRequest(newTweet,client));

            return Ok(result.Content);
        }

        private static Action<ITwitterRequest> BuildTwitterRequest(PostTweetRequestDto newTweet, TwitterClient client)
        {
            return (ITwitterRequest request) =>
            {
                var jsonBody = client.Json.Serialize(newTweet);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                request.Query.Url = "https://api.twitter.com/2/tweets";
                request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                request.Query.HttpContent = content;
            };
        }
    }
}
