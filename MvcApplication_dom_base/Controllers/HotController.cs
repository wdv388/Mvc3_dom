using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_dom_base.Models;

namespace MvcApplication_dom_base.Controllers
{ 
    public class HotController : Controller
    {
        private DbContextfull db = new DbContextfull();
        private int pageSize = 12;
        //
        // GET: /Hot/

        public ViewResult Index(int pageNum = 1)
        {
            ViewData["PageNum"] = pageNum;
            ViewData["PageSize"] = pageSize;
            ViewData["ItemsCount"] = db.coldwater.Count();
            var list = (from hot in db.hotwater orderby hot.date select hot).Skip(pageSize * pageNum).Take(pageSize).ToList();

            return View(list);
        }

        //
        // GET: /Hot/Details/5

        public ViewResult Details(int id)
        {
            Hotwater hotwater = db.hotwater.Find(id);
            return View(hotwater);
        }

        //
        // GET: /Hot/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Hot/Create

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
        // GET: /Hot/Edit/5
 
        public ActionResult Edit(int id)
        {
            Hotwater hotwater = db.hotwater.Find(id);
            return View(hotwater);
        }

        //
        // POST: /Hot/Edit/5

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
        // GET: /Hot/Delete/5
 
        public ActionResult Delete(int id)
        {
            Hotwater hotwater = db.hotwater.Find(id);
            return View(hotwater);
        }

        //
        // POST: /Hot/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Hotwater hotwater = db.hotwater.Find(id);
            db.hotwater.Remove(hotwater);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //partalvidew

        public ActionResult Index_partal ()
        {
            var listi = db.hotwater.ToList();
            return PartialView(listi);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}