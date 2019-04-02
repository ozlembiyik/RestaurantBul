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
    public class AdditionalPlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdditionalPlaces
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var additionalPlaces = db.AdditionalPlaces.Include(a => a.Additional).Include(a => a.Place);
            return View(additionalPlaces.ToList());
        }

        // GET: AdditionalPlaces/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalPlace additionalPlace = db.AdditionalPlaces.Find(id);
            if (additionalPlace == null)
            {
                return HttpNotFound();
            }
            return View(additionalPlace);
        }

        // GET: AdditionalPlaces/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AdditionalId = new SelectList(db.Additionals, "AdditionalId", "AdditionalId");
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName");
            return View();
        }

        // POST: AdditionalPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,PlaceId,AdditionalId")] AdditionalPlace additionalPlace)
        {
            if (ModelState.IsValid)
            {
                db.AdditionalPlaces.Add(additionalPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdditionalId = new SelectList(db.Additionals, "AdditionalId", "AdditionalId", additionalPlace.AdditionalId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", additionalPlace.PlaceId);
            return View(additionalPlace);
        }

        // GET: AdditionalPlaces/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalPlace additionalPlace = db.AdditionalPlaces.Find(id);
            if (additionalPlace == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdditionalId = new SelectList(db.Additionals, "AdditionalId", "AdditionalId", additionalPlace.AdditionalId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", additionalPlace.PlaceId);
            return View(additionalPlace);
        }

        // POST: AdditionalPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,PlaceId,AdditionalId")] AdditionalPlace additionalPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionalPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdditionalId = new SelectList(db.Additionals, "AdditionalId", "AdditionalId", additionalPlace.AdditionalId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "PlaceName", additionalPlace.PlaceId);
            return View(additionalPlace);
        }

        // GET: AdditionalPlaces/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalPlace additionalPlace = db.AdditionalPlaces.Find(id);
            if (additionalPlace == null)
            {
                return HttpNotFound();
            }
            return View(additionalPlace);
        }

        // POST: AdditionalPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            AdditionalPlace additionalPlace = db.AdditionalPlaces.Find(id);
            db.AdditionalPlaces.Remove(additionalPlace);
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
