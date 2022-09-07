using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_StokTakip.Models.Entity;

namespace Mvc_StokTakip.Controllers
{
    public class SatislarController : Controller
    {

        DbMvc_StokTakipEntities db = new DbMvc_StokTakipEntities();
        // GET: Satislar
        public ActionResult Satislar_View()
        {
            var satislar = db.Satislar.ToList();
            return View(satislar);
        }

        [HttpPost]
        public ActionResult UpdateSatis(Satislar id)
        {
            var update = db.Satislar.Find(id.s_Id);
            update.s_Adi = id.s_Adi;
            update.s_Fiyat = id.s_Fiyat;
            update.s_Adet = id.s_Adet;
            db.SaveChanges();
            return RedirectToAction("Satislar_View");
        }

        [HttpGet]
        public ActionResult UpdateSatislar(int id)
        {
            var update = db.Satislar.Find(id);
            return View("UpdateSatislar",update);
        }

        [HttpPost]
        public ActionResult AddSatis(Satislar id)
        {
            var urun = db.Urunler.Where(m => m.u_Id == id.Urunler.u_Id).FirstOrDefault();
            id.Urunler = urun;
            db.Satislar.Add(id);
            db.SaveChanges();
            return RedirectToAction("Satislar_View");
        }

        [HttpGet]
        public ActionResult AddSatis()
        {
            //List<SelectListItem> deger = (from item in db.Urunler.ToList()
            //                              select new SelectListItem
            //                              {
            //                                  Value = item.u_Id.ToString(),
            //                                  Text = item.u_Adi
            //                              }
            //                             ).ToList();
            //ViewBag.dgr = deger;
            ViewBag.UrunlerOptions = new SelectList(db.Urunler.ToList(), "u_Id", "u_Adi");
            ViewBag.MusterilerOptions = new SelectList(db.Musteriler.ToList(), "m_Id", "m_Adi");
            return View("AddSatis");
        }

        public ActionResult SİL(int id)
        {
           
            var delete = db.Satislar.Find(id);
            db.Satislar.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Satislar_View");
        }
    }
}