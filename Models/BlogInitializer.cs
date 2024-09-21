using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() { KategoriAdi = "C++"},
                new Category() { KategoriAdi = "ASP.NET MVC"},
                new Category() { KategoriAdi = "ASP.NET WEB FORM"},
                new Category() { KategoriAdi = "Windows Form"}
            };

            foreach (var category in categories)
            {
                context.Kategoriler.Add(category);
            }
            context.SaveChanges();


            List<Blog> blogs = new List<Blog>()
            {
                new Blog() { Baslik = "0001 konusu", Aciklama="0001 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik= "0001 konusu Hakkında acıklama kısmı burası0001 konusu Hakkında acıklama kısmı burası0001 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=1},
                new Blog() { Baslik = "0002 konusu", Aciklama="0002 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=false, Icerik= "0002 konusu Hakkında acıklama kısmı burası0002 konusu Hakkında acıklama kısmı burası0002 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=1},
                new Blog() { Baslik = "0003 konusu", Aciklama="0003 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-30), Anasayfa=false, Onay=true, Icerik= "0003 konusu Hakkında acıklama kısmı burası0003 konusu Hakkında acıklama kısmı burası0003 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=1},
                new Blog() { Baslik = "0004 konusu", Aciklama="0004 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik= "0004 konusu Hakkında acıklama kısmı burası0004 konusu Hakkında acıklama kısmı burası0004 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=2},
                new Blog() { Baslik = "0005 konusu", Aciklama="0005 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-20), Anasayfa=true, Onay=false, Icerik= "0005 konusu Hakkında acıklama kısmı burası0005 konusu Hakkında acıklama kısmı burası0005 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=2},
                new Blog() { Baslik = "0006 konusu", Aciklama="0006 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik= "0006 konusu Hakkında acıklama kısmı burası0006 konusu Hakkında acıklama kısmı burası0006 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=2},
                new Blog() { Baslik = "0007 konusu", Aciklama="0007 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=false, Onay=true, Icerik= "0007 konusu Hakkında acıklama kısmı burası0007 konusu Hakkında acıklama kısmı burası0007 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=3},
                new Blog() { Baslik = "0008 konusu", Aciklama="0008 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-30), Anasayfa=true, Onay=true, Icerik= "0008 konusu Hakkında acıklama kısmı burası0008 konusu Hakkında acıklama kısmı burası0008 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=3},
                new Blog() { Baslik = "0009 konusu", Aciklama="0009 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-20), Anasayfa=true, Onay=true, Icerik= "0009 konusu Hakkında acıklama kısmı burası0009 konusu Hakkında acıklama kısmı burası0009 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=3},
                new Blog() { Baslik = "0010 konusu", Aciklama="0010 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-15), Anasayfa=true, Onay=true, Icerik= "0010 konusu Hakkında acıklama kısmı burası0010 konusu Hakkında acıklama kısmı burası0010 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=4},
                new Blog() { Baslik = "0011 konusu", Aciklama="0011 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=false, Onay=true, Icerik= "0011 konusu Hakkında acıklama kısmı burası0011 konusu Hakkında acıklama kısmı burası0011 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=4},
                new Blog() { Baslik = "0012 konusu", Aciklama="0012 konusu Hakkında acıklama kısmı burası", EklenmeTarihi=DateTime.Now.AddDays(-10), Anasayfa=true, Onay=true, Icerik= "0012 konusu Hakkında acıklama kısmı burası0012 konusu Hakkında acıklama kısmı burası0012 konusu Hakkında acıklama kısmı burası", Resim="travel3.jpg", CategoryId=4},
            }; 

            foreach (var item in blogs)
            {
                context.Bloglar.Add(item);
            }





            base.Seed(context);
        }
    }
}