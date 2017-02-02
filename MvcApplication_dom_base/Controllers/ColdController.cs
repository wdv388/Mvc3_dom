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
    public class ColdController : Controller
    {
        private DbContextfull db = new DbContextfull();
        private int pageSize = 12;

        //
        // GET: /Cold/
        
        public ActionResult Index(int pageNum=1)
        {
            ViewData["PageNum"] = pageNum;
            ViewData["PageSize"] = pageSize;
            ViewData["ItemsCount"] = db.coldwater.Count();
            var list = (from coldwater in db.coldwater orderby coldwater.date  select coldwater).Skip(pageSize*pageNum).Take(pageSize).ToList();
            
            if (!Request.IsAjaxRequest())
            {
                return View(list);
            }
            else
            {
                return PartialView("Index_ajax",list);
            }
        }
       
        //
        // GET: /Cold/Details/5

        public ViewResult Details(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return View(coldwater);
        }

        //
        // GET: /Cold/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Cold/Create

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
        // GET: /Cold/Edit/5
 
        public ActionResult Edit(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return View(coldwater);
        }

        //
        // POST: /Cold/Edit/5

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
        // GET: /Cold/Delete/5
 
        public ActionResult Delete(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return View(coldwater);
        }

        //
        // POST: /Cold/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Coldwater coldwater = db.coldwater.Find(id);
            db.coldwater.Remove(coldwater);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //partailview
        public ActionResult Index_partal()
        {
            var list = db.coldwater.ToList();
            return PartialView(list);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}