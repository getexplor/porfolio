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
    public class ContactController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();
        ContactU contact = new ContactU();

        // GET: Contact
        public ActionResult Index()
        {
            contact = db.ContactUs.SingleOrDefault(x => x.Id_Contact == 1);
            ContactViewModel contacVM = new ContactViewModel();

            contacVM.Id_Contact = contact.Id_Contact;
            contacVM.Address = contact.Address;
            contacVM.Phone = contact.Phone;
            contacVM.Email = contact.Email;
            contacVM.Instagram = contact.Instagram;
            contacVM.Twitter = contact.Twitter;
            contacVM.Facebook = contact.Facebook;
            contacVM.Linkin = contact.Linkin;

            int id = Int32.Parse(Session["AdminId"].ToString());

            User usr = db.Users.SingleOrDefault(x => x.Id_User == id);
            ViewBag.AdminPhoto = usr.Image_Path;
            ViewBag.AdminName = usr.Full_Name;

            return View(contacVM);
        }

        [HttpPost]
        public ActionResult UpdateContact(ContactViewModel model)
        {
            if (model.Id_Contact > 0)
            {
                contact = db.ContactUs.SingleOrDefault(x => x.Id_Contact == model.Id_Contact);

                contact.Id_Contact = model.Id_Contact;
                contact.Address = model.Address;
                contact.Phone = model.Phone;
                contact.Email = model.Email;
                db.SaveChanges();
                
            }
            else
            {
                contact.Address = model.Address;
                contact.Phone = model.Phone;
                contact.Email = model.Email;

                db.ContactUs.Add(contact);
                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateSocial(ContactViewModel model)
        {
            if (model.Id_Contact > 0)
            {
                contact = db.ContactUs.SingleOrDefault(x => x.Id_Contact == model.Id_Contact);

                contact.Id_Contact = model.Id_Contact;
                contact.Instagram = model.Instagram;
                contact.Twitter = model.Twitter;
                contact.Facebook = model.Facebook;
                contact.Linkin = model.Linkin;
                db.SaveChanges();

            }
            else
            {
                contact = db.ContactUs.SingleOrDefault(x => x.Id_Contact == model.Id_Contact);
                contact.Id_Contact = model.Id_Contact;
                contact.Instagram = model.Instagram;
                contact.Twitter = model.Twitter;
                contact.Facebook = model.Facebook;
                contact.Linkin = model.Linkin;

                db.ContactUs.Add(contact);
                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}