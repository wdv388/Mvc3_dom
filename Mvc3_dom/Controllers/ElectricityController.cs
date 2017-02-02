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
    public class ElectricityController : Controller
    {
        private DBContext05 db = new DBContext05();

        //
        // GET: /Electricity/

        public ViewResult Index()
        {
            return View(db.electricity.ToList());
        }

        //
        // GET: /Electricity/Details/5

        public ViewResult Details(int id)
        {
            Electricity electricity = db.electricity.Find(id);
            return View(electricity);
        }

        //
        // GET: /Electricity/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Electricity/Create

        [HttpPost]
        public ActionResult Create(Electricity electricity)
        {
            if (ModelState.IsValid)
            {
                db.electricity.Add(electricity);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(electricity);
        }
        
        //
        // GET: /Electricity/Edit/5
 
        public ActionResult Edit(int id)
        {
            Electricity electricity = db.electricity.Find(id);
            return View(electricity);
        }

        //
        // POST: /Electricity/Edit/5

        [HttpPost]
        public ActionResult Edit(Electricity electricity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electricity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(electricity);
        }

        //
        // GET: /Electricity/Delete/5
 
        public ActionResult Delete(int id)
        {
            Electricity electricity = db.electricity.Find(id);
            return View(electricity);
        }

        //
        // POST: /Electricity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Electricity electricity = db.electricity.Find(id);
            db.electricity.Remove(electricity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index_Partal()
        {
            var list = db.electricity.ToList();
            return PartialView(list);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}