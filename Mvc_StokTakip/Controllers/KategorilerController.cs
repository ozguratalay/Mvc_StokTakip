using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_StokTakip.Models.Entity;

namespace Mvc_StokTakip.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        DbMvc_StokTakipEntities db = new DbMvc_StokTakipEntities();
        public ActionResult Index()
        {
            var kategorilers = db.Kategoriler.ToList();
            return View(kategorilers);
        }

         public ActionResult SİL(int id)
         {
            //var musteri = db.TBLMUSTERILER.Find(id);
             //db.TBLMUSTERILER.Remove(musteri);
             //db.SaveChanges();
             //return RedirectToAction("Index");
             var delete = db.Kategoriler.Find(id);
             db.Kategoriler.Remove(delete);
             db.SaveChanges();
             return RedirectToAction("Index");
         }

        [HttpPost]
        public ActionResult UPDATE (Kategoriler id)
        {
            var update = db.Kategoriler.Find(id.k_Id);
            update.k_Adi = id.k_Adi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateKtgr (int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("UpdateKtgr", kategori);
        }

        [HttpPost]
        public ActionResult AddKtgr(Kategoriler id)
        {
            if (!ModelState.IsValid)
            {
                return View("AddKtgr");
            }


            db.Kategoriler.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddKtgr()
        {
            return View("AddKtgr");
        }
    }
}