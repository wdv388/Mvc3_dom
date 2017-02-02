using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mvc3_dom.Models
{
    public class DBContext05 : DbContext
    {
        public DbSet<Electricity> electricity { get; set; }
        public DbSet<Coldwater> coldwater { get; set; }
        public DbSet<Hotwater> hotwater { get; set; }
    }
}