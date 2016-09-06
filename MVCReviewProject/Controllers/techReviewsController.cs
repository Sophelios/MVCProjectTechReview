using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCReviewProject.Models;

namespace MVCReviewProject.Controllers
{
    public class techReviewsController : Controller
    {
        private MVCReviewProjectContext db = new MVCReviewProjectContext();

        // GET: techReviews
        public ActionResult Index()
        {
            var techReviews = db.techReviews.Include(t => t.Category);
            return View(techReviews.ToList());
        }

        // GET: techReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            techReview techReview = db.techReviews.Find(id);
            if (techReview == null)
            {
                return HttpNotFound();
            }
            return View(techReview);
        }

        // GET: techReviews/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: techReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Item,Review,Published,CategoryID")] techReview techReview)
        {
            if (ModelState.IsValid)
            {
                db.techReviews.Add(techReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", techReview.CategoryID);
            return View(techReview);
        }

        // GET: techReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            techReview techReview = db.techReviews.Find(id);
            if (techReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", techReview.CategoryID);
            return View(techReview);
        }

        // POST: techReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Item,Review,Published,CategoryID")] techReview techReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", techReview.CategoryID);
            return View(techReview);
        }

        // GET: techReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            techReview techReview = db.techReviews.Find(id);
            if (techReview == null)
            {
                return HttpNotFound();
            }
            return View(techReview);
        }

        // POST: techReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            techReview techReview = db.techReviews.Find(id);
            db.techReviews.Remove(techReview);
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
