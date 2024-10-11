using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class projectDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status_now { get; set; }
        public DateTime created_time { get; set; }
        public int sid { get; set; }
    }
}
