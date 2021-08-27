using ModelsTurnin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelsTurnin.Controllers
{
    public class searchbarController : Controller
    {
        private ModelsTurninContext db = new ModelsTurninContext();
        // GET: searchbar
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string SearchBox)
        {
            List<hm> myProducts = db.hms.ToList<hm>();
            ViewBag.Count = myProducts.FindAll(x => x.title.Contains(SearchBox)).Count();
            return View(myProducts.FindAll(x => x.title.Contains(SearchBox)));
        }

        public ActionResult Details(int? id)
        {

            return View(db.hms.Find(id));
        }
    }
}