using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class DashboardsViewModel
    {
        public int Id_Role { get; set; }
        public int Id_Category { get; set; }
        [Required(ErrorMessage="This position name cannot be empty")]
        public string Role_Name { get; set; }
        [Required(ErrorMessage = "This category name cannot be empty")]
        public string Category_Name { get; set; }
    }
}