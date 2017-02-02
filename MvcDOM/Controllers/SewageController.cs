using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDOM.Controllers
{
    public class SewageController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Sewage/

        public ActionResult Index()
        {
            var sewageнабор = db.SewageНабор.Include(s => s.Hom);
            return View(sewageнабор.ToList());
        }

        //
        // GET: /Sewage/Details/5

        public ActionResult Details(int id = 0)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            if (sewage == null)
            {
                return HttpNotFound();
            }
            return View(sewage);
        }

        //
        // GET: /Sewage/Create

        public ActionResult Create(int?id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //id homa
            ViewBag.ID = id;
            //namber apartaments
            var nuber = (from n in db.HomItems
                         where n.ID == id
                         select n.Apartament_naber).FirstOrDefault();
            ViewBag.nuber = nuber;
            //tarrif
            var tarrif = (from t in db.TarrifНабор
                          where t.HomID == id
                          select t.S).FirstOrDefault();
            ViewBag.tarrif = tarrif;
            //benefit
            var benefit = (from b in db.HomItems
                           where b.ID == id
                           select b.Benefit).FirstOrDefault();
            if (benefit)
            {
                ViewBag.benefit = (tarrif * 25) / 100;

            }
            else
            {
                ViewBag.benefit = 0;
            }
            //попередні показник
            var sw = (from p in db.SewageНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.ST).FirstOrDefault();
            ViewBag.SWT = sw;


            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            return View();
        }

        //
        // POST: /Sewage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sewage sewage)
        {
            if (ModelState.IsValid)
            {
                db.SewageНабор.Add(sewage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", sewage.HomID);
            return View(sewage);
        }

        //
        // GET: /Sewage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            if (sewage == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", sewage.HomID);
            return View(sewage);
        }

        //
        // POST: /Sewage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sewage sewage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sewage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", sewage.HomID);
            return View(sewage);
        }

        //
        // GET: /Sewage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            if (sewage == null)
            {
                return HttpNotFound();
            }
            return View(sewage);
        }

        //
        // POST: /Sewage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            db.SewageНабор.Remove(sewage);
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