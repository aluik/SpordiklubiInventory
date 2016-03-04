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
    public class RentingsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Rentings
        public ActionResult Index()
        {
            var rentings = db.Rentings.Include(r => r.Inventory).Include(r => r.User);
            return View(rentings.ToList());
        }

        // GET: Rentings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renting renting = db.Rentings.Find(id);
            if (renting == null)
            {
                return HttpNotFound();
            }
            return View(renting);
        }

        // GET: Rentings/Create
        public ActionResult Create()
        {
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: Rentings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentingId,RentValue,Beginning,End,UserId,InventoryId")] Renting renting)
        {
            if (ModelState.IsValid)
            {
                db.Rentings.Add(renting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", renting.InventoryId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", renting.UserId);
            return View(renting);
        }

        // GET: Rentings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renting renting = db.Rentings.Find(id);
            if (renting == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", renting.InventoryId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", renting.UserId);
            return View(renting);
        }

        // POST: Rentings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentingId,RentValue,Beginning,End,UserId,InventoryId")] Renting renting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "InventoryId", renting.InventoryId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", renting.UserId);
            return View(renting);
        }

        // GET: Rentings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renting renting = db.Rentings.Find(id);
            if (renting == null)
            {
                return HttpNotFound();
            }
            return View(renting);
        }

        // POST: Rentings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renting renting = db.Rentings.Find(id);
            db.Rentings.Remove(renting);
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
