using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHOME.Controllers
{
    public class TarrifController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Tarrif/

        public ActionResult Index()
        {
            try
            {
                var tarrifнабор = db.TarrifНабор.Include(t => t.Hom);
                return View(tarrifнабор.ToList());
            }
            catch (Exception )//ex
            {
                return HttpNotFound();
             //   throw new Exception("Exeption to xs",ex);
            }
            
           
        }

        //
        // GET: /Tarrif/Details/5

        public ActionResult Details(int id = 0)
        {
            Tarrif tarrif = db.TarrifНабор.Find(id);
            if (tarrif == null)
            {
                return HttpNotFound();
            }
            return View(tarrif);
        }

        //
        // GET: /Tarrif/Create

        public ActionResult Create()
        {
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            return View();
        }

        //
        // POST: /Tarrif/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarrif tarrif)
        {
            if (ModelState.IsValid)
            {
                db.TarrifНабор.Add(tarrif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber", tarrif.HomID);
            return View(tarrif);
        }

        //
        // GET: /Tarrif/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tarrif tarrif = db.TarrifНабор.Find(id);
            if (tarrif == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber", tarrif.HomID);
            return View(tarrif);
        }

        //
        // POST: /Tarrif/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarrif tarrif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarrif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber", tarrif.HomID);
            return View(tarrif);
        }

        //
        // GET: /Tarrif/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tarrif tarrif = db.TarrifНабор.Find(id);
            if (tarrif == null)
            {
                return HttpNotFound();
            }
            return View(tarrif);
        }

        //
        // POST: /Tarrif/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarrif tarrif = db.TarrifНабор.Find(id);
            db.TarrifНабор.Remove(tarrif);
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