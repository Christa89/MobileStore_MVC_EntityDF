using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();


        }

        public ActionResult About()
        {
            if(Request.IsAuthenticated)
            {
              ViewBag.Message = "Your application description page.";
               return View();
            }

            return RedirectToAction("Login","Account");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}