using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class token
    {
        public int id { get; set; }
        public string token_string { get; set; }
        public string userrole { get; set; }
        public int userid { get; set; }
        public DateTime expireTime { get; set; }
    }
}
