using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;
using TwitterAPI.Models;

namespace TwitterAPI.Controllers
{
    public class HomeController : Controller
    {

        

        public ActionResult Index()
        {
            //instanciar modelo y llenarlo con informacion
            //remplazar con API de Twitter y traer hash
            Auth.SetUserCredentials("OmnRr6g9E4nIdy5vW6IE9gJmD", "iY9kah88jg5Hw53qsfQ5UGzpif0V0mOK30Ar5ie2pBfVpFyHan"
                                   , "796462679758163971-NubG7GJva0P1BttmpQoGkot71YTc6f9"
                                   , "aODZ3wD1xD6lxifeWZPO4TzjY7ybD5gYojdMiQXDhEZjt");
            var usertw = Tweetinvi.User.GetAuthenticatedUser();

            //lista de 5 tw
            var tw = Timeline.GetUserTimeline(usertw,5);

            var followers = Timeline.GetRetweetsOfMeTimeline();
           

            ViewBag.listatw = tw;
            return View();
        }

        public ActionResult About()
        {
            //instanciar modelo y llenarlo con informacion
            //remplazar con API de Twitter y traer hash
            Auth.SetUserCredentials("OmnRr6g9E4nIdy5vW6IE9gJmD", "iY9kah88jg5Hw53qsfQ5UGzpif0V0mOK30Ar5ie2pBfVpFyHan"
                , "796462679758163971-NubG7GJva0P1BttmpQoGkot71YTc6f9"
                , "aODZ3wD1xD6lxifeWZPO4TzjY7ybD5gYojdMiQXDhEZjt");
            var usertw = Tweetinvi.User.GetAuthenticatedUser();

            //lista de  Retw
           

            var retweetss = Timeline.GetRetweetsOfMeTimeline();


            ViewBag.listatw = retweetss;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}