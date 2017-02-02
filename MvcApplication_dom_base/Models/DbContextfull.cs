using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcApplication_dom_base.Models
{
    public class DbContextfull:DbContext
    {
        public DbSet<Coldwater> coldwater { get; set; }
        public DbSet<Hotwater> hotwater { get; set; }
        public DbSet<Electric> electr { get; set; }
    }
}