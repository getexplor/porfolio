using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class LandingViewMode
    {
        //about me
        public int Id_About { get; set; }
        public string Content_About { get; set; }
        public string Current_Position { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Birthday { get; set; }
        public string City { get; set; }
        public Nullable<int> Age { get; set; }
        public string Degree { get; set; }
        //Contact us
        public int Id_Contact { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Linkin { get; set; }
        //portofolio
        public int Id_Portofolio { get; set; }
        public string Title { get; set; }
        public int Category { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImagePath { get; set; }
        public virtual Category Category1 { get; set; }
        //category
        public int Id_Category { get; set; }
        public string Category_Name { get; set; }
        //services
        public int Id_Service { get; set; }
        public string Service_Name { get; set; }
        public string Content_Service { get; set; }
        //users
        public string Full_Name { get; set; }
        public string Image_Path { get; set; }
        //skill
        public int Id_Skill { get; set; }
        public string Skill_Name { get; set; }
        public Nullable<int> Skill_Value { get; set; }
    }
}