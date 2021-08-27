using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelsTurnin.Models;

namespace ModelsTurnin.Controllers
{
    public class hmsController : Controller
    {
        private ModelsTurninContext db = new ModelsTurninContext();

        // GET: hms
        public ActionResult Index()
        {
            return View(db.hms.ToList());
        }
        [HttpPost]
        public ActionResult Index(string SearchBox)
        {
            List<hm> myProducts = db.hms.ToList<hm>();
            ViewBag.Count = myProducts.FindAll(x => x.title.Contains(SearchBox)).Count();
            return View(myProducts.FindAll(x => x.title.Contains(SearchBox)));
        }

        public ActionResult SearchPage()
        {
            return View();
        }

        // GET: hms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hm hm = db.hms.Find(id);
            if (hm == null)
            {
                return HttpNotFound();
            }
            return View(db.hms.Find(id));
        }

        // GET: hms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,rating,director,releaseYear,budget")] hm hm)
        {
            if (ModelState.IsValid)
            {
                db.hms.Add(hm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hm);
        }

        // GET: hms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hm hm = db.hms.Find(id);
            if (hm == null)
            {
                return HttpNotFound();
            }
            return View(hm);
        }

        // POST: hms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,rating,director,releaseYear,budget")] hm hm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hm);
        }

        

        // GET: hms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hm hm = db.hms.Find(id);
            if (hm == null)
            {
                return HttpNotFound();
            }
            return View(hm);
        }

        // POST: hms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hm hm = db.hms.Find(id);
            db.hms.Remove(hm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
