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
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            YelCreativeEntities db = new YelCreativeEntities();
            AboutU abt = db.AboutUs.SingleOrDefault(x => x.Id_About == 1);
            AboutViewModel avm = new AboutViewModel();
            avm.Id_About = abt.Id_About;
            avm.Content_About = abt.Content_About;
            avm.Update_Date = abt.Update_Date;
            avm.Current_Position = abt.Current_Position;
            avm.Birthday = abt.Birthday;
            avm.City = abt.City;
            avm.Age = abt.Age;
            avm.Degree = abt.Degree;

            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Auth");
            }

            int id = Int32.Parse(Session["AdminId"].ToString());

            User usr = db.Users.SingleOrDefault(x => x.Id_User == id);
            ViewBag.AdminPhoto = usr.Image_Path;
            ViewBag.AdminName = usr.Full_Name;

            return View(avm);
        }

        [HttpPost]
        public ActionResult Index(AboutViewModel model)
        {
            YelCreativeEntities db = new YelCreativeEntities();

            if (ModelState.IsValid == true)
            {
                AboutU ab = db.AboutUs.SingleOrDefault(x => x.Id_About == model.Id_About);
                ab.Id_About = model.Id_About;
                ab.Content_About = model.Content_About;
                ab.Update_Date = DateTime.Now;
                db.SaveChanges();
            }
            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateAboutMe(AboutViewModel model)
        {
            YelCreativeEntities db = new YelCreativeEntities();

            AboutU ab = db.AboutUs.SingleOrDefault(x => x.Id_About == model.Id_About);
            ab.Current_Position = model.Current_Position;
            ab.City = model.City;
            ab.Age = model.Age;
            ab.Birthday = model.Birthday;
            ab.Degree = model.Degree;

            db.SaveChanges();

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}