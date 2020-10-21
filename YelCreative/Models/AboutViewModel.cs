using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class AboutViewModel
    {
        public int Id_About { get; set; }
        [Required(ErrorMessage = "This content be cannot empty")]
        public string Content_About { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Update_Date { get; set; }
        public string Current_Position { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Birthday { get; set; }
        public string City { get; set; }
        public Nullable<int> Age { get; set; }
        public string Degree { get; set; }
    }
}