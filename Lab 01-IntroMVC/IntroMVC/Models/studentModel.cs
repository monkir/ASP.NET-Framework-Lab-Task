using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroMVC.Models
{
    public class studentModel
    {
        public string name { get; set; }
        public string dob { get; set; }
        public string nation { get; set; }
        public string bloodGroup { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string[] hobbies { get; set; }
    }
}