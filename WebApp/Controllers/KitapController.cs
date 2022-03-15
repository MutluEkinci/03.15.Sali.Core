using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class KitapController : Controller
    {
        IConfiguration _config;
        public KitapController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            //string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";

            KitapDB db = new KitapDB(_config.GetConnectionString("KitapDB"));
            ViewBag.Ad = new SelectList(db.Liste(), "KitapID", "KitapAd");
            return View(db.Liste());
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Kitap kitap)
        {
            //string strConn = @"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;Initial Catalog=Calısma;Integrated Security=True";
            //KitapDB db = new KitapDB(strConn);

            KitapDB db = new KitapDB(_config.GetConnectionString("KitapDB"));
            db.Ekle(kitap);
            return RedirectToAction("Index");
        }
    }
}
