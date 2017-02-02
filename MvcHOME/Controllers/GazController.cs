using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHOME.Controllers
{
    public class GazController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Gaz/

        public ActionResult Index()
        {
            var gasнабор = db.GasНабор.Include(g => g.Hom);
            return View(gasнабор.ToList());
        }

        //
        // GET: /Gaz/Details/5

        public ActionResult Details(int id = 0)
        {
            Gas gas = db.GasНабор.Find(id);
            if (gas == null)
            {
                return HttpNotFound();
            }
            return View(gas);
        }

        //
        // GET: /Gaz/Create

        public ActionResult Create()
        {
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            return View();
        }

        //
        // POST: /Gaz/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gas gas)
        {
            if (ModelState.IsValid)
            {
                db.GasНабор.Add(gas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", gas.HomID);
            return View(gas);
        }

        //
        // GET: /Gaz/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gas gas = db.GasНабор.Find(id);
            if (gas == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", gas.HomID);
            return View(gas);
        }

        //
        // POST: /Gaz/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gas gas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", gas.HomID);
            return View(gas);
        }

        //
        // GET: /Gaz/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gas gas = db.GasНабор.Find(id);
            if (gas == null)
            {
                return HttpNotFound();
            }
            return View(gas);
        }

        //
        // POST: /Gaz/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gas gas = db.GasНабор.Find(id);
            db.GasНабор.Remove(gas);
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