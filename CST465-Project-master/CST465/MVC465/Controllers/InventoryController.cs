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
    public class InventoryController : Controller
    {
        private IDataEntityRepository<Category> data;

        public InventoryController(IDataEntityRepository<Category> repo)
        {
            data = repo;
        }
        // GET: Inventory
        public ActionResult Categories()
        {
            List<Category> t = data.GetList();
            return View(t);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Category(string CategoryName)
        {
            Category n = new Category();
            n.CategoryName = CategoryName;
            data.Save(n);
            return RedirectToAction("Categories");

        }
        public ActionResult Edit(string CategoryName)
        {

            return RedirectToAction("Categories");

        }
        public InventoryController()
        {
            data = new InventoryDBRepository();
        }
    }
}