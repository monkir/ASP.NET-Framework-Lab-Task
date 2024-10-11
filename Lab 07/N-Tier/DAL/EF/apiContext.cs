
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.EF
{
    public class apiContext: DbContext
    {
        public DbSet<news> news { get; set; }
        public DbSet<category> categories { get; set; }
    }
}