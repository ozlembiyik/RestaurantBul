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
    public class AdditionalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Additionals
        public ActionResult Index()
        {
            return View(db.Additionals.ToList());
        }

        // GET: Additionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // GET: Additionals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Additionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdditionalId,Otopark,DenizKenari,DisMekan,İcMekan,TerasiVar,AlkolServis,Wifi,OnlineRezervasyon,Kahvalti,GelAl,HayvanDostu,SigaraAlanı,PaketServis,TatlivePasta,CanliMuzik")] Additional additional)
        {
            if (ModelState.IsValid)
            {
                db.Additionals.Add(additional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(additional);
        }

        // GET: Additionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // POST: Additionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdditionalId,Otopark,DenizKenari,DisMekan,İcMekan,TerasiVar,AlkolServis,Wifi,OnlineRezervasyon,Kahvalti,GelAl,HayvanDostu,SigaraAlanı,PaketServis,TatlivePasta,CanliMuzik")] Additional additional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additional);
        }

        // GET: Additionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // POST: Additionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Additional additional = db.Additionals.Find(id);
            db.Additionals.Remove(additional);
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
