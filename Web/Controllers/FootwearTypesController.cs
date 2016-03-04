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
    public class FootwearTypesController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: FootwearTypes
        public ActionResult Index()
        {
            return View(db.FootwearTypes.ToList());
        }

        // GET: FootwearTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootwearType footwearType = db.FootwearTypes.Find(id);
            if (footwearType == null)
            {
                return HttpNotFound();
            }
            return View(footwearType);
        }

        // GET: FootwearTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootwearTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FootwearTypeId,FootwearTypeValue")] FootwearType footwearType)
        {
            if (ModelState.IsValid)
            {
                db.FootwearTypes.Add(footwearType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footwearType);
        }

        // GET: FootwearTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootwearType footwearType = db.FootwearTypes.Find(id);
            if (footwearType == null)
            {
                return HttpNotFound();
            }
            return View(footwearType);
        }

        // POST: FootwearTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FootwearTypeId,FootwearTypeValue")] FootwearType footwearType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footwearType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footwearType);
        }

        // GET: FootwearTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootwearType footwearType = db.FootwearTypes.Find(id);
            if (footwearType == null)
            {
                return HttpNotFound();
            }
            return View(footwearType);
        }

        // POST: FootwearTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FootwearType footwearType = db.FootwearTypes.Find(id);
            db.FootwearTypes.Remove(footwearType);
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
