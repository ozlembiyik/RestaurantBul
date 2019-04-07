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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        public ActionResult AllPlace()
        {
            var result = db.Places.ToList();
            db.SaveChanges();
            return View(result);

        }

        public ActionResult Additionals(int id)
        {

            var result = (from a in db.Places
                          join b in db.AdditionalPlaces on a.PlaceId equals b.PlaceId
                          join c in db.Additionals on b.AdditionalId equals c.AdditionalId
                          where a.PlaceId == id
                          select new PlaceAdditionalViewModel
                          {
                              AlkolServis = c.AlkolServis,
                              CanliMuzik = c.CanliMuzik,
                              DenizKenari = c.DenizKenari,
                              DisMekan = c.DisMekan,
                              GelAl = c.GelAl,
                              HayvanDostu = c.HayvanDostu,
                              Kahvalti = c.Kahvalti,
                              OnlineRezervasyon = c.OnlineRezervasyon,
                              Otopark = c.Otopark,
                              PaketServis = c.PaketServis,
                              SigaraAlanı = c.SigaraAlanı,
                              TatlivePasta = c.TatlivePasta,
                              TerasiVar = c.TerasiVar,
                              Wifi = c.Wifi,
                              İcMekan = c.İcMekan


                          }).FirstOrDefault();


            return PartialView(result);

        }

        public ActionResult PopularPlace()
        {
            var result = (from a in db.Places
                          join c in db.Comments on a.PlaceId equals c.PlaceId
                          join f in db.AdditionalPlaces on a.PlaceId equals f.PlaceId
                          select new PlaceAdditionalViewModel()
                          {
                              MenuPic=a.MenuPic,
                              PlaceName = a.PlaceName,
                              CommentContent = c.CommentContent,
                              CommentPoint =c.CommentPoint,
                              AvgPrice = a.AvgPrice,
                              County = a.County,
                              CloseTime = a.CloseTime,
                              OpenTime = a.OpenTime
                          }).OrderByDescending(x=>x.CommentPoint>3).Take(3).ToList();
            return View(result);

        }

        public ActionResult CommentList(int id)
        {
            var result = (from a in db.Places
                          join c in db.Comments on a.PlaceId equals c.PlaceId
                          where a.PlaceId == id
                          select new PlaceCommentViewModel()
                          {
                              PlaceId = a.PlaceId,
                              CommentContent=c.CommentContent,
                              PlaceName=a.PlaceName,
                              UserName=c.ApplicationUser.UserName,
                              CategoryName=a.CategoryName,
                              CommentPhoto=c.CommentPhoto,
                               CommentPoint=c.CommentPoint,
                          }).ToList();
                       
            return View(result);
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
        public ActionResult PlaceDetails(int id)
        {
            int mekanid= db.Places.FirstOrDefault(x => x.PlaceId == id).PlaceId;

            var result = (from a in db.Places
                          join e in db.AdditionalPlaces on a.PlaceId equals e.PlaceId
                          where a.PlaceId==id
                          select new PlaceCommentViewModel
                          {
                              PlaceName=a.PlaceName,
                             MenuPic=a.MenuPic,
                             OpenTime=a.OpenTime,
                             CloseTime=a.CloseTime,
                             AvgPrice=a.AvgPrice,
                             Adress=a.Adress,
                             Phone=a.Phone,
                             City=a.City,
                             County=a.County
                          }).ToList();

            return View(result.FirstOrDefault());
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

        //[HttpGet]
        //public ActionResult SearchPlace()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult SearchPlace(string search)
        {
           
            var aranan = db.Places.Where(x => x.PlaceName==search || x.City==search).ToList();
            return View(aranan.OrderByDescending(x=>x.AvgPrice>50));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddPlace()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
