using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CangooruMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Order");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
