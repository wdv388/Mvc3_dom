using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHOME.Controllers
{
    public class LimitController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Limit/

        public ActionResult Index()
        {
            var limitsнабор = db.LimitsНабор.Include(l => l.Hom);
            return View(limitsнабор.ToList());
        }

        //
        // GET: /Limit/Details/5

        public ActionResult Details(int id = 0)
        {
            Limits limits = db.LimitsНабор.Find(id);
            if (limits == null)
            {
                return HttpNotFound();
            }
            return View(limits);
        }

        //
        // GET: /Limit/Create

        public ActionResult Create()
        {
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            return View();
        }

        //
        // POST: /Limit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Limits limits)
        {
            if (ModelState.IsValid)
            {
                db.LimitsНабор.Add(limits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", limits.HomID);
            return View(limits);
        }

        //
        // GET: /Limit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Limits limits = db.LimitsНабор.Find(id);
            if (limits == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", limits.HomID);
            return View(limits);
        }

        //
        // POST: /Limit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Limits limits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(limits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", limits.HomID);
            return View(limits);
        }

        //
        // GET: /Limit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Limits limits = db.LimitsНабор.Find(id);
            if (limits == null)
            {
                return HttpNotFound();
            }
            return View(limits);
        }

        //
        // POST: /Limit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Limits limits = db.LimitsНабор.Find(id);
            db.LimitsНабор.Remove(limits);
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