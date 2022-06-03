using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci.Models.Entity;

namespace Ogrenci.Controllers
{

    public class akademikController : Controller
    {
        ogr_otoBM2020Entities entities = new ogr_otoBM2020Entities();
        // GET: akademik
        public ActionResult Index()
        {
            var doList = entities.akademik.ToList();
            return View(doList);
        }

        [HttpGet]
        public ActionResult AkademikEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AkademikEkle(akademik d1)
        {
            entities.akademik.Add(d1);
            entities.SaveChanges();
            return View();
        }


        public ActionResult Sil(string id)
        {
            var akademik = entities.akademik.Find(id);
            entities.akademik.Remove(akademik);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAkademik(string id)
        {
            var d1 = entities.akademik.Find(id);
            return View("GetAkademik", d1);
        }
        public ActionResult AkademikGuncelle(akademik x)
        {
            var d1 = entities.akademik.Find(x.pkod);
            d1.pkod = x.pkod;
            d1.sicilno = x.sicilno;
            d1.padi = x.padi;
            d1.psoyadi = x.psoyadi;
            d1.bransi = x.bransi;
            d1.bolumu = x.bolumu;
            d1.ptc = x.ptc;

            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}