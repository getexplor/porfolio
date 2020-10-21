using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;

namespace YelCreative.Controllers
{
    [HandleError]
    [Authorize]
    public class SkillController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();
        Skill skill = new Skill();
        // GET: Skill
        public ActionResult Index()
        {
           
            List<Skill> skillList = db.Skills.ToList();
            ViewBag.SkillList = skillList;

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Auth");
            }

            int id = Int32.Parse(Session["AdminId"].ToString());

            User usr = db.Users.SingleOrDefault(x => x.Id_User == id);
            ViewBag.AdminPhoto = usr.Image_Path;
            ViewBag.AdminName = usr.Full_Name;

            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(SkillViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                skill.Skill_Name = model.Skill_Name;
                skill.Skill_Value = model.Skill_Value;

                db.Skills.Add(skill);
                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditSkill(SkillViewModel model)
        {
            if (model.Id_Skill > 0)
            {
                skill = db.Skills.SingleOrDefault(x => x.Id_Skill == model.Id_Skill);

                skill.Id_Skill = model.Id_Skill;
                skill.Skill_Name = model.Skill_Name;
                skill.Skill_Value = model.Skill_Value;

                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteSkill(int Id_Skill)
        {
            skill = db.Skills.Find(Id_Skill);
            db.Skills.Remove(skill);
            db.SaveChanges();

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}