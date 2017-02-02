using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHOME.Helpers
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public PageInfo PageInfo { get; set; }
        public virtual IEnumerable<Cold_Water> Cold_Water { get; set; }
        public virtual IEnumerable<Hot_Water> Hot_Water { get; set; }
        public virtual IEnumerable<Electricity> Electricity { get; set; }
        public virtual IEnumerable<Tarrif> Tarrif { get; set; }
        public virtual IEnumerable<Sewage> Sewage { get; set; }
        public virtual IEnumerable<Benefit> Benefit1 { get; set; }
        public virtual IEnumerable<Gas> Gas1 { get; set; }
        public virtual IEnumerable<Limits> Limits { get; set; }

    }
}