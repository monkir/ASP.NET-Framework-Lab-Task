using Lab_3_entitiy_task.DB;
using Lab_3_entitiy_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_3_entitiy_task.Controllers
{
    public class studentController : Controller
    {
        public ActionResult index()
        {
            var db = new entityTaskEntities();
            var students = db.students.ToList();
            return View(convert(students));
        }
        // GET: student
        [HttpGet]
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(studentDTO st)
        {
            if (ModelState.IsValid)
            {
                var db = new entityTaskEntities();
                db.students.Add(convert(st));
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(st);
        }
        studentDTO convert(student st)
        {
            studentDTO u = new studentDTO()
            {
                name = st.name,
                username = st.username,
                gender = st.gender,
                profession = st.profession.Split(' '),
                studentID = st.studentID,
                email = st.email,
                dob = st.dob
            };
            return u;
        }
        student convert(studentDTO st)
        {
            student u = new student()
            {
                name = st.name,
                username = st.username,
                gender = st.gender,
                profession = string.Join(" ", st.profession),
                studentID = st.studentID,
                email = st.email,
                dob = st.dob
            };
            return u;
        }
        List<studentDTO> convert(List<student> st)
        {
            var sts = new List<studentDTO>();
            foreach (student student in st)
            {
                sts.Add(convert(student));
            }
            return sts;
        }
        List<student> convert(List<studentDTO> st)
        {
            var sts = new List<student>();
            foreach (studentDTO student in st)
            {
                sts.Add(convert(student));
            }
            return sts;
        }

    }
}