using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDOM.Controllers
{
    public class RecordsController : Controller
    {
        private Model1Container db = new Model1Container();
        //
        // GET: /Records/

        public ActionResult Index(int? id)
        {

       if (id == null)
    {
        return HttpNotFound();
    }
      // var hom = db.HomItems.Find(id);
    //Hom hom = db.HomItems.Find(id);
   
   // hom.Cold_Water = db.Cold_WaterНабор.Where(m => m.HomID == hom.ID);
     //  var h = db.Cold_WaterНабор.Where(p => p.HomID == id);
      // Cold_Water hom = db.Cold_WaterНабор.Where(p => p.HomID == id).OrderByDescending(x => x.ID).Take(1).Single();    
    // var buts = db.Buts.Include(b=>b.Player).Where(b=>b.Player.TeamId==2) ,2 - здесь id нужной нам команды.

       var cw = (from p in db.Cold_WaterНабор
                 where p.HomID == id 
                 orderby p.ID descending
                 select p).ToList().Take(1);
       var apart = (from p in db.HomItems
                    where p.ID == id
                    select p.Apartament_naber).FirstOrDefault();
       ViewBag.apartament = apart;
            ViewBag.Nuber = id;
    return View(cw);
        }
        public ActionResult Hot(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var hw = (from p in db.Hot_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p).ToList().Take(1);
            ViewBag.Nuber = id;
            return View(hw);
        }
        public ActionResult Electro(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var elect = (from p in db.ElectricityНабор
                         where p.HomID == id
                         orderby p.ID descending
                         select p).ToList().Take(1);
            ViewBag.Nuber = id;
            return View(elect);
        
        }
        public ActionResult Sewage(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var sew = (from p in db.SewageНабор
                       where p.HomID == id
                       orderby p.ID descending
                       select p).ToList().Take(1);
            ViewBag.Nuber = id;
            return View(sew);
        }
    }
}
