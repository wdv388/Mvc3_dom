using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc3_dom.Models
{
    public class Electricity
    {
        public int ID { get; set; }
        [Display(Name="Текущие показания")]
        public int Current { get; set; }
        [Display(Name="Предыдущие показания")]
        public int Previous { get; set; }
        [Display(Name = "Разница")]
        public int Difference { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Итого")]
        public decimal TotaltoPay { get; set; }
        [Display(Name = "Дата сняти показателей")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }
}