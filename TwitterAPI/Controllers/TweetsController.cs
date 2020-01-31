using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterAPI.Controllers
{
    [RoutePrefix("API")]
    public class TweetsController : ApiController
    {
        public const string CustomerKey = "OmnRr6g9E4nIdy5vW6IE9gJmD";
        public const string CustomerSecKey = "iY9kah88jg5Hw53qsfQ5UGzpif0V0mOK30Ar5ie2pBfVpFyHan";
        public const string AccTkn = "796462679758163971-NubG7GJva0P1BttmpQoGkot71YTc6f9";
        public const string AccSecTkn = "aODZ3wD1xD6lxifeWZPO4TzjY7ybD5gYojdMiQXDhEZjt";

        [Route("Tweets")]
        [HttpGet]
        public IEnumerable<ITweet> GetTweets(int numberOfTweets)
        {
            IEnumerable<ITweet> tweet = null;
            try
            {
                Auth.SetUserCredentials(CustomerKey, CustomerSecKey, AccTkn, AccSecTkn);
                tweet = Timeline.GetHomeTimeline(numberOfTweets);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return tweet;
        }

        [Route("MakeATweet")]
        [HttpPost]
        public ITweet MakeATweet(string text)
        {
            try
            {
                Auth.SetUserCredentials(CustomerKey, CustomerSecKey, AccTkn, AccSecTkn);
                return Tweet.PublishTweet(text);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

        [Route("UpdateTheLastTweet")]
        [HttpPut]
        public void UpdateTheLastTweet(string text)
        {
            try
            {
                Auth.SetUserCredentials(CustomerKey, CustomerSecKey, AccTkn, AccSecTkn);
                var authenticatedUser = Tweetinvi.User.GetAuthenticatedUser();
                var homeTimeline = authenticatedUser.GetHomeTimeline();
                var tweet = homeTimeline.FirstOrDefault();
                Tweet.DestroyTweet(tweet);
                Tweet.PublishTweet(text);
            }
            catch
            {

            }
        }

        [Route("Delete")]
        [HttpDelete]
        public ITweet DeleteATweet(long id)
        {
            try
            {
                Auth.SetUserCredentials(CustomerKey, CustomerSecKey, AccTkn, AccSecTkn);
                var tweet = Tweet.GetTweet(id);
                Tweet.DestroyTweet(tweet);
                return tweet;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
