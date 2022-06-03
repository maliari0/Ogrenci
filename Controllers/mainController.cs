using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci.Models.Entity;

namespace Ogrenci.Controllers
{
    public class mainController : Controller
    {
        // GET: bolumler
        public ActionResult Index()
        {
            return View();
        }
    }
}