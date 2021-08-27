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
    public class vgsController : Controller
    {
        private ModelsTurninContext db = new ModelsTurninContext();

        // GET: vgs
        public ActionResult Index()
        {
            return View(db.vgs.ToList());
        }

        // GET: vgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vg vg = db.vgs.Find(id);
            if (vg == null)
            {
                return HttpNotFound();
            }
            return View(vg);
        }

        // GET: vgs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,rating,developer,releaseYear,budget")] vg vg)
        {
            if (ModelState.IsValid)
            {
                db.vgs.Add(vg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vg);
        }

        // GET: vgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vg vg = db.vgs.Find(id);
            if (vg == null)
            {
                return HttpNotFound();
            }
            return View(vg);
        }

        // POST: vgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,rating,developer,releaseYear,budget")] vg vg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vg);
        }

        // GET: vgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vg vg = db.vgs.Find(id);
            if (vg == null)
            {
                return HttpNotFound();
            }
            return View(vg);
        }

        // POST: vgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vg vg = db.vgs.Find(id);
            db.vgs.Remove(vg);
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
