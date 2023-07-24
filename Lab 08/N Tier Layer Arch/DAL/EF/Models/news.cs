using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class news
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        [ForeignKey("Category")]
        public int cid { get; set; }
        public virtual category Category { get; set; }
    }
}