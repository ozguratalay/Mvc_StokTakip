using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_StokTakip.Models.Entity;
using PagedList;

namespace Mvc_StokTakip.Controllers
{
    public class MusterilerController : Controller
    {

        DbMvc_StokTakipEntities db = new DbMvc_StokTakipEntities();
        // GET: Musteriler
        public ActionResult Musteriler_View(int sayfa=1)
        {
            
            var musterilers = db.Musteriler.ToList().ToPagedList(sayfa,10);
            return View(musterilers);
        }



        public ActionResult SİL(int id)
        {
            //var musteri = db.TBLMUSTERILER.Find(id);
            //db.TBLMUSTERILER.Remove(musteri);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            var delete = db.Musteriler.Find(id);
            db.Musteriler.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Musteriler_View");
        }

        [HttpPost]
        public ActionResult UPDATE(Musteriler id)
        {
            var update = db.Musteriler.Find(id.m_Id);
            update.m_Adi = id.m_Adi;
            update.m_Soy = id.m_Soy;
            db.SaveChanges();
            return RedirectToAction("Musteriler_View");
        }

        public ActionResult UpdateMus(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View("UpdateMus", musteri);
        }

        [HttpPost]
        public ActionResult AddMus(Musteriler id)
        {
            db.Musteriler.Add(id);
            db.SaveChanges();
            return RedirectToAction("Musteriler_View");
        }

        [HttpGet]
        public ActionResult AddMus()
        {
            return View("AddMus");
        }
    }

}