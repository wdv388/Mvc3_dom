using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_dom_base.Models;

namespace MvcApplication_dom_base.Controllers
{
    public class ColdwController : Controller
    {
        private DbContextfull db = new DbContextfull();

        //
        // GET: /Coldw/

        public ViewResult Index(int start = 0, int itemsPerPage = 12, string orderBy = "ID", bool desc = false)
        {
            ViewBag.Count = db.coldwater.Count();
            ViewBag.Start = start;
            ViewBag.ItemsPerPage = itemsPerPage;
            ViewBag.OrderBy = orderBy;
            ViewBag.Desc = desc;

            return View();
        }

        //
        // GET: /Coldw/GridData/?start=0&itemsPerPage=20&orderBy=ID&desc=true

        public ActionResult GridData(int start = 0, int itemsPerPage = 20, string orderBy = "ID", bool desc = false)
        {
            Response.AppendHeader("X-Total-Row-Count", db.coldwater.Count().ToString());
            ObjectQuery<Coldwater> coldwater = (db as IObjectContextAdapter).ObjectContext.CreateObjectSet<Coldwater>();
            coldwater = coldwater.OrderBy("it." + orderBy + (desc ? " desc" : ""));

            return PartialView(coldwater.Skip(start).Take(itemsPerPage));
        }

        //
        // GET: /Default5/RowData/5

        public ActionResult RowData(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return PartialView("GridData", new Coldwater[] { coldwater });
        }

        //
        // GET: /Coldw/Create

        public ActionResult Create()
        {
            return PartialView("Edit");
        }

        //
        // POST: /Coldw/Create

        [HttpPost]
        public ActionResult Create(Coldwater coldwater)
        {
            if (ModelState.IsValid)
            {
                db.coldwater.Add(coldwater);
                db.SaveChanges();
                return PartialView("GridData", new Coldwater[] { coldwater });
            }

            return PartialView("Edit", coldwater);
        }

        //
        // GET: /Coldw/Edit/5

        public ActionResult Edit(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            return PartialView(coldwater);
        }

        //
        // POST: /Coldw/Edit/5

        [HttpPost]
        public ActionResult Edit(Coldwater coldwater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coldwater).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("GridData", new Coldwater[] { coldwater });
            }

            return PartialView(coldwater);
        }

        //
        // POST: /Coldw/Delete/5

        [HttpPost]
        public void Delete(int id)
        {
            Coldwater coldwater = db.coldwater.Find(id);
            db.coldwater.Remove(coldwater);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
