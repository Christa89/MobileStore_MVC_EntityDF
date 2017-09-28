using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Microsoft.AspNet.Identity;

namespace MobileStore.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        private mobileStoreEntities db = new mobileStoreEntities();

        public ActionResult Index()
        {
           
           
            if (Request.IsAuthenticated)
            {
                var usrId =User.Identity.GetUserId();
               // int?  cusId = Convert.ToInt32(Session["CustomerID"].ToString());
                int? cusId = Convert.ToInt32(db.tblCustomers.SingleOrDefault(x => x.UserId == usrId).CusId.ToString());
              var tblmodels = db.tblCarts.Include(t => t.tblModel).Where(x=>x.CusId == cusId);

              return View(tblmodels.ToList());
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult AddCart(tblModel TestRoute1)
        {

            tblCart cart = new tblCart();
            cart.CusId = 3;
            cart.ModelId = TestRoute1.ModelId;
            cart.PurcharseDate = TestRoute1.PurcharseDate;

            if(ModelState.IsValid)
            {
                db.tblCarts.Add(cart);
                db.SaveChanges();
                TempData["AlertMessage"] = "my alert message";
                return RedirectToAction("index","product");
            }

            return RedirectToAction("index", new { id = "1" });


           
        }
	}
}