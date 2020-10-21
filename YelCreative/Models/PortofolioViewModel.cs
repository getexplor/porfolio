using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class PortofolioViewModel
    {
        public int Id_Portofolio { get; set; }

        [Required(ErrorMessage = "This title cannot be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This category cannot be empty")]
        public int Category { get; set; }
        
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.JPG)$", ErrorMessage = "Only Image files allowed.")]
        [Required(ErrorMessage = "This portofolio cannot be empty")]
        public HttpPostedFileBase ImageUpload { get; set; }
        
        public string ImageTitle { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImagePath { get; set; }


        public virtual Category Category1 { get; set; }
        [Required(ErrorMessage = "This category name cannot be empty")]
        public string Category_Name { get; set; }
    }
}