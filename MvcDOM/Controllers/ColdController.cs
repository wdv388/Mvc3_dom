using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDOM.Controllers
{
    public class ColdController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Cold/

        public ActionResult Index(int? id)
        {
           
            var cold_waterнабор = db.Cold_WaterНабор.Include(c => c.Hom);
            //var lst = (from l in db.Cold_WaterНабор
            //           where l.HomID == id
            //           select l).ToList();
            ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            return View(cold_waterнабор.ToList());
        }
        //search filter
        public ActionResult ShowFilter(int?id)
        {
            var lst = (from l in db.Cold_WaterНабор
                       where l.HomID == id
                       select l).ToList();
            ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            return View(lst);
        }
        //
        // GET: /Cold/Details/5

        public ActionResult Details(int id = 0)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            if (cold_water == null)
            {
                return HttpNotFound();
            }
            return View(cold_water);
        }

        //
        // GET: /Cold/Create

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            
            ViewBag.Nuber = id;

            var water = (from p in db.HomItems
                         where p.ID == id
                         select p.Apartament_naber).FirstOrDefault();
            ViewBag.apartament = water;

            var tarrif = (from t in db.TarrifНабор
                          where t.HomID == id
                          select t.CW).FirstOrDefault();
            ViewBag.tarrif = tarrif;
            var benefit = (from b in db.HomItems
                           where b.ID == id
                           select b.Benefit).FirstOrDefault();
            if (benefit)
            {
                ViewBag.benefit = (tarrif * 25) / 100;

            }
            else { 
             ViewBag.benefit = 0;  
                    }
            var cw = (from p in db.Cold_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.CWT).FirstOrDefault();
            ViewBag.CWT = cw;
            return View();
        }

        //
        // POST: /Cold/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cold_Water cold_water)
        {
            if (ModelState.IsValid)
            {
                db.Cold_WaterНабор.Add(cold_water);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           ViewBag.HomID = new SelectList(db.HomItems, "HomeID", "Apartament_naber", cold_water.HomID);
            return View(cold_water);
        }

        //
        // GET: /Cold/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            if (cold_water == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", cold_water.HomID);
            return View(cold_water);
        }

        //
        // POST: /Cold/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cold_Water cold_water)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cold_water).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", cold_water.HomID);
            return View(cold_water);
        }

        //
        // GET: /Cold/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            if (cold_water == null)
            {
                return HttpNotFound();
            }
            return View(cold_water);
        }

        //
        // POST: /Cold/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            db.Cold_WaterНабор.Remove(cold_water);
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