//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YelCreative.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Portofolio
    {
        public int Id_Portofolio { get; set; }
        public string Title { get; set; }
        public int Category { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImagePath { get; set; }
    
        public virtual Category Category1 { get; set; }
    }
}
