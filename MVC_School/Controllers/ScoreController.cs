using MVC_School.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_School.Controllers
{
    public class ScoreController : Controller
    {
        Db_MVC_SchoolEntities entities = new Db_MVC_SchoolEntities();
        // GET: Score
        public ActionResult Index()
        {
            var scores = entities.tblScores.ToList();
            return View(scores);
        }

        [HttpGet]
        public ActionResult ScoreAdd()
        {
            List<SelectListItem> student = (from i in entities.tblStudents.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.stdNameSurname,
                                            Value = i.stdId.ToString()
                                        }).ToList();
            ViewBag.std = student;
            List<SelectListItem> course = (from i in entities.tblCourses.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.courseName,
                                               Value = i.courseId.ToString()
                                           }).ToList();
            ViewBag.crs = course;
            return View();
        }

        [HttpPost]
        public ActionResult ScoreAdd(tblScore score)
        {
            var std = entities.tblStudents.Where(x => x.stdId == score.tblStudent.stdId).FirstOrDefault();
            var crs = entities.tblCourses.Where(x => x.courseId == score.tblCours.courseId).FirstOrDefault();
            score.tblStudent = std;
            score.tblCours = crs;
            entities.tblScores.Add(score);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ScoreDelete(int id)
        {
            var value = entities.tblScores.Find(id);
            entities.tblScores.Remove(value);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Bring(int id)
        {
            var value = entities.tblScores.Find(id);

            List<SelectListItem> student = (from i in entities.tblStudents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.stdNameSurname,
                                               Value = i.stdId.ToString()
                                           }).ToList();
            ViewBag.std = student;
            List<SelectListItem> course = (from i in entities.tblCourses.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.courseName,
                                               Value = i.courseId.ToString()
                                           }).ToList();
            ViewBag.crs = course;

            return View("Bring", value);
        }

        public ActionResult ScoreEdit(tblScore score)
        {
            var std = entities.tblStudents.Where(x => x.stdId == score.tblStudent.stdId).FirstOrDefault();
            var crs = entities.tblCourses.Where(x => x.courseId == score.tblCours.courseId).FirstOrDefault();
            score.tblStudent = std;
            score.tblCours = crs;
            var value = entities.tblScores.Find(score.scoreId);
            value.courseId = score.tblCours.courseId;
            value.stdId = score.tblStudent.stdId;
            value.exam1 = score.exam1;
            value.exam2 = score.exam2;
            value.exam3 = score.exam3;
            value.assignment = score.assignment;
            value.average = score.average;
            value.status = score.status;
            entities.SaveChanges();
            return RedirectToAction("Index", "Score");
        }
    }
}