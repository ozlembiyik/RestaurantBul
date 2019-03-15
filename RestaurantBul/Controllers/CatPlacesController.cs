using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantBul.Models;

namespace RestaurantBul.Controllers
{
    public class CatPlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CatPlaces
        public ActionResult Index()
        {
            var catPlaces = db.CatPlaces.Include(c => c.Category).Include(c => c.Place);
            return View(catPlaces.ToList());
        }

        // GET: CatPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatPlace catPlace = db.CatPlaces.Find(id);
            if (catPlace == null)
            {
                return HttpNotFound();
            }
            return View(catPlace);
        }

        // GET: CatPlaces/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryId");
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            return View();
        }

        // POST: CatPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatPlaceId,PlaceId,CategoryId")] CatPlace catPlace)
        {
            if (ModelState.IsValid)
            {
                db.CatPlaces.Add(catPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryId", catPlace.CategoryId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", catPlace.PlaceId);
            return View(catPlace);
        }

        // GET: CatPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatPlace catPlace = db.CatPlaces.Find(id);
            if (catPlace == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryId", catPlace.CategoryId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", catPlace.PlaceId);
            return View(catPlace);
        }

        // POST: CatPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatPlaceId,PlaceId,CategoryId")] CatPlace catPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryId", catPlace.CategoryId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", catPlace.PlaceId);
            return View(catPlace);
        }

        // GET: CatPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatPlace catPlace = db.CatPlaces.Find(id);
            if (catPlace == null)
            {
                return HttpNotFound();
            }
            return View(catPlace);
        }

        // POST: CatPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatPlace catPlace = db.CatPlaces.Find(id);
            db.CatPlaces.Remove(catPlace);
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
