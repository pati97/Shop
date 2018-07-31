using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return Content("Witaj!");
        }
        public ActionResult Hello(string id)
        {
            ViewBag.Name = id;
            ViewBag.Weather = "Jest słonecznie!";
            return View();
        }
    }
}