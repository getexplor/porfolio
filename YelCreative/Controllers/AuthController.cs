using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;
using System.Web.Security;

namespace YelCreative.Controllers
{
    [HandleError]
    public class AuthController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Login(UserViewModel model)
        {
            
            User usr = db.Users.SingleOrDefault(x => x.Email == model.Email && x.password == model.password);
            var response = false;

            if (usr != null)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);

                Session["AdminId"] = usr.Id_User;
                Session["AdminName"] = usr.Full_Name;
                Session["AdminPhoto"] = usr.Image_Path;

                Role role = db.Roles.SingleOrDefault(x => x.Id_Role == usr.Id_Role);
                Session["AdminRole"] = role.Role_Name;

                if (usr.Id_Role == 1)
                {
                    response = true;
                }
                else
                {
                    response = false;
                }
            }

            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}