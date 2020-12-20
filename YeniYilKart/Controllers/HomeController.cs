using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniYilKart.Models;

namespace YeniYilKart.Controllers
{
    public class HomeController : Controller
    {
        UygulamaDbContext db = new UygulamaDbContext(); 
        public ActionResult Index()
        {
            
            return View(db.Kartlar.ToList());
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}