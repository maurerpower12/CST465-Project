using MVC465.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465.Controllers
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> data;

        public ActionResult Index()
        {
            List<BlogPost> blogz;
            blogz = data.GetList();
            return View(blogz);
        }

        public BlogController()
        {
            data = new BlogDBRepository();
        }

        public ActionResult Add()
        {
            BlogPostModel addme = new BlogPostModel();
            return View(addme);
        }
        [HttpPost]
        public ActionResult Add(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost blg = new BlogPost();
                blg.ID = model.ID;
                blg.Title = model.Title;
                blg.Author = model.Author;
                blg.Content = model.Content;

                data.Save(blg);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            BlogPost editme = data.Get(id);
            BlogPostModel model = new BlogPostModel() { Author = editme.Author, Content=editme.Content, ID=editme.ID, Title=editme.Title };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                BlogPost blg = new BlogPost();
                blg.ID = model.ID;
                blg.Title = model.Title;
                blg.Author = model.Author;
                blg.Content = model.Content;

                data.Save(blg);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
            
        }
        
        public ActionResult ViewBlog(int id)
        {
            return View(data.Get(id));
        }
    }
}