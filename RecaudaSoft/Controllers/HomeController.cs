using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecaudaSoft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bievenido " + User.Identity.Name;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
