using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class FootwearsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Footwears
        public ActionResult Index()
        {
            var footwears = db.Footwears.Include(f => f.FootwearType).Include(f => f.Inventory);
            return View(footwears.ToList());
        }

        // GET: Footwears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footwear footwear = db.Footwears.Find(id);
            if (footwear == null)
            {
                return HttpNotFound();
            }
            return View(footwear);
        }

        // GET: Footwears/Create
        public ActionResult Create()
        {
            ViewBag.FootwearTypeId = new SelectList(db.FootwearTypes, "FootwearTypeId", "FootwearTypeValue");
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId");
            return View();
        }

        // POST: Footwears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FootwearId,FootwearValue,MadeBy,Size,FootwearTypeId,InventoryId")] Footwear footwear)
        {
            if (ModelState.IsValid)
            {
                db.Footwears.Add(footwear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FootwearTypeId = new SelectList(db.FootwearTypes, "FootwearTypeId", "FootwearTypeValue", footwear.FootwearTypeId);
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", footwear.InventoryId);
            return View(footwear);
        }

        // GET: Footwears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footwear footwear = db.Footwears.Find(id);
            if (footwear == null)
            {
                return HttpNotFound();
            }
            ViewBag.FootwearTypeId = new SelectList(db.FootwearTypes, "FootwearTypeId", "FootwearTypeValue", footwear.FootwearTypeId);
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", footwear.InventoryId);
            return View(footwear);
        }

        // POST: Footwears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FootwearId,FootwearValue,MadeBy,Size,FootwearTypeId,InventoryId")] Footwear footwear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footwear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FootwearTypeId = new SelectList(db.FootwearTypes, "FootwearTypeId", "FootwearTypeValue", footwear.FootwearTypeId);
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", footwear.InventoryId);
            return View(footwear);
        }

        // GET: Footwears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footwear footwear = db.Footwears.Find(id);
            if (footwear == null)
            {
                return HttpNotFound();
            }
            return View(footwear);
        }

        // POST: Footwears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Footwear footwear = db.Footwears.Find(id);
            db.Footwears.Remove(footwear);
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
