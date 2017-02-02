using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDOM.Controllers
{
    public class HotController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Hot/

        public ActionResult Index()
        {
            var hot_waterнабор = db.Hot_WaterНабор.Include(h => h.Hom);
            return View(hot_waterнабор.ToList());
        }

        //
        // GET: /Hot/Details/5

        public ActionResult Details(int id = 0)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            if (hot_water == null)
            {
                return HttpNotFound();
            }
            return View(hot_water);
        }

        //
        // GET: /Hot/Create

        public ActionResult Create(int? id)
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
                          select t.HW).FirstOrDefault();
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
            var hw = (from p in db.Hot_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.HWT).FirstOrDefault();
            ViewBag.HWT = hw;
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            return View();
        }

        //
        // POST: /Hot/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hot_Water hot_water)
        {
            if (ModelState.IsValid)
            {
                db.Hot_WaterНабор.Add(hot_water);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", hot_water.HomID);
            return View(hot_water);
        }

        //
        // GET: /Hot/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            if (hot_water == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", hot_water.HomID);
            return View(hot_water);
        }

        //
        // POST: /Hot/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hot_Water hot_water)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hot_water).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", hot_water.HomID);
            return View(hot_water);
        }

        //
        // GET: /Hot/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            if (hot_water == null)
            {
                return HttpNotFound();
            }
            return View(hot_water);
        }

        //
        // POST: /Hot/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            db.Hot_WaterНабор.Remove(hot_water);
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