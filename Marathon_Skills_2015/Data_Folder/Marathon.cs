//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marathon_Skills_2015.Data_Folder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Marathon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marathon()
        {
            this.C_Event = new HashSet<C_Event>();
        }
    
        public int MarathonId { get; set; }
        public string MarathonName { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public Nullable<short> YearHeld { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Event> C_Event { get; set; }
        public virtual Country Country { get; set; }
    }
}
