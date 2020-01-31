using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;

namespace TwitterAPI.Controllers
{
    [RoutePrefix("HomeAle")]
    public class HomeAleController : Controller
    {
        // GET: HomeAle
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("ViewTweets")]
        public ActionResult ViewTweets(int numberOfTweets)
        {
            var tc = new TweetsController();
            ViewBag.tweets = tc.GetTweets(numberOfTweets);
            return View();
        }

        [HttpPost]
        [Route("MakeATweet")]
        public ActionResult MakeATweet()
        {
            return View();
        }
    }
}