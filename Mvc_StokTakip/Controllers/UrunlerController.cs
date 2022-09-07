using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_StokTakip.Models.Entity;

namespace Mvc_StokTakip.Controllers
{
    public class UrunlerController : Controller
    {

        DbMvc_StokTakipEntities db = new DbMvc_StokTakipEntities();
        // GET: Urunler
        public ActionResult Urunler_View()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

     
    }
}