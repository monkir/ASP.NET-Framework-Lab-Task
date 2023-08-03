using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class project
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status_now { get; set; }
        public DateTime created_time { get; set; }
        [ForeignKey("supervisor")]
        public int sid { get; set; }
        public virtual supervisor supervisor { get; set; }
        public virtual List<enrollment> enrollments { get; set; }
        public project()
        {
            enrollments = new List<enrollment>();
        }
    }
}
