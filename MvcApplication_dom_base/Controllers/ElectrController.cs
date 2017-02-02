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
    public class ElectrController : Controller
    {
        private DbContextfull db = new DbContextfull();
        private int pageSize = 12;
        //
        // GET: /Electr/

        public ViewResult Index(int pageNum=1)
        {
            ViewData["PageNum"] = pageNum;
            ViewData["PageSize"] = pageSize;
            ViewData["ItemsCount"] = db.coldwater.Count();
            var list = (from electr in db.electr orderby electr.date select electr).Skip(pageSize * pageNum).Take(pageSize).ToList();
            return View(list);
        }

        //
        // GET: /Electr/Details/5

        public ViewResult Details(int id)
        {
            Electric electric = db.electr.Find(id);
            return View(electric);
        }

        //
        // GET: /Electr/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Electr/Create

        [HttpPost]
        public ActionResult Create(Electric electric)
        {
            if (ModelState.IsValid)
            {
                db.electr.Add(electric);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(electric);
        }
        
        //
        // GET: /Electr/Edit/5
 
        public ActionResult Edit(int id)
        {
            Electric electric = db.electr.Find(id);
            return View(electric);
        }

        //
        // POST: /Electr/Edit/5

        [HttpPost]
        public ActionResult Edit(Electric electric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electric);
        }

        //
        // GET: /Electr/Delete/5
 
        public ActionResult Delete(int id)
        {
            Electric electric = db.electr.Find(id);
            return View(electric);
        }

        //
        // POST: /Electr/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Electric electric = db.electr.Find(id);
            db.electr.Remove(electric);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //partalview
        public ActionResult Index_partal()
        {
            var list = db.electr.ToList();
            return PartialView(list);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}