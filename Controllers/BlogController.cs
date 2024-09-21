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
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();


        [Authorize]
        public ActionResult Index()
        {
            var bloglar = db.Bloglar
                .Include(b => b.Category)
                .OrderByDescending(i => i.EklenmeTarihi);
            return View(bloglar.ToList());
        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }


        [Authorize]

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,Icerik,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {

                blog.EklenmeTarihi = DateTime.Now;

                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }


        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity != null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.Icerik = blog.Icerik;
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.CategoryId = blog.CategoryId;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

 
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        
        public ActionResult List(int? id,string q)
        {
            var bloglar = db.Bloglar
                            .Where(i => i.Onay == true)
                            .Select(i => new BlogModel()
                            {
                                Id = i.Id,
                                Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                                Aciklama = i.Aciklama,
                                EklenmeTarihi = i.EklenmeTarihi,
                                Anasayfa = i.Anasayfa,
                                Onay = i.Onay,
                                Resim = i.Resim,
                                CategoryId = i.CategoryId
                            }).AsQueryable();

            if (id != null)
            {
                bloglar = bloglar.Where(i => i.CategoryId == id);
            }
            else if(string.IsNullOrEmpty("q") == false)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
            }
          
            return View(bloglar.ToList());
        }

        // POST: Blog/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
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
