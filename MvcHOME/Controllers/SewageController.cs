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
    public class SewageController : Controller
    {
        private Model1Container db = new Model1Container();

        //
        // GET: /Sewage/

        public ActionResult Index(int? id,int? page)
        {
            #region dropdownlists
            ViewBag.Hom_ID = new SelectList(db.HomItems, "ID", "Apartament_naber");
            var time = db.SewageНабор.Select(s => s.Data.Year).Distinct().ToList();
            ViewBag.Time = new SelectList(time);
            #endregion
            var sewageнабор = db.SewageНабор.Include(s => s.Hom);
            if (id==null)
            {
              
              #region pagination
              // var products = MyProductDataSource.FindAllProducts(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?
              var pord = db.SewageНабор.OrderBy(c => c.ID).Include(c => c.Hom);

              var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
              var onePageOfProducts = pord.ToPagedList(pageNumber, 12); // will only contain 25 products max because of the pageSize

              ViewBag.OnePageOfProducts = onePageOfProducts;
              //
              #endregion
              #region write file
              try
              {
                  string writePath = @"C:\Sawege.txt";
                  using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                  {
                      foreach (var item in sewageнабор)
                      {
                        sw.WriteLine("S0:{0}, S1:{1}, SD:{2}, SP:{3}, ST:{4}, Sum:{5}, Data:{6}, HomeID:{7}, ID:{8}", item.S0, item.S1, item.SD, item.SP, item.ST, item.Sum, item.Data, item.Hom.Apartament_naber, item.ID);

                      }
                  }
           
              }
              catch (Exception e)
              {
                  HttpNotFound(e.Message);
                 
              }

              #endregion
              return View(sewageнабор.ToList());  
            }
            var sew = (from p in db.SewageНабор
                       where p.HomID == id
                       orderby p.ID descending
                       select p).ToList();
            return View(sew);
        }
        public ActionResult IndexSort(int? id,int? Data) 
        {
            if (id==null & Data==null)
            {
                return HttpNotFound();
                 //var sewageнабор = db.SewageНабор.Include(s => s.Hom);
                 //return PartialView(sewageнабор);
            }
            else if (id==null || Data==null)
            {
                var sew = (from p in db.SewageНабор
                           where p.HomID == id || p.Data.Year == Data
                       orderby p.ID descending
                       select p).ToList();
            return PartialView(sew);
            }
            else
            {
                var sew = (from p in db.SewageНабор
                           where p.HomID == id & p.Data.Year == Data
                           orderby p.ID descending
                           select p).ToList();
                return PartialView(sew);     
            }
            
        }
        //
        // GET: /Sewage/Details/5

        public ActionResult Details(int id = 0)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            if (sewage == null)
            {
                return HttpNotFound();
            }
            return View(sewage);
        }

        //
        // GET: /Sewage/Create

        public ActionResult Create(int? id )
        {
            //id homa
            ViewBag.ID = id;
            //namber apartaments
            var nuber = (from n in db.HomItems
                         where n.ID == id
                         select n.Apartament_naber).FirstOrDefault();
            ViewBag.nuber = nuber;
            //tarrif
            var tarrif = (from t in db.TarrifНабор
                          where t.HomID == id
                          select t.S).FirstOrDefault();
            ViewBag.tarrif = tarrif;
            //benefit
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
            var sw = (from p in db.SewageНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p.ST).FirstOrDefault();
            var swdat= db.SewageНабор.Where(n => n.HomID == id).OrderByDescending(n => n.ID).Select(n => n.Data).FirstOrDefault();
            ViewBag.SWT ="ПОПЕРЕДНІ ПОКАЗНИКИ _" + sw + " _СТАНОМ НА_"+ swdat ;
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID");
            //авто заполнение формы 
            ViewBag.HW1 = db.Hot_WaterНабор.Where(h => h.HomID == id).OrderByDescending(h => h.ID).Select(h => h.HW0).FirstOrDefault();
            ViewBag.HW0 = db.Hot_WaterНабор.Where(h => h.HomID == id).OrderByDescending(h => h.ID).Select(h => h.HW1).FirstOrDefault();
            ViewBag.HWT = db.Hot_WaterНабор.Where(h => h.HomID == id).OrderByDescending(h => h.ID).Select(h => h.HWT).FirstOrDefault();
            ViewBag.HWP = db.Hot_WaterНабор.Where(h => h.HomID == id).OrderByDescending(h => h.ID).Select(h => h.HWP).FirstOrDefault();
            ViewBag.HWD = db.Hot_WaterНабор.Where(h => h.HomID == id).OrderByDescending(h => h.ID).Select(h => h.HWD).FirstOrDefault();
            ViewBag.Su = db.Hot_WaterНабор.Where(h => h.HomID == id).OrderByDescending(h => h.ID).Select(h => h.Sum).FirstOrDefault();

            return View();
        }

        //
        // POST: /Sewage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sewage sewage,bool next)
        {
            if (ModelState.IsValid)
            {
                db.SewageНабор.Add(sewage);
                db.SaveChanges();
                if (next)
                {
                    return RedirectToAction("Create", "Electricity", new { id = sewage.HomID }); 
                }
                return RedirectToAction("Index","Records",new {id=sewage.HomID });
            }

            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", sewage.HomID);
            return View(sewage);
        }

        //
        // GET: /Sewage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            if (sewage == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", sewage.HomID);
            return View(sewage);
        }

        //
        // POST: /Sewage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sewage sewage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sewage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HomID = new SelectList(db.HomItems, "ID", "ID", sewage.HomID);
            return View(sewage);
        }

        //
        // GET: /Sewage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            if (sewage == null)
            {
                return HttpNotFound();
            }
            return View(sewage);
        }

        //
        // POST: /Sewage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sewage sewage = db.SewageНабор.Find(id);
            db.SewageНабор.Remove(sewage);
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