using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
namespace MvcHOME.Controllers
{
    public class ElectricityController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Electricity/

        public ActionResult Index(int? id,int? page)
        {
            var electricityнабор = db.ElectricityНабор.Include(e => e.Hom);
            #region dropdownlist
            ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            var time = db.ElectricityНабор.Select(s => s.Data.Year).Distinct().ToList();
             ViewBag.Time = new SelectList(time);
            #endregion
            #region pagination
            // var products = MyProductDataSource.FindAllProducts(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?
              var pord = db.ElectricityНабор.OrderBy(c => c.ID).Include(c => c.Hom);

              var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
              var onePageOfProducts = pord.ToPagedList(pageNumber, 12); // will only contain 25 products max because of the pageSize

              ViewBag.OnePageOfProducts = onePageOfProducts;
              //
              #endregion
             
             // return View(electricityнабор.ToList());  
           
            //var elect = (from p in db.ElectricityНабор
            //             where p.HomID == id
            //             orderby p.ID descending
            //             select p).ToList();

            return View(onePageOfProducts);
        }

        public ActionResult Write()
        {
            #region write file
              try
              {
                  string writePath = @"C:\Electricity.txt";
                  using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                  {
                      foreach (var item in  db.ElectricityНабор)
                      {
                          sw.WriteLine("EC:{0},ED:{1},EP:{2},tolim:{3},fromlim:{4},overlim:{5},Privileg:{6},SumT:{7},SumF:{8},SumO:{9},SumP:{10},Sum:{11},HomeId:{12},Data:{13},Id:{14}",item.EC,item.ED,item.EP,item.toLim,item.fromLim,item.overLim,item.Privelege,item.SumT,item.SumF,item.SumO,item.SumP,item.Sum,item.Hom.Apartament_naber,item.Data,item.ID);
                      }
                  }
              }
              catch (Exception e)
              {
                  HttpNotFound(e.Message);
                  
              }
              #endregion
            return View();
        }

        public ActionResult IndexSort(int? id, int? Data)
        {
            if (id == null & Data == null)
            {
                //var electricityнабор = db.ElectricityНабор.Include(e => e.Hom);
                //return PartialView(electricityнабор);
                return HttpNotFound();
            }
            else if (id==null || Data==null)
            {
                var elect = (from p in db.ElectricityНабор
                             where p.HomID == id || p.Data.Year == Data
                         orderby p.ID descending
                         select p).ToList();

            return PartialView(elect);
            }
            else
            {
                var elect = (from p in db.ElectricityНабор
                             where p.HomID == id & p.Data.Year == Data
                             orderby p.ID descending
                             select p).ToList();

                return PartialView(elect);     
            }
          
        }
        //
        // GET: /Electricity/Details/5

        public ActionResult Details(int id = 0)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            if (electricity == null)
            {
                return HttpNotFound();
            }
            return View(electricity);
        }

        //
        // GET: /Electricity/Create

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            //id homa
            ViewBag.ID = id;

            ViewBag.benefit = (from b in db.HomItems
                               where b.ID == id
                               select b.Benefit).FirstOrDefault();
            ViewBag.nuber = db.HomItems.Where(n => n.ID == id).Select(n => n.Apartament_naber).FirstOrDefault();
            var ben = db.HomItems.Where(n => n.ID == id).Select(n => n.Benefit).FirstOrDefault();

            ViewBag.lim1 = (from l in db.LimitsНабор
                            where l.HomID == id
                            select l.E_L1).FirstOrDefault();
            ViewBag.lim2 = (from l in db.LimitsНабор
                            where l.HomID == id
                            select l.E_L2).FirstOrDefault();
            ViewBag.lim3 = (from l in db.LimitsНабор
                            where l.HomID == id
                            select l.E_L3).FirstOrDefault();
            ViewBag.TEL1 = db.TarrifНабор.Where(n => n.HomID == id).Select(n => n.E_T).FirstOrDefault();
            ViewBag.TEL2 = db.TarrifНабор.Where(n => n.HomID == id).Select(n => n.E_F).FirstOrDefault();
            ViewBag.TEL3 = db.TarrifНабор.Where(n => n.HomID == id).Select(n => n.E_O).FirstOrDefault();
            ViewBag.benefitPerson = db.Benefit.Where(n => n.HomID == id).Select(n => n.Persons).FirstOrDefault();
           var ep  = db.ElectricityНабор.Where(n => n.HomID == id).OrderByDescending(n => n.ID).Select(n => n.EC).FirstOrDefault();
           var epd = db.ElectricityНабор.Where(n => n.HomID == id).OrderByDescending(n => n.ID).Select(n => n.Data).FirstOrDefault();
           ViewBag.EP = "ПОПЕРЕДНІ ПОКАЗНИКИ = " + ep + " СТАНОМ НА " + epd;
            //  ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            return View();
        }

        //
        // POST: /Electricity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Electricity electricity)
        {
            if (ModelState.IsValid)
            {
                db.ElectricityНабор.Add(electricity);
                db.SaveChanges();
                return RedirectToAction("Index", "Records", new  {id=electricity.HomID });
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", electricity.HomID);
            return View(electricity);
        }

        //
        // GET: /Electricity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            if (electricity == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", electricity.HomID);
            return View(electricity);
        }

        //
        // POST: /Electricity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Electricity electricity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electricity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", electricity.HomID);
            return View(electricity);
        }

        //
        // GET: /Electricity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            if (electricity == null)
            {
                return HttpNotFound();
            }
            return View(electricity);
        }

        //
        // POST: /Electricity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Electricity electricity = db.ElectricityНабор.Find(id);
            db.ElectricityНабор.Remove(electricity);
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