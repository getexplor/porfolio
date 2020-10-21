using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;

namespace YelCreative.Controllers
{
    [HandleError]
    public class LandingController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();
        AboutU about = new AboutU();
        Service service = new Service();
        Portofolio portofolio = new Portofolio();
        ContactU contact = new ContactU();
        Category category = new Category();
        User user = new User();
        Skill skill = new Skill();
        
        // GET: Landing
        public ActionResult Index()
        {
            LandingViewMode landingVM = new LandingViewMode();

            //user
            user = db.Users.SingleOrDefault(x => x.Id_User == 1);
            landingVM.Full_Name = user.Full_Name;
            landingVM.Image_Path = user.Image_Path;

            //about
            about = db.AboutUs.SingleOrDefault(x => x.Id_About == 1);
            landingVM.Id_About = about.Id_About;
            landingVM.Content_About = about.Content_About;
            landingVM.Current_Position = about.Current_Position;
            landingVM.Birthday = about.Birthday;
            landingVM.City = about.City;
            landingVM.Age = about.Age;
            landingVM.Degree = about.Degree;

            //services
            List<Service> serviceList = db.Services.ToList();
            ViewBag.ServiceList = serviceList;
            
            //portofolio
            List<Portofolio> protoList = db.Portofolios.ToList();
            ViewBag.PorfoList = protoList;

            //category
            List<Category> CategList = db.Categories.ToList();
            ViewBag.CateList = CategList;
            ViewBag.Category_Name = category.Category_Name;
            
            //contact us
            contact = db.ContactUs.SingleOrDefault(x => x.Id_Contact == 1);
            landingVM.Address = contact.Address;
            landingVM.Phone = contact.Phone;
            landingVM.Email = contact.Email;
            landingVM.Instagram = contact.Instagram;
            landingVM.Twitter = contact.Twitter;
            landingVM.Facebook = contact.Facebook;
            landingVM.Linkin = contact.Linkin;

            //skill
            List<Skill> skillList = db.Skills.ToList();
            ViewBag.SkillList = skillList;

            return View(landingVM);
        }
    }
}