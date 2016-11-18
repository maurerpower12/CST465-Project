//using MVC465.Code.Repositories;
using MVC465.Code.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465.Controllers 
{
    [Authorize]
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> data;

        public BlogController(IDataEntityRepository<BlogPost> repo)
        {
            data = repo;
        }
        [Authorize]
        public ActionResult Index()
        {
            List<BlogPost> blogz;
            blogz = data.GetList();
            return View(blogz);
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            List<BlogPost> blogz;
            blogz = data.GetListByContent(filter);
            return View(blogz);
        }

        public BlogController()
        {
            data = new BlogDBRepository();
        }

        [Authorize]
        public ActionResult Add()
        {
            BlogPostModel addme = new BlogPostModel();
            return View(addme);
        }

        [Authorize]
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
        [Authorize]
        public ActionResult Edit(int id)
        {
            BlogPost editme = data.Get(id);
            BlogPostModel model = new BlogPostModel() { Author = editme.Author, Content=editme.Content, ID=editme.ID, Title=editme.Title };
            
            return View(model);
        }
        [Authorize(Roles ="Admin")]
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