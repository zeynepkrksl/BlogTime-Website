using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    public class ProjeController : Controller

    {
        private BlogContext db = new BlogContext();


        [Authorize]
        public ActionResult Index()
        {
            var projeler = db.Projeler
                .OrderByDescending(i => i.ProjeTarihi);
            return View(projeler.ToList());
        }




        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proje proje = db.Projeler.Find(id);
            if (proje == null)
            {
                return HttpNotFound();
            }
            return View(proje);
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ProjeAd,ProjeOzet,ProjeAciklama,ProjeGorsel")] Proje proje)
        {
            if (ModelState.IsValid)
            {
                proje.ProjeTarihi = DateTime.Now;

                db.Projeler.Add(proje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proje);
        }


        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proje proje = db.Projeler.Find(id);
            if (proje == null)
            {
                return HttpNotFound();
            }
            return View(proje);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,ProjeAd,ProjeOzet,ProjeAciklama,ProjeGorsel")] Proje proje)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Projeler.Find(proje.Id);
                if (entity != null)
                {
                    entity.ProjeAd = proje.ProjeAd;
                    entity.ProjeGorsel = proje.ProjeGorsel;
                    entity.ProjeOzet = proje.ProjeOzet;
                    entity.ProjeAciklama = proje.ProjeAciklama;


                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(proje);
        }

        public ActionResult ProjelerHome()
        {
            var projeler = db.Projeler
                .OrderByDescending(i => i.ProjeTarihi);
                
            return View(projeler.ToList());
        }



        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proje proje = db.Projeler.Find(id);
            if (proje == null)
            {
                return HttpNotFound();
            }
            return View(proje);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Proje proje = db.Projeler.Find(id);
            db.Projeler.Remove(proje);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
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
