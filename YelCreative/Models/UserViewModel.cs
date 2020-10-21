using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class UserViewModel
    {
        public int Id_User { get; set; }
        [Required(ErrorMessage = "Email Cannot be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passwords Cannot be empty")]
        public string password { get; set; }
        public string Picture { get; set; }
        public string Full_Name { get; set; }
        public int Id_Role { get; set; }
        public string Image_Path { get; set; }
        public byte[] Image_Byte { get; set; }
        public virtual Role Role { get; set; }
    }
}