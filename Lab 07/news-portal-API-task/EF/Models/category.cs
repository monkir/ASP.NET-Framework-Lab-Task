using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace news_portal_API_task.EF.Models
{
    public class category
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<news> newsList { get; set; }
        public category()
        {
            newsList = new List<news>();
        }
    }
}