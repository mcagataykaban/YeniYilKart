﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniYilKart.Models;

namespace YeniYilKart.Controllers
{
    public class KartlarController : Controller
    {
        // GET: Kartlar
        UygulamaDbContext db = new UygulamaDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Yeni(string ResimAd)
        {
            ViewBag.ResimAd = ResimAd;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Yeni(Kart kart)
        {
            if (ModelState.IsValid)
            {
                db.Kartlar.Add(kart);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        public ActionResult Duzenle(int? id)
        {
            
            var kart = db.Kartlar.FirstOrDefault(x => x.Id == id);
            if (kart == null)
            {
                return HttpNotFound();
            }
            return View(kart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kart kart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(kart);
        }
        public ActionResult Sil(int id)
        {
            var kart = db.Kartlar.FirstOrDefault(x => x.Id == id);
            db.Kartlar.Remove(kart);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Indir(int id)
        {
            var kart = db.Kartlar.FirstOrDefault(x => x.Id == id);
            string deneme = kart.Mesaj;
            string mesaj1 = deneme.Substring(0, deneme.Length / 2);
            string mesaj2 = deneme.Substring((deneme.Length / 2) + 1);


            Bitmap bmp = new Bitmap(Server.MapPath($"~/images/{kart.ResimAd}.png"));
            Bitmap bmp2 = ResizeBitmap(bmp, 420, 330);
            Bitmap bmp3 = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(bmp3);
            g.FillRectangle(Brushes.LightGray, 0, 0, bmp3.Width, bmp3.Height);
            g.DrawImage(bmp2, new PointF(300, 500));
            g.DrawString($"Sevgili {kart.AliciAd},", new Font("Arial", 22, FontStyle.Bold), new SolidBrush(Color.DarkRed), new PointF(100, 100));

            g.DrawString($"{mesaj1}", new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(30, 200));
            g.DrawString($"{mesaj2}", new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(30, 250));



            g.DrawString($"{kart.GonderenAd}", new Font("Arial", 22, FontStyle.Bold), new SolidBrush(Color.DarkRed), new PointF(600, 470));
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {

                bmp3.Save(ms, ImageFormat.Jpeg);
                data = ms.ToArray();
            }
            string fileName = "resim.jpeg";
            return File(data, "image/jpeg", fileName);


        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        public ActionResult Goruntule(int id)
        {
            var kart = db.Kartlar.FirstOrDefault(x => x.Id == id);
            if (kart == null)
            {
                return HttpNotFound();
            }
            return PartialView("_KartDiv", kart);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}