using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterAPI.Models;

namespace TwitterAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //instanciar modelo y llenarlo con informacion
            //remplazar con API de Twitter y traer hash
            var tweets = new List<Hash_tagModel>()
            {
                new Hash_tagModel()
                {
                    Hash = "#Enero",
                    FechaPublicacion = Convert.ToDateTime("2020/01/29"),
                    Usuario = "fer"
                },
                new Hash_tagModel()
                {
                Hash = "#Febrero",
                FechaPublicacion = Convert.ToDateTime("2020/01/01"),
                Usuario = "Luisfer"
            }
            };

            //enviar la lista por medio de ViewBag para implementar en parcialView

            ViewBag.ListaHashs = tweets; //se le asigna la lista con datos


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var tweets = new List<Hash_tagModel>()
            {
                new Hash_tagModel()
                {
                    Hash = "#Mexico",
                    FechaPublicacion = Convert.ToDateTime("2020/01/29"),
                    Usuario = "user1"
                },
                new Hash_tagModel()
                {
                    Hash = "#USA",
                    FechaPublicacion = Convert.ToDateTime("2020/01/01"),
                    Usuario = "user2"
                }
            };
            ViewBag.ListaHashs = tweets; //se le asigna la lista con datos
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}