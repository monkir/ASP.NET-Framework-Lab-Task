using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_3_entitiy_task.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class studentDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [RegularExpression("^[A-Za-z .]+$", ErrorMessage ="Name can only contain Alphabets, spaces, dot")]
        [MaxLength(100, ErrorMessage ="Name length can be maximum 100 chraracters")]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"[^\s]*", ErrorMessage ="Username can't have spaces")]
        [MaxLength(15, ErrorMessage ="Username can have 15 characters maximum")]
        public string username { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string[] profession { get; set; }
        [Required]
        [RegularExpression(@"\d{2}-\d{5}-[1-3]$")]
        public string studentID { get; set; }
        [Required]
        [RegularExpression(@"\d{2}-\d{5}-[1-3]@student.aiub.edu$")]
        public string email { get; set; }
        [validateDOB()]
        public System.DateTime dob { get; set; }
    }
}
