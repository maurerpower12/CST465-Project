using MVC465.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC465;

namespace MVC465.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private IDataEntityRepository<Category> data;

        public CategoryController(IDataEntityRepository<Category> repo)
        {
            data = repo;
        }
        // GET: Inventory
        public ActionResult Index()
        {
            List<Category> t = data.GetList();
            return View(t);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCategory(string CategoryName)
        {
            if (ModelState.IsValid)
            {
                Category n = new Category();
                n.CategoryName = CategoryName;
                data.Save(n);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category Cat)
        {
            if (ModelState.IsValid)
            {
                data.Save(Cat);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public ActionResult DeleteMe(Category Cat)
        {
            data.Remove(Cat.ID);
            return RedirectToAction("Index");

        }
        public CategoryController()
        {
            data = new CategoryDBRepository();
        }
    }
}