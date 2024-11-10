using MVC_School.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_School.Controllers
{
    public class SocialClubController : Controller
    {
        Db_MVC_SchoolEntities entities = new Db_MVC_SchoolEntities();
        // GET: SocialClub
        public ActionResult Index()
        {
            var socialClubs = entities.tblSocialClubs.ToList();
            return View(socialClubs);
        }

        [HttpGet]
        public ActionResult ClubAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClubAdd(tblSocialClub socialClub)
        {
            entities.tblSocialClubs.Add(socialClub);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ClubDelete(int id)
        {
            var value = entities.tblSocialClubs.Find(id);
            entities.tblSocialClubs.Remove(value);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Bring(int id)
        {
            var value = entities.tblSocialClubs.Find(id);
            return View("Bring", value);
        }

        public ActionResult ClubEdit(tblSocialClub socialClub)
        {
            var value = entities.tblSocialClubs.Find(socialClub.socialClubId);
            value.socialClubName = socialClub.socialClubName;
            entities.SaveChanges();
            return RedirectToAction("Index", "SocialClub");
        }
    }
}