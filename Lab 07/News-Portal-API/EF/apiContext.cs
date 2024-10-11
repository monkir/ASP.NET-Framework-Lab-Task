
using news_portal_API_task.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace news_portal_API_task.EF
{
    public class apiContext: DbContext
    {
        public DbSet<news> news { get; set; }
        public DbSet<category> categories { get; set; }
    }
}