using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoSemestralBiblioteca.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "DESCRIPTION PAGE";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "CONTACT US";

            return View();
        }

        public ActionResult HelloWorld()
        {
            ViewBag.Message = "Your hello world Page";
            return View();
        }
    }
}