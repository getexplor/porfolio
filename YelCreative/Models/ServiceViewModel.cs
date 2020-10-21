using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class ServiceViewModel
    {
        public int Id_Service { get; set; }
        [Required(ErrorMessage = "This service name be cannot empty")]
        public string Service_Name { get; set; }
        [Required(ErrorMessage = "This content be cannot empty")]
        [StringLength(200, ErrorMessage ="Maximum 200 Characters")]
        public string Content_Service { get; set; }
    }
}