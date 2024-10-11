using lab_02_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_02_ASP.NET.Controllers
{
    public class userController : Controller
    {
        // GET: user
        [HttpGet]
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(userModel um)
        {
            /*var t = um.Hobbies.Contains("h1");*/
            return View(um);
        }
    }
}