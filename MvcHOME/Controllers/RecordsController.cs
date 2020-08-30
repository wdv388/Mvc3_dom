using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace MvcHOME.Controllers
{
    public class RecordsController : Controller
    {
        //
        private Model1Container db = new Model1Container();
        // GET: /Records/

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                
                //return HttpNotFound();
            }
            #region tarif
            ViewBag.tar = db.TarrifНабор.Where(t => t.HomID == id).Select(t => t.CW).FirstOrDefault();
          ViewBag.tarH = db.TarrifНабор.Where(t => t.HomID == id).Select(t => t.HW).FirstOrDefault();
          ViewBag.tarS = db.TarrifНабор.Where(t => t.HomID == id).Select(t => t.S).FirstOrDefault();
          ViewBag.tarE = db.TarrifНабор.Where(t => t.HomID == id).Select(t => t.E_T).FirstOrDefault();
          ViewBag.tarEE = db.TarrifНабор.Where(t => t.HomID == id).Select(t => t.E_F).FirstOrDefault();
          ViewBag.tarEEE = db.TarrifНабор.Where(t => t.HomID == id).Select(t => t.E_O).FirstOrDefault();
            #endregion
          
            var cw = (from p in db.Cold_WaterНабор
                      where p.HomID == id
                      orderby p.ID descending
                      select p).ToList().Take(1);
            var apart = (from p in db.HomItems
                         where p.ID == id
                         select p.Apartament_naber).FirstOrDefault();
            #region time Less
            var time = db.Cold_WaterНабор.Where(t => t.HomID == id).OrderByDescending(o => o.ID).Select(t => t.Data).FirstOrDefault();
            
            TimeSpan timedeferens = DateTime.Now - time;
           
            if (timedeferens.TotalDays > 20)
            {
               // ViewBag.timeer = timedeferens.TotalDays;
                ViewBag.timeer = true;

            }
            #endregion
           
            ViewBag.apartament = apart;
            ViewBag.Nuber = id;
            #region sum
            try
            {

                var scw = (from p in db.Cold_WaterНабор
                           where p.HomID == id
                           orderby p.ID ascending
                           select p.Sum).ToList().Last();
                var shw = (from p in db.Hot_WaterНабор
                           where p.HomID == id
                           orderby p.ID ascending
                           select p.Sum).ToList().Last();
                var ss = (from p in db.SewageНабор
                          where p.HomID == id
                          orderby p.ID ascending
                          select p.Sum).ToList().Last();
                var se = (from p in db.ElectricityНабор
                          where p.HomID == id
                          orderby p.ID
                          select p.Sum).ToList().Last();
                ViewBag.sumall = scw + shw + ss + se;
            }
            catch (Exception )
            {
                ViewBag.sumall = "Error!";
                // return RedirectToAction("Index","Home");
                // throw new Exception();
            }
           
           
            #endregion
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
            #region time Less
            var time = db.Hot_WaterНабор.Where(t => t.HomID == id).OrderByDescending(o => o.ID).Select(t => t.Data).FirstOrDefault();

            TimeSpan timedeferens = DateTime.Now - time;

            if (timedeferens.TotalDays > 20)
            {
                // ViewBag.timeer = timedeferens.TotalDays;
                ViewBag.timeerH = true;

            }
            #endregion


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
            #region time Less
            var time = db.ElectricityНабор.Where(t => t.HomID == id).OrderByDescending(o => o.ID).Select(t => t.Data).FirstOrDefault();

            TimeSpan timedeferens = DateTime.Now - time;

            if (timedeferens.TotalDays > 20)
            {
                // ViewBag.timeer = timedeferens.TotalDays;
                ViewBag.timeerE = true;

            }
            #endregion
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
            #region time Less
            var time = db.SewageНабор.Where(t => t.HomID == id).OrderByDescending(o => o.ID).Select(t => t.Data).FirstOrDefault();

            TimeSpan timedeferens = DateTime.Now - time;

            if (timedeferens.TotalDays > 20)
            {
                // ViewBag.timeer = timedeferens.TotalDays;
                ViewBag.timeerS = true;

            }
            #endregion
            return View(sew);
        }
        #region total summerri to water and electricity
        public ActionResult Totalsummer()
        {
            var summer = from c in db.Cold_WaterНабор
                         join h in db.Hot_WaterНабор on c.Sum equals h.Sum
                         join s in db.SewageНабор on h.Sum equals s.Sum
                         join e in db.ElectricityНабор on s.Sum equals e.Sum
                         select c;
                        
                         
            return View(summer);
        }
        #endregion

        #region sending mail
        public ActionResult Sendmail()
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Credentials = new System.Net.NetworkCredential("mkxs81@gmail.com", "");
            smtpServer.Port = 587; // Gmail works on this port

            mail.From = new MailAddress("mkxs81@gmail.com");
            mail.To.Add("wdv388@yahoo.com");
            mail.Subject = "Password recovery";
            mail.Body = "Recovering the password";

            smtpServer.Send(mail);

            return View();
        }
        #endregion
    }
}
