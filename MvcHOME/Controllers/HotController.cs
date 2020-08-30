using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using Newtonsoft.Json;
namespace MvcHOME.Controllers
{
    public class HotController : Controller
    {
        private Model1Container db = new Model1Container();
      
        //
        // GET: /Hot/

        public ActionResult Index(int? id,int? page)
        {
            var hot_waterнабор = db.Hot_WaterНабор.Include(h => h.Hom);
            #region dropdownlist
            ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            var time = db.Hot_WaterНабор.Select(s => s.Data.Year).Distinct().ToList();
            ViewBag.Time = new SelectList(time);
            #endregion

            if (id==null)
            {
            
             #region pagination
             // var products = MyProductDataSource.FindAllProducts(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?
             var pord = db.Hot_WaterНабор.OrderBy(c => c.ID).Include(c => c.Hom);

             var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
             var onePageOfProducts = pord.ToPagedList(pageNumber, 12); // will only contain 25 products max because of the pageSize

             ViewBag.OnePageOfProducts = onePageOfProducts;
             //
             #endregion
             #region write file
           
            try
            { 
                string writePath = @"C:\HotWater.txt";

                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var item in hot_waterнабор)
                    {
                        sw.WriteLine("HW0:{0}, HW1:{1}, HWD:{2}, HWP:{3}, HWT:{4}, Sum:{5}, Data:{6}, HomeID:{7}, ID:{8}", item.HW0, item.HW1, item.HWD, item.HWP, item.HWT, item.Sum, item.Data, item.Hom.Apartament_naber, item.ID);

                    }
                }


            }
            catch (Exception e)
            {
                HttpNotFound(e.Message);
                
            }
            #endregion
            return View(hot_waterнабор.ToList());
            }
            var hw = (from p in db.Hot_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p).ToList();
            
            return View(hw);
        }
        public ActionResult IndexSort(int? id,int ? Data)
        {
            if (id==null & Data==null)
            {
                return HttpNotFound();
                //var hot_waterнабор = db.Hot_WaterНабор.Include(h => h.Hom);
                //return PartialView(hot_waterнабор);
            }
            else if (id==null || Data==null)
            {
                 var hw = (from p in db.Hot_WaterНабор
                           where p.HomID == id || p.Data.Year == Data
                      orderby p.ID descending
                      select p).ToList();

            
            return PartialView(hw);
            }
            else
            {
                var hw = (from p in db.Hot_WaterНабор
                          where p.HomID == id & p.Data.Year == Data
                          orderby p.ID descending
                          select p).ToList();


                return PartialView(hw);  
            }
           
        }
        //
        // GET: /Hot/Details/5

        public ActionResult Details(int id = 0)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            if (hot_water == null)
            {
                return HttpNotFound();
            }
            return View(hot_water);
        }

        //
        // GET: /Hot/Create

        public ActionResult Create(int? id)
        {
            //id homa
            ViewBag.ID = id;
            ViewBag.nuber = db.HomItems.Where(n => n.ID == id).Select(n => n.Apartament_naber).FirstOrDefault();
            var tarrif = db.TarrifНабор.Where(n => n.HomID == id).Select(n => n.HW).FirstOrDefault();
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
            //попередні показник
            var hw = (from p in db.Hot_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.HWT).FirstOrDefault();
            var hwdat = db.Hot_WaterНабор.Where(n => n.HomID == id).OrderByDescending(n => n.ID).Select(n => n.Data).FirstOrDefault();

            ViewBag.HWT ="ПОПЕРЕДНІ ПОКАЗНИКИ _" + hw + " _СТАНОМ НА_"+ hwdat;

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            return View();
        }

        //
        // POST: /Hot/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hot_Water hot_water,bool next)
        {
            if (ModelState.IsValid)
            {
                db.Hot_WaterНабор.Add(hot_water);
                db.SaveChanges();
                if (next)
                {
                    return RedirectToAction("Create", "Sewage", new {id= hot_water.HomID });
                }
                return RedirectToAction("Index","Records",new {id=hot_water.HomID });
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", hot_water.HomID);
            return View(hot_water);
        }

        //
        // GET: /Hot/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            if (hot_water == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", hot_water.HomID);
            return View(hot_water);
        }

        //
        // POST: /Hot/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hot_Water hot_water)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hot_water).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", hot_water.HomID);
            return View(hot_water);
        }

        //
        // GET: /Hot/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            if (hot_water == null)
            {
                return HttpNotFound();
            }
            return View(hot_water);
        }

        //
        // POST: /Hot/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hot_Water hot_water = db.Hot_WaterНабор.Find(id);
            db.Hot_WaterНабор.Remove(hot_water);
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