using IntroMVC.Models;
using IntroMVC.Views.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Home()
        {
            ViewBag.name = "Monkir Chowdhury";
            ViewBag.email = "monkir@yahoo.com";
            ViewBag.bio = "I am doing BSc in AIUB now";
            return View();
        }
        public ActionResult Profile()
        {
            studentModel s1 = new studentModel();
            s1.name= "Monkir Chowdhury";
            s1.dob= "12-08-1995";
            s1.nation = "Bangladesh";
            s1.bloodGroup = "O+";
            s1.address = "Motijheel";
            s1.contactNo = "016516543";
            s1.hobbies = new string[] { "Playing Cricket", "travelling", "Catcing fish"};
            return View(s1);
        }
        public ActionResult Education()
        {
            educationModel[] ed = new educationModel[3];
            
            ed[0] = new educationModel();
            ed[0].curriculum = "Bsc";
            ed[0].institute = "AIUB";
            ed[0].year = "4th year";

            ed[1] = new educationModel();
            ed[1].curriculum = "HSC";
            ed[1].institute = "RPLSC";
            ed[1].year = "2019";

            ed[2] = new educationModel();
            ed[2].curriculum = "HSC";
            ed[2].institute = "BBHS";
            ed[2].year = "2017";
            return View(ed);
        }
        public ActionResult projects()
        {
            projectModel[] pm = new projectModel[4];

            pm[0] = new projectModel();
            pm[0].serial = 1;
            pm[0].course = "Database";
            pm[0].description = "Vehicle Renting Management System";

            pm[1] = new projectModel();
            pm[1].serial = 2;
            pm[1].course = "OOP2";
            pm[1].description = "Vehicle Renting Management System";

            pm[2] = new projectModel();
            pm[2].serial = 3;
            pm[2].course = "Web Tech";
            pm[2].description = "Vehicle Renting Management System";

            pm[3] = new projectModel();
            pm[3].serial = 4;
            pm[3].course = "ATP-3";
            pm[3].description = "Bus Ticketing System";

            ViewBag.pm= pm;

            return View();
        }
        public ActionResult references()
        {
            referenceModel[] rm = new referenceModel[2];

            rm[0] = new referenceModel();
            rm[0].name = "Tanvir Ahmed";
            rm[0].title = "Associate Faculty";
            rm[0].institute = "AIUB";

            rm[1] = new referenceModel();
            rm[1].name = "Sazzad Hossain";
            rm[1].title = "Associate Faculty";
            rm[1].institute = "AIUB";

            return View(rm);
        }
    }
}