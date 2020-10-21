using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;

namespace YelCreative.Controllers
{
    [HandleError]
    [Authorize]
    public class ProfileController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();
        User usr = new User();

        // GET: Profile
        public ActionResult Index()
        {
            string currentId = Session["AdminId"].ToString();
            int id = Int32.Parse(currentId);

            usr = db.Users.SingleOrDefault(x=>x.Id_User == id);

            Role role = db.Roles.SingleOrDefault(x => x.Id_Role == usr.Id_Role);

            List<Role> roleList = db.Roles.ToList();
            ViewBag.SelectRole = new SelectList(roleList, "Id_Role", "Role_Name");

            ProfileViewModel prof = new ProfileViewModel();

            prof.Id_User = usr.Id_User;
            prof.Picture = usr.Picture;
            prof.Image_Path = usr.Image_Path;
            prof.Full_Name = usr.Full_Name;
            prof.Email = usr.Email;
            prof.password = usr.password;
            prof.Id_Role = usr.Id_Role;
            prof.Role_Name = role.Role_Name;

            Session["AdminImagePath"] = usr.Image_Path;

            ViewBag.AdminPhoto = usr.Image_Path;
            ViewBag.AdminName = usr.Full_Name;

            return View(prof);
        }

        public ActionResult UpdateProfile(ProfileViewModel model)
        {
            if (model.Id_User > 0)
            {
                User usr = db.Users.SingleOrDefault(x => x.Id_User == model.Id_User);
                usr.Id_User = model.Id_User;
                usr.Full_Name = model.Full_Name;
                usr.Email = model.Email;
                usr.password = model.password;

                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePicture(ProfileViewModel model)
        {
            var file = model.ImageUpload;
            byte[] imagebyte = null;

            if (file != null && model.Id_User > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);

                filename = filename + extension;

                
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);

                User iuser = new User();
                iuser = db.Users.Where(x => x.Id_User == model.Id_User).FirstOrDefault();
                iuser.Image_Byte = imagebyte;
                iuser.Image_Path = "/Images/Profile/" + filename;
                iuser.Picture = filename;

                db.Entry(iuser).State = EntityState.Modified;
                string oldImgPath = Request.MapPath(Session["AdminImagePath"].ToString());

                if (db.SaveChanges() > 0)
                {
                    file.SaveAs(Server.MapPath("/Images/Profile/" + filename));
                    if (System.IO.File.Exists(oldImgPath))
                    {
                        System.IO.File.Delete(oldImgPath);
                    }
                   
                }

            }

            return RedirectToAction("Index");
        }
    }
}