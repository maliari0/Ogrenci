using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci.Models.Entity;

namespace Ogrenci.Controllers
{
    public class notlarController : Controller
    {
        ogr_otoBM2020Entities entities = new ogr_otoBM2020Entities();
        // GET: notlar
        public ActionResult Index()
        {
            var doList = entities.notlar.ToList();
            return View(doList);
        }

        [HttpGet]
        public ActionResult NotlarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotlarEkle(notlar d1)
        {
            entities.notlar.Add(d1);
            entities.SaveChanges();
            return View();
        }


        public ActionResult Sil(string id)
        {
            var notlar = entities.notlar.Find(id);
            entities.notlar.Remove(notlar);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetNotlar(string id)
        {
            var d1 = entities.notlar.Find(id);
            return View("GetNotlar", d1);
        }
        public ActionResult NotlarGuncelle(notlar x)
        {
            var d1 = entities.notlar.Find(x.ogrno);
            d1.ogrno = x.ogrno;
            d1.dkod = x.dkod;
            d1.vize = x.vize;
            d1.final = x.final;
            d1.ddurum = x.ddurum;

            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}