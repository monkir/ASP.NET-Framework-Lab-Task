using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class enrollment
    {
        public int id { get; set; }
        [ForeignKey("project")]
        public int pid { get; set; }
        [ForeignKey("member")]
        public int mid { get; set; }
        public virtual member member { get; set; }
        public virtual project project { get; set; }
    }
}
