using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465.Controllers
{
    public class InventoryController : Controller
    {
 
        private IDataEntityRepository<Inventory> data;

        public InventoryController(IDataEntityRepository<Inventory> repo)
        {
            data = repo;
        }
        // GET: Inventory
        public ActionResult Index()
        {
            List<Inventory> t = data.GetList();
            return View(t);
        }

        public ActionResult Item(int Cat)
        {
            Inventory t = data.Get(Cat);
            return View(t);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveInventory(Inventory inv)
        {
            if (ModelState.IsValid)
            {
                data.Save(inv);
                return RedirectToAction("Image"); // not index
            }
            else
            {
                return View();
            }

        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory Cat)
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
        [Authorize]
        public ActionResult Edit(int index)
        {
            return View(data.Get(index));
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Inventory Cat)
        {
            if (ModelState.IsValid)
            {
                data.Save(Cat);
                //return RedirectToAction("Index");
                return View("Image");

            }
            else
            {
                return View();
            }

        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public ActionResult DeleteMe(int Cat)
        {
            data.Remove(Cat);
            return RedirectToAction("Index");

        }

        public InventoryController()
        {
            data = new InventoryDBRepository();
        }
    }
}