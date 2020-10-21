using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;

namespace YelCreative.Controllers
{
    [HandleError]
    [Authorize]
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            YelCreativeEntities db = new YelCreativeEntities();
            List<Service> serviceList = db.Services.ToList();
            ViewBag.ServiceList = serviceList;

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
        public ActionResult Index(ServiceViewModel model)
        {
            YelCreativeEntities db = new YelCreativeEntities();
            

            if(model.Id_Service > 0){
                try
                {
                    Service service = db.Services.SingleOrDefault(x => x.Id_Service == model.Id_Service);

                    service.Id_Service = model.Id_Service;
                    service.Service_Name = model.Service_Name;
                    service.Content_Service = model.Content_Service;
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }
            else{

                Service service = new Service();
                service.Id_Service = model.Id_Service;
                service.Service_Name = model.Service_Name;
                service.Content_Service = model.Content_Service;

                db.Services.Add(service);
                db.SaveChanges();

            }
            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditService(int Id_Service)
        {
            YelCreativeEntities db = new YelCreativeEntities();
            ServiceViewModel model = new ServiceViewModel();

            List<Role> roleList = db.Roles.ToList();
            ViewBag.SelectRole = new SelectList(roleList, "Id_Role", "Role_Name");

            if (Id_Service > 0)
            {
                Service service = db.Services.SingleOrDefault(x => x.Id_Service == Id_Service);
                model.Id_Service = service.Id_Service;
                model.Service_Name = service.Service_Name;
                model.Content_Service = service.Content_Service;
            }

            return PartialView("ServiceEditModal", model);
        }

        public ActionResult DeleteService(int Id_Service)
        {
            YelCreativeEntities db = new YelCreativeEntities();
            Service service = db.Services.Find(Id_Service);
            db.Services.Remove(service);
            db.SaveChanges();

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}