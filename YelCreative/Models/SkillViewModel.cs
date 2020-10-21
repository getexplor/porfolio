using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YelCreative.Models
{
    public class SkillViewModel
    {
        public int Id_Skill { get; set; }
        [Required(ErrorMessage = "This skill name be cannot empty")]
        public string Skill_Name { get; set; }
        [Range(0, 100)]
        [Required(ErrorMessage = "This skill value be cannot empty")]
        public Nullable<int> Skill_Value { get; set; }
    }
}