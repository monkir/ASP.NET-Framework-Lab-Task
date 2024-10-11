using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class supervisor
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public virtual List<project> projects { get; set; }
        public supervisor()
        {
            projects = new List<project>();
        }
    }
}
