using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class newsDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public int cid { get; set; }
    }
}
