using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class ProfileViewModel
    {
        public int Id_User { get; set; }
        [Required(ErrorMessage = "This email cannot be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This password cannot be empty")]
        public string password { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = "This full name cannot be empty")]
        public string Full_Name { get; set; }
        public int Id_Role { get; set; }
        public string Image_Path { get; set; }
        public byte[] Image_Byte { get; set; }
        public virtual Role Role { get; set; }
        public string Role_Name { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.JPG)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}