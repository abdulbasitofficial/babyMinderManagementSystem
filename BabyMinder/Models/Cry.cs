//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BabyMinder.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cry
    {
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> BabyID { get; set; }
        public byte[] Audio { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
