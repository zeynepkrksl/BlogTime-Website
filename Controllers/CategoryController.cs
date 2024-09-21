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
    public class CategoryController : Controller
    {
        private BlogContext db = new BlogContext();
        
        public PartialViewResult KategoriListesi()
        {
            return PartialView(db.Kategoriler.ToList());
        }



        [Authorize]
        public ActionResult Index()
        {
            var yeni_kategoriler = db.Kategoriler
                .Select(i =>
                    new CategoryModel()
                    {
                        Id= i.Id,
                        KategoriAdi=i.KategoriAdi,
                        BlogSayisi=i.Bloglar.Count()
                    }
                ); 


            return View(yeni_kategoriler.ToList());
        }


        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Kategoriler.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "KategoriAdi")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }


        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Kategoriler.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,KategoriAdi")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Kategori"] = category;
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Kategoriler.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
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
