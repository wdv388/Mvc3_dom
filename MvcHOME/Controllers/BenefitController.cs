using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHOME.Controllers
{
    public class BenefitController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Benefit/

        public ActionResult Index()
        {
            var benefit = db.Benefit.Include(b => b.Hom);
            return View(benefit.ToList());
        }

        //
        // GET: /Benefit/Details/5

        public ActionResult Details(int id = 0)
        {
            Benefit benefit = db.Benefit.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        //
        // GET: /Benefit/Create

        public ActionResult Create()
        {
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            return View();
        }

        //
        // POST: /Benefit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Benefit.Add(benefit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", benefit.HomID);
            return View(benefit);
        }

        //
        // GET: /Benefit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Benefit benefit = db.Benefit.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", benefit.HomID);
            return View(benefit);
        }

        //
        // POST: /Benefit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benefit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", benefit.HomID);
            return View(benefit);
        }

        //
        // GET: /Benefit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Benefit benefit = db.Benefit.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        //
        // POST: /Benefit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benefit benefit = db.Benefit.Find(id);
            db.Benefit.Remove(benefit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}