using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class pmsContext: DbContext
    {
        public DbSet<member> member { get; set; }
        public DbSet<supervisor> supervisor { get; set; }
        public DbSet<project> project { get; set; }
        public DbSet<enrollment> enrollment { get; set; }
        public DbSet<token> token { get; set; }
    }
}
