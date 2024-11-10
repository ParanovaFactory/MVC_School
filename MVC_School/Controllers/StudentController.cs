using MVC_School.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_School.Controllers
{
    public class StudentController : Controller
    {
        Db_MVC_SchoolEntities entities = new Db_MVC_SchoolEntities();
        // GET: Student
        public ActionResult Index()
        {
            var student = entities.tblStudents.ToList();
            return View(student);
        }

        [HttpGet]
        public ActionResult StudentAdd()
        {
            List<SelectListItem> values = (from i in entities.tblSocialClubs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.socialClubName,
                                               Value = i.socialClubId.ToString()
                                           }).ToList();
            ViewBag.clb = values;
            return View();
        }

        [HttpPost]
        public ActionResult StudentAdd(tblStudent student)
        {
            var clb = entities.tblSocialClubs.Where(x => x.socialClubId == student.tblSocialClub.socialClubId).FirstOrDefault();
            student.tblSocialClub = clb;
            entities.tblStudents.Add(student);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StudentDelete(int id)
        {
            var value = entities.tblStudents.Find(id);
            entities.tblStudents.Remove(value);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Bring(int id)
        {
            var value = entities.tblStudents.Find(id);

            List<SelectListItem> values = (from i in entities.tblSocialClubs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.socialClubName,
                                               Value = i.socialClubId.ToString()
                                           }).ToList();
            ViewBag.clb = values;

            return View("Bring", value);
        }

        public ActionResult StudentEdit(tblStudent std)
        {
            var clb = entities.tblSocialClubs.Where(x => x.socialClubId == std.tblSocialClub.socialClubId).FirstOrDefault();
            std.tblSocialClub = clb;
            var value = entities.tblStudents.Find(std.stdId);
            value.stdNameSurname = std.stdNameSurname;
            value.stdImage = std.stdImage;
            value.stdGender = std.stdGender;
            value.stdSocialClub = std.tblSocialClub.socialClubId;
            entities.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}