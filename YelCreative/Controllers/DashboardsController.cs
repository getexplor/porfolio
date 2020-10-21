using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;

namespace YelCreative.Controllers
{
    [HandleError]
    public class DashboardsController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();

        // GET: Dashboards
        [Authorize]
        public ActionResult Index()
        {
            List<Portofolio> PortoList = db.Portofolios.ToList();
            ViewBag.PortoList = PortoList;

            List<Role> RoleList = db.Roles.ToList();
            ViewBag.RoleList = RoleList;

            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = CategoryList;

            if (Session["AdminID"] == null)
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
        public ActionResult AddRole(DashboardsViewModel model)
        {
            Role role = new Role();
            role.Role_Name = model.Role_Name;

            db.Roles.Add(role);
            db.SaveChanges();

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditRole(DashboardsViewModel model)
        {
            if (model.Id_Role > 0)
            {
                Role role = db.Roles.SingleOrDefault(x => x.Id_Role == model.Id_Role);
                role.Id_Role = model.Id_Role;
                role.Role_Name = model.Role_Name;
                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteRole(int Id_Role)
        {
            if (Id_Role > 0)
            {
                Role role = db.Roles.Find(Id_Role);
                db.Roles.Remove(role);
                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCateg(DashboardsViewModel model)
        {
            Category categ = new Category();
            categ.Category_Name = model.Category_Name;

            db.Categories.Add(categ);
            db.SaveChanges();

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditCateg(DashboardsViewModel model)
        {
            if (model.Id_Category > 0)
            {
                Category category = db.Categories.SingleOrDefault(x => x.Id_Category == model.Id_Category);
                category.Id_Category = model.Id_Category;
                category.Category_Name = model.Category_Name;
                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCateg(int Id_Category)
        {
            if (Id_Category > 0)
            {
                try
                {
                    Category category = db.Categories.Find(Id_Category);
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}