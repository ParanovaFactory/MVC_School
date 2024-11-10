using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_School.Models.Entity;

namespace MVC_School.Controllers
{
    public class CourseController : Controller
    {
        Db_MVC_SchoolEntities entities = new Db_MVC_SchoolEntities();

        // GET: Course
        public ActionResult Index()
        {
            var courses = entities.tblCourses.ToList();
            return View(courses);
        }

        [HttpGet]
        public ActionResult CourseAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CourseAdd(tblCours cours)
        {
            entities.tblCourses.Add(cours);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CourseDelete(int id)
        {
            var value = entities.tblCourses.Find(id);
            entities.tblCourses.Remove(value);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Bring(int id)
        {
            var value = entities.tblCourses.Find(id);
            return View("Bring", value);
        }

        public ActionResult CourseEdit(tblCours cours)
        {
            var value = entities.tblCourses.Find(cours.courseId);
            value.courseName = cours.courseName;
            entities.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}