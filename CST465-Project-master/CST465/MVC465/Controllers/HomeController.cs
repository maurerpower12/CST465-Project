using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int numBlogzToDisplay = 3;
            int numInventoryToDisplay = 5;
            DBRepo data = new DBRepo();
            List<BlogPost> blogz;
            

            blogz = data.GetList();

            IEnumerable<BlogPost> dizplay = blogz.OrderBy(m => m.Timestamp).Take(numBlogzToDisplay);

            ViewBag.BlogPreview = dizplay;

            InventoryDBRepository tdata = new InventoryDBRepository();
            List<Inventory> t = tdata.GetList();

            IEnumerable<Inventory> tdizplay = t.OrderBy(m => m.ID).Take(numInventoryToDisplay);

            ViewBag.InventoryPreview = tdizplay;

            return View();
        }


    }
}