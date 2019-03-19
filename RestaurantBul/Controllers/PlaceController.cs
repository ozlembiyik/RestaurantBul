using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantBul.Models;
using RestaurantBul.Models.ViewModel;

namespace RestaurantBul.Controllers
{
    public class PlaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Place
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        // GET: Place/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Place/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceAdditionalViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Place place = new Place();
                place.Adress = viewmodel.Adress;
                place.AvgPrice = viewmodel.AvgPrice;
                place.CategoryName = viewmodel.CategoryName;
                place.City = viewmodel.City;
                place.CloseTime = viewmodel.CloseTime;
                place.OpenTime = viewmodel.OpenTime;
                place.Phone = viewmodel.Phone;
                place.MenuPic = viewmodel.MenuPic;
                place.County = viewmodel.County;
                place.PlaceName = viewmodel.PlaceName;

                Additional add = new Additional();
                add.AlkolServis = viewmodel.AlkolServis;
                add.CanliMuzik = viewmodel.CanliMuzik;
                add.DenizKenari = viewmodel.DenizKenari;
                add.DisMekan = viewmodel.DisMekan;
                add.GelAl = viewmodel.GelAl;
                add.HayvanDostu = viewmodel.HayvanDostu;
                add.Kahvalti = viewmodel.Kahvalti;
                add.OnlineRezervasyon = viewmodel.OnlineRezervasyon;
                add.Otopark = viewmodel.Otopark;
                add.PaketServis = viewmodel.PaketServis;
                add.SigaraAlanı = viewmodel.SigaraAlanı;
                add.TatlivePasta = viewmodel.TatlivePasta;
                add.TerasiVar = viewmodel.TerasiVar;
                add.Wifi = viewmodel.Wifi;
                add.İcMekan = viewmodel.İcMekan;

                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewmodel);
        }

        // GET: Place/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Place/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceId,PlaceName,CategoryName,MenuPic,Phone,Adress,County,City,OpenTime,CloseTime,AvgPrice")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Place/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Place/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
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
