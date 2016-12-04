using MVC465.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        public ActionResult Index()
        {
            Contact c = new Contact();
            return View(c);
        }
        public ActionResult Success()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(Contact c)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Success");
            else
                return RedirectToAction("Index");
        }
    }
}