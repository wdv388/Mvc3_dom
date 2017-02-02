using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication_dom_base.Models
{
    public class Hotwater
    {
        public int ID { get; set; }
        [Display(Name = "Текушие показания счетчика 1")]
        public int Current { get; set; }
        [Display(Name = "Текушие показания счетчика 2")]
        public int Current1 { get; set; }
        [Display(Name = "Суммарные значения двух счетчиков")]
        public int CurrentTotal { get; set; }
        [Display(Name = "Предыдущие показания счетчиков")]
        public int Previous { get; set; }
        [Display(Name = "Разница")]
        public int Difference { get; set; }
        [Display(Name = "Стоимость за один куб воды")]
        public decimal Price { get; set; }

        [Display(Name = "Вода пополам льгота")]
        public decimal water_half { get; set; }
        [Display(Name = "Цена 75%")]
        public decimal Price_half { get; set; }
        [Display(Name = "стоимость по льготе")]
        public decimal totaltopay_half { get; set; }
        [Display(Name = "полная стоимость без льготы")]
        public decimal totaltoplayfull_half { get; set; }


        [Display(Name = "Итого")]
        public decimal TotaltoPay { get; set; }
        [Display(Name = "Дата снятия показателей")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    }
}