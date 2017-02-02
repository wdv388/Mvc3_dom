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
    public class ColdWaterController : Controller
    {
        private DBContext05 db = new DBContext05();

        //
        // GET: /ColdWater/

        public ViewResult Index()
        {
            return View(db.coldwater.ToList());
        }

        //
        // GET: /ColdWater/Details/5

        public ViewResult Details(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return View(coldwater);
        }

        //
        // GET: /ColdWater/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ColdWater/Create

        [HttpPost]
        public ActionResult Create(Coldwater coldwater)
        {
            if (ModelState.IsValid)
            {
                db.coldwater.Add(coldwater);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(coldwater);
        }
        
        //
        // GET: /ColdWater/Edit/5
 
        public ActionResult Edit(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return View(coldwater);
        }

        //
        // POST: /ColdWater/Edit/5

        [HttpPost]
        public ActionResult Edit(Coldwater coldwater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coldwater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coldwater);
        }

        //
        // GET: /ColdWater/Delete/5
 
        public ActionResult Delete(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return View(coldwater);
        }

        //
        // POST: /ColdWater/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Coldwater coldwater = db.coldwater.Find(id);
            db.coldwater.Remove(coldwater);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index_Partal() 
        {
            var list = db.coldwater.ToList();
            return PartialView(list);
        }
        public ActionResult Ind()
        {
            return View( db.coldwater.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}