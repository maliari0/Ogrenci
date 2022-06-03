using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci.Models.Entity;

namespace Ogrenci.Controllers
{
    
    public class bolumController : Controller
    {
        ogr_otoBM2020Entities entities = new ogr_otoBM2020Entities();
        // GET: bolumler
        public ActionResult Index()
        {
            var doList = entities.bolumler.ToList();
            return View(doList);
        }

        [HttpGet]
        public ActionResult BolumlerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BolumlerEkle(bolumler d1)
        {
            entities.bolumler.Add(d1);
            entities.SaveChanges();
            return View();
        }


        public ActionResult Sil(string id)
        {
            var bolumler = entities.bolumler.Find(id);
            entities.bolumler.Remove(bolumler);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBolumler(string id)
        {
            var d1 = entities.bolumler.Find(id);
            return View("GetBolumler", d1);
        }
        public ActionResult BolumlerGuncelle(bolumler x)
        {
            var d1 = entities.bolumler.Find(x.bkod);
            d1.bkod = x.bkod;
            d1.badi = x.badi;
            d1.bbsk = x.bbsk;
            d1.bkon = x.bkon;

            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}