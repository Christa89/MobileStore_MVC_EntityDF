using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace MobileStore.Controllers
{
    public class ProductController : Controller
    {
        private mobileStoreEntities db = new mobileStoreEntities();

        // GET: /Product/
        public ActionResult Index()  
        {

            if(Request.IsAuthenticated)
            {
                ViewBag.Auth = true;
                var tblmodels = db.tblModels.Include(t => t.tblBrand).Include(t => t.tblDiscount)
               .Include(t => t.tblStock).Include(t => t.tblType);
                return View(tblmodels.ToList());
            }

            else
            {
                ViewBag.Auth = false;
                var tblmodels = db.tblModels.Include(t => t.tblBrand).Include(t => t.tblDiscount)
              .Include(t => t.tblStock).Include(t => t.tblCarts);
                return View(tblmodels.ToList());

            }
             

          //  return RedirectToAction("Login", "Account", new { returnUrl ="product\\Index"});
           
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblmodel = db.tblModels.Find(id);
            if (tblmodel == null)
            {
                return HttpNotFound();
            }
            return View(tblmodel);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.tblBrands, "BrandId", "BrandName");
            ViewBag.DiscountId = new SelectList(db.tblDiscounts, "DiscountId", "DiscountName");
            ViewBag.StockId = new SelectList(db.tblStocks, "StockId", "StockId");
            ViewBag.TypeId = new SelectList(db.tblTypes, "TypeId", "TypeName");
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ModelId,ModelName,ModelImagePath,IsAvailable,BrandId,TypeId,Price,DiscountId,StockId")] tblModel tblmodel)
        {
            if (ModelState.IsValid)
            {
                db.tblModels.Add(tblmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.tblBrands, "BrandId", "BrandName", tblmodel.BrandId);
            ViewBag.DiscountId = new SelectList(db.tblDiscounts, "DiscountId", "DiscountName", tblmodel.DiscountId);
            ViewBag.StockId = new SelectList(db.tblStocks, "StockId", "StockId", tblmodel.StockId);
            ViewBag.TypeId = new SelectList(db.tblTypes, "TypeId", "TypeName", tblmodel.TypeId);
            return View(tblmodel);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblmodel = db.tblModels.Find(id);
            if (tblmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.tblBrands, "BrandId", "BrandName", tblmodel.BrandId);
            ViewBag.DiscountId = new SelectList(db.tblDiscounts, "DiscountId", "DiscountName", tblmodel.DiscountId);
            ViewBag.StockId = new SelectList(db.tblStocks, "StockId", "StockId", tblmodel.StockId);
            ViewBag.TypeId = new SelectList(db.tblTypes, "TypeId", "TypeName", tblmodel.TypeId);
            return View(tblmodel);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ModelId,ModelName,ModelImagePath,IsAvailable,BrandId,TypeId,Price,DiscountId,StockId")] tblModel tblmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.tblBrands, "BrandId", "BrandName", tblmodel.BrandId);
            ViewBag.DiscountId = new SelectList(db.tblDiscounts, "DiscountId", "DiscountName", tblmodel.DiscountId);
            ViewBag.StockId = new SelectList(db.tblStocks, "StockId", "StockId", tblmodel.StockId);
            ViewBag.TypeId = new SelectList(db.tblTypes, "TypeId", "TypeName", tblmodel.TypeId);
            return View(tblmodel);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblmodel = db.tblModels.Find(id);
            if (tblmodel == null)
            {
                return HttpNotFound();
            }
            return View(tblmodel);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblModel tblmodel = db.tblModels.Find(id);
            db.tblModels.Remove(tblmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
