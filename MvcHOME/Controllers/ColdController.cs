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
    public class ColdController : Controller
    {
        private Model1Container db = new Model1Container();
       

        //
        // GET: /Cold/

        public ViewResult Index(int? id,int? page)
        {
         
                var cold_waterнабор = db.Cold_WaterНабор.Include(c => c.Hom);
          
                var cold = db.Cold_WaterНабор.Select(s => s.HomID);
                #region dropdownlist
                //  ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber");
                ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");


                var time = db.Cold_WaterНабор.Select(s => s.Data.Year).Distinct().ToList();

             
                  ViewBag.Time = new SelectList(time );
                #endregion
                  //
                #region pagination
                // var products = MyProductDataSource.FindAllProducts(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?
                var pord = db.Cold_WaterНабор.OrderBy(c => c.ID).Include(c => c.Hom);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = pord.ToPagedList(pageNumber, 12); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            //
                #endregion
         
            return View(onePageOfProducts); 
          
          
            //
            
          
        }
        public ActionResult Write(bool wrt)
        {
            #region write to file
            if (wrt)
            {
                
          
            string writePath = @"C:\Coldwater.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {

                    // sw.BaseStream.Seek(10, SeekOrigin.End);
                    foreach (var item in db.Cold_WaterНабор )
                    {
                        sw.WriteLine("CW0:{0}, CW1:{1}, CWD:{2}, CWP:{3}, CWT:{4}, Sum:{5}, Data:{6}, HomeID:{7}, ID:{8}", item.CW0, item.CW1, item.CWD, item.CWP, item.CWT, item.Sum, item.Data, item.Hom.Apartament_naber, item.ID);

                    }
                }
            }
            catch (Exception e)
            {
                HttpNotFound(e.Message);

            }
          }
            #endregion
            return View();
        }
        public ActionResult IndexSort(int? id, int? Data )
        {
            if (id==null & Data==null)
            {
              //  var cold_waterнабор = db.Cold_WaterНабор.Include(c => c.Hom);
                //return PartialView(cold_waterнабор);
                return HttpNotFound();
            } 
            else if (id==null || Data==null)
            {
                 var cw = (from p in db.Cold_WaterНабор
                     where p.HomID == id 
                  ||  p.Data.Year== Data
                      orderby p.Data.Year  ascending
                     
                      select p).ToList();
                 return PartialView(cw);
            }
            else
            {
                var cw = (from p in db.Cold_WaterНабор
                          where p.HomID == id
                       & p.Data.Year == Data
                          orderby p.Data.Year ascending

                          select p).ToList();
                return PartialView(cw);
            }
               

         //   ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");

          //  return PartialView(cw);
        }
        //
        // GET: /Cold/Details/5

        public ActionResult Details(int id = 0)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            if (cold_water == null)
            {
                return HttpNotFound();
            }
            return View(cold_water);
        }

        //
        // GET: /Cold/Create

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var apartament = (from p in db.HomItems
                              where p.ID == id
                              select p.Apartament_naber).FirstOrDefault();
            ViewBag.apartament = apartament;
            var tarrif = (from t in db.TarrifНабор
                          where t.HomID == id
                          select t.CW).FirstOrDefault();
            ViewBag.tarrif = tarrif;
            var benefit = (from b in db.HomItems
                           where b.ID == id
                           select b.Benefit).FirstOrDefault();
            if (benefit)
            {
                ViewBag.benefit = (tarrif * 25) / 100;

            }
            else
            {
                ViewBag.benefit = 0;
            }
            var cw = (from p in db.Cold_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.CWT).FirstOrDefault();
            var cwdat = db.Cold_WaterНабор.Where(n => n.HomID == id).OrderByDescending(n => n.ID).Select(n => n.Data).FirstOrDefault();
            ViewBag.CWT ="ПОПЕРЕДНІ ПОКАЗНИКИ_ " + cw + "_ СТАНОМ НА _" + cwdat ;
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            ViewBag.Nuber = id;
            return View();
        }

        //
        // POST: /Cold/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cold_Water cold_water, bool next)
        {
            if (ModelState.IsValid)
            {
                db.Cold_WaterНабор.Add(cold_water);
                db.SaveChanges();
                if (next)
                {
                    return RedirectToAction("Create", "Hot", new {id = cold_water.HomID });
                }
                return RedirectToAction("Index","Records",new {id=cold_water.HomID });
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", cold_water.HomID);
            return View(cold_water);
        }

        //
        // GET: /Cold/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            if (cold_water == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "Apartament_naber", cold_water.HomID);
            return View(cold_water);
        }

        //
        // POST: /Cold/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cold_Water cold_water)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cold_water).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", cold_water.HomID);
            return View(cold_water);
        }

        //
        // GET: /Cold/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            if (cold_water == null)
            {
                return HttpNotFound();
            }
            return View(cold_water);
        }

        //
        // POST: /Cold/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cold_Water cold_water = db.Cold_WaterНабор.Find(id);
            db.Cold_WaterНабор.Remove(cold_water);
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