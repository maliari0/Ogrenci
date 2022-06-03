using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci.Models.Entity;

namespace Ogrenci.Controllers
{
    public class derslerController : Controller
    {
        ogr_otoBM2020Entities entities = new ogr_otoBM2020Entities();
        // GET: dersler
        
        public ActionResult Index()
        {
            var doList = entities.ders.ToList();
            return View(doList);
        }

        [HttpGet]
        public ActionResult dersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dersEkle(ders d1)
        {
            entities.ders.Add(d1);
            entities.SaveChanges();
            return View();
        }


        public ActionResult Sil(string id)
        {
            var ders = entities.ders.Find(id);
            entities.ders.Remove(ders);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDers(string id)
        {
            var d1 = entities.ders.Find(id);
            return View("GetDers", d1);
        }
        public ActionResult DersGuncelle(ders x)
        {
            var d1 = entities.ders.Find(x.dkod);
            d1.dkod = x.dkod;
            d1.dadi = x.dadi;
            d1.dteo = x.dteo;
            d1.duyg = x.duyg;
            d1.dakts = x.dakts;

            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}