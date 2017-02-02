using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHOME.Controllers
{
    public class HomeController : Controller
    {
        private Model1Container db = new Model1Container();

        //GET Ajax Index View
        public ActionResult IndexAj()
        {
            return View();
        }
        //Get All Items
        public ActionResult ShowTrend()
        {
            var homlist = db.HomItems.ToList();
            var time = db.Cold_WaterНабор.Select(s => s.Data.Year).Distinct().ToList();
            ViewBag.Time = new SelectList(time);
            return View(homlist);
        }
        //Get Alternative Index View
        public ActionResult Start()
        {
            var list = db.HomItems.ToList();
            return View(list);
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try
            {
              return View(db.HomItems.ToList());
            }
            catch (Exception )
            {
                return RedirectToAction("IndexAj");
                // return HttpNotFound(e.Message);
              //  throw;
            }
            
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Hom hom = db.HomItems.Find(id);
            if (hom == null)
            {
                return HttpNotFound();
            }
            return View(hom);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hom hom)
        {
            if (ModelState.IsValid)
            {
                db.HomItems.Add(hom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hom);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hom hom = db.HomItems.Find(id);
            if (hom == null)
            {
                return HttpNotFound();
            }
            return View(hom);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hom hom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hom);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hom hom = db.HomItems.Find(id);
            if (hom == null)
            {
                return HttpNotFound();
            }
            return View(hom);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hom hom = db.HomItems.Find(id);
            db.HomItems.Remove(hom);
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