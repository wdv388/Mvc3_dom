using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDOM.Controllers
{
    public class ElectricityController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Electricity/

        public ActionResult Index()
        {
            var electricityнабор = db.ElectricityНабор.Include(e => e.Hom);
            return View(electricityнабор.ToList());
        }

        //
        // GET: /Electricity/Details/5

        public ActionResult Details(int id = 0)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            if (electricity == null)
            {
                return HttpNotFound();
            }
            return View(electricity);
        }

        //
        // GET: /Electricity/Create

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
                          select t.E).FirstOrDefault();
            ViewBag.tarrif = tarrif;
            //tarrif up150/250
            var uptarrif = (from u in db.TarrifНабор
                            where u.HomID == id
                            select u.upEL150_250).FirstOrDefault();
            ViewBag.uptarrif = uptarrif;
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
            //gas or not
            var gas = (from g in db.HomItems
                       where g.ID == id
                       select g.Gas).FirstOrDefault();
            if (gas)
            {
                ViewBag.gas = 150;

            }
            else 
            {
                ViewBag.gas = 250;
            }
            //попередні показник
            var e = (from p in db.ElectricityНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.EC).FirstOrDefault();
            ViewBag.EP = e;


            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            return View();
        }

        //
        // POST: /Electricity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Electricity electricity)
        {
            if (ModelState.IsValid)
            {
                db.ElectricityНабор.Add(electricity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", electricity.HomID);
            return View(electricity);
        }

        //
        // GET: /Electricity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            if (electricity == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", electricity.HomID);
            return View(electricity);
        }

        //
        // POST: /Electricity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Electricity electricity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electricity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", electricity.HomID);
            return View(electricity);
        }

        //
        // GET: /Electricity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            if (electricity == null)
            {
                return HttpNotFound();
            }
            return View(electricity);
        }

        //
        // POST: /Electricity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            db.ElectricityНабор.Remove(electricity);
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