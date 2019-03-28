using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RestaurantBul.Models;
using RestaurantBul.Models.ViewModel;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Controllers
{
    public class PlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Places
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        public ActionResult BreakfastList()
        {
            CategoryName breakfast = CategoryName.Kahvalti;
            var result = db.Places.Where(x => x.CategoryName == breakfast).ToList();
            db.SaveChanges();
            return View(result);
        }

        public ActionResult EnjoyList()
        {
            CategoryName enjoy =CategoryName.EglenceyeCik;
            var result = db.Places.Where(x => x.CategoryName ==enjoy).ToList();
            db.SaveChanges();
            return View(result);
        }

        public ActionResult EatAndOutList()
        {
            CategoryName eatout = CategoryName.YeveKalk;
            var result = db.Places.Where(x => x.CategoryName == eatout).ToList();
            db.SaveChanges();
            return View(result);
        }

        public ActionResult EatList()
        {
            CategoryName eat = CategoryName.Yemek;
            var result = db.Places.Where(x => x.CategoryName == eat).ToList();
            db.SaveChanges();
            return View(result);
        }
        public ActionResult CafeList()
        {
            CategoryName cafe = CategoryName.YeveKalk;
            var result = db.Places.Where(x => x.CategoryName == cafe).ToList();
            db.SaveChanges();
            return View(result);
        }
        public ActionResult PlaceDetails()
        {
            return View();
        }
        //public JsonResult YorumYap(Comment yorum, int PlaceID,string yorums)
        //{
        //    string usid = User.Identity.GetUserId();
        //    var result = (from a in db.Users
        //              where a.Id == usid
        //              select a).FirstOrDefault();
        //    yorum.ApplicationUser = result;
        //    if (yorums != null)
        //    {
        //        db.Comments.Add(new Comment {PlaceId = PlaceID,CommentContent=yorums,UserId=usid});
        //    }

        //    return Json(false, JsonRequestBehavior.AllowGet);     
        //}

        public ActionResult SearchPlace(string search = null)
        {
            CategoryName catname = new CategoryName();
            var aranan = db.Places.Where(x => x.PlaceName.Contains(search)).ToList();
            return View();
        }



        [HttpGet]
        public ActionResult AddPlace()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPlace(PlaceAdditionalViewModel p, HttpPostedFileBase MenuPic)
        {
            Place place = new Place();
            Additional additional = new Additional();
            AdditionalPlace ap = new AdditionalPlace();

            if (MenuPic != null)
            {
                WebImage img = new WebImage(MenuPic.InputStream);
                FileInfo photoInfo = new FileInfo(MenuPic.FileName);

                string newfoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                img.Resize(800, 350); //resim boyutu için
                img.Save("../UpLoads/MenuPic/" + newfoto);
                place.MenuPic = "../UpLoads/MenuPic/" + newfoto;
                place.PlaceName = p.PlaceName;
                //place.MenuPic = p.MenuPic;
                place.CategoryName = p.CategoryName;
                place.Phone = p.Phone;
                place.Adress = p.Adress;
                place.County = p.County;
                place.City = p.City;
                place.OpenTime = p.OpenTime;
                place.CloseTime = p.CloseTime;
                place.AvgPrice = p.AvgPrice;
            }

            db.Places.Add(place);
            db.SaveChanges();

            int sonmekan = db.Places.OrderByDescending(x => x.PlaceId).FirstOrDefault().PlaceId;

            #region MyRegion
            additional.AlkolServis = p.AlkolServis;
            additional.CanliMuzik = p.CanliMuzik;
            additional.DenizKenari = p.DenizKenari;
            additional.DisMekan = p.DisMekan;
            additional.GelAl = p.GelAl;
            additional.HayvanDostu = p.HayvanDostu;
            additional.Kahvalti = p.Kahvalti;
            additional.OnlineRezervasyon = p.OnlineRezervasyon;
            additional.Otopark = p.Otopark;
            additional.PaketServis = p.PaketServis;
            additional.SigaraAlanı = p.SigaraAlanı;
            additional.TatlivePasta = p.TatlivePasta;
            additional.TerasiVar = p.TerasiVar;
            additional.Wifi = p.Wifi;
            additional.İcMekan = p.İcMekan;
            #endregion
            db.Additionals.Add(additional);
            db.SaveChanges();

            int sonid = db.Additionals.OrderByDescending(x => x.AdditionalId).FirstOrDefault().AdditionalId;


            ap.PlaceId = sonmekan;
            ap.AdditionalId = sonid;
            db.AdditionalPlaces.Add(ap);
            db.SaveChanges();

            return View();

        }

            // GET: Places/Details/5
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

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceId,PlaceName,CategoryName,MenuPic,Phone,Adress,County,City,OpenTime,CloseTime,AvgPrice")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

      
        // GET: Places/Edit/5
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

        // POST: Places/Edit/5
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

        // GET: Places/Delete/5
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

        // POST: Places/Delete/5
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
