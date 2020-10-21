using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YelCreative.Models;

namespace YelCreative.Controllers
{
    [HandleError]
    [Authorize]
    public class PortofolioController : Controller
    {
        YelCreativeEntities db = new YelCreativeEntities();
        // GET: Portofolio
        public ActionResult Index()
        {
            
            List<Category> list = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(list, "Id_Category", "Category_Name");

            List<Portofolio> portoList = db.Portofolios.ToList();
            ViewBag.PortoList = portoList;

            int id = Int32.Parse(Session["AdminId"].ToString());

            User usr = db.Users.SingleOrDefault(x => x.Id_User == id);
            ViewBag.AdminPhoto = usr.Image_Path;
            ViewBag.AdminName = usr.Full_Name;

            return View();
        }

        //add new category
        [HttpPost]
        public ActionResult Index(PortofolioViewModel model)
        {
            Category category = new Category();
            category.Category_Name = model.Category_Name;

            db.Categories.Add(category);
            db.SaveChanges();

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
        //add new porto
        [HttpPost]
        public ActionResult AddPortofolio(PortofolioViewModel model)
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(list, "Id_Category", "Category_Name");
            
            var file = model.ImageUpload;
            byte[] imagebyte = null;

            if (file != null)
            {
                string filename = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);

                filename = filename + DateTime.Now.ToString("yymmssff") + extension;

                file.SaveAs(Server.MapPath("/Images/gallery/" + filename));
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                Portofolio porto = new Portofolio();
                
                porto.Title = model.Title;
                porto.Category = model.Category;
                porto.ImageTitle = filename;
                porto.ImageByte = imagebyte;
                porto.ImagePath = "/Images/gallery/" + filename;

                db.Portofolios.Add(porto);
                db.SaveChanges();
                
            }
            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePortofolio(PortofolioViewModel model)
        {
            if (model.Id_Portofolio > 0)
            {
                Portofolio porto = new Portofolio();

                porto = db.Portofolios.SingleOrDefault(x => x.Id_Portofolio == model.Id_Portofolio);

                porto.Title = model.Title;
                porto.Category = model.Category;

                db.SaveChanges();
            }

            var response = true;
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult DeletePorto(int Id_Portofolio)
        {
            var porto = db.Portofolios.Find(Id_Portofolio);

            string currentImg = Request.MapPath(porto.ImagePath);

            

            db.Entry(porto).State = EntityState.Deleted;
            if (db.SaveChanges() > 0)
            {
                if (System.IO.File.Exists(currentImg))
                {
                    System.IO.File.Delete(currentImg);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
       
    }
}