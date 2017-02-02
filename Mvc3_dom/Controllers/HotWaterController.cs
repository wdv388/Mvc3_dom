using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3_dom.Models;

namespace Mvc3_dom.Controllers
{ 
    public class HotWaterController : Controller
    {
        private DBContext05 db = new DBContext05();

        //
        // GET: /HotWater/

        public ViewResult Index()
        {
            return View(db.hotwater.ToList());
        }

        //
        // GET: /HotWater/Details/5

        public ViewResult Details(int id)
        {
            Hotwater hotwater = db.hotwater.Find(id);
            return View(hotwater);
        }

        //
        // GET: /HotWater/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /HotWater/Create

        [HttpPost]
        public ActionResult Create(Hotwater hotwater)
        {
            if (ModelState.IsValid)
            {
                db.hotwater.Add(hotwater);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(hotwater);
        }
        
        //
        // GET: /HotWater/Edit/5
 
        public ActionResult Edit(int id)
        {
            Hotwater hotwater = db.hotwater.Find(id);
            return View(hotwater);
        }

        //
        // POST: /HotWater/Edit/5

        [HttpPost]
        public ActionResult Edit(Hotwater hotwater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotwater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotwater);
        }

        //
        // GET: /HotWater/Delete/5
 
        public ActionResult Delete(int id)
        {
            Hotwater hotwater = db.hotwater.Find(id);
            return View(hotwater);
        }

        //
        // POST: /HotWater/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Hotwater hotwater = db.hotwater.Find(id);
            db.hotwater.Remove(hotwater);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index_Partal()
        {
            var list = db.hotwater.ToList();
            return PartialView(list);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}