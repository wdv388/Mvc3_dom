using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication_dom_base.Models
{
    public class Electric
    {
        public int ID { get; set; }
        [Display(Name = "Текущие показания")]
        public int Current { get; set; }
        [Display(Name = "Предыдущие показания")]
        public int Previous { get; set; }
        [Display(Name = "Разница")]
        public int Difference { get; set; }
         [Display(Name = "75 кВт")]
        public int Difference_half { get; set; }
         [Display(Name = "Разница-75кВт")]
        public int Difference_fullhalf { get; set; }
        [Display(Name = "Цена по льготам 0.7005")]
        public decimal Price_half { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Итого")]
        public decimal TotaltoPay { get; set; }
        [Display(Name = "Дата сняти показателей")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }
}