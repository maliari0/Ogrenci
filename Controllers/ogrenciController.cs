using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci.Models.Entity;

namespace Ogrenci.Controllers
{
    public class ogrenciController : Controller
    {
        ogr_otoBM2020Entities entities = new ogr_otoBM2020Entities();


        // GET: ogrenci
        public ActionResult Index()
        {
            var doList = entities.ogrenci.ToList();
            return View(doList);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(ogrenci ogr)
        {
            entities.ogrenci.Add(ogr);
            entities.SaveChanges();
            return View();
        }

        
        public ActionResult Sil(string id)
        {
            var ogrenci = entities.ogrenci.Find(id);
            entities.ogrenci.Remove(ogrenci);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetOgrenci(string no)
        {
            var ogr = entities.ogrenci.Find(no);
            return View("GetOgrenci", ogr);
        }
        public ActionResult OgrenciGuncelle(ogrenci x)
        {
            var ogr = entities.ogrenci.Find(x.ogrno);
            ogr.ogrno = x.ogrno;
            ogr.ogrtcno = x.ogrtcno;
            ogr.ogradi = x.ogradi;
            ogr.ogrsoyadi = x.ogrsoyadi;
            ogr.ogradres = x.ogradres;
            ogr.ogrbolumu = x.ogrbolumu;
            ogr.ogrcins = x.ogrcins;
            ogr.ogrdogumtar = x.ogrdogumtar;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}