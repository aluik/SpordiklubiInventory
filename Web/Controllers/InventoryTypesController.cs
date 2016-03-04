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
    public class InventoryTypesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: InventoryTypes
        public ActionResult Index()
        {
            return View(db.InventoryTypes.ToList());
        }

        // GET: InventoryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryType inventoryType = db.InventoryTypes.Find(id);
            if (inventoryType == null)
            {
                return HttpNotFound();
            }
            return View(inventoryType);
        }

        // GET: InventoryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryTypeId,InventoryTypeValue")] InventoryType inventoryType)
        {
            if (ModelState.IsValid)
            {
                db.InventoryTypes.Add(inventoryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryType);
        }

        // GET: InventoryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryType inventoryType = db.InventoryTypes.Find(id);
            if (inventoryType == null)
            {
                return HttpNotFound();
            }
            return View(inventoryType);
        }

        // POST: InventoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryTypeId,InventoryTypeValue")] InventoryType inventoryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryType);
        }

        // GET: InventoryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryType inventoryType = db.InventoryTypes.Find(id);
            if (inventoryType == null)
            {
                return HttpNotFound();
            }
            return View(inventoryType);
        }

        // POST: InventoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryType inventoryType = db.InventoryTypes.Find(id);
            db.InventoryTypes.Remove(inventoryType);
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
