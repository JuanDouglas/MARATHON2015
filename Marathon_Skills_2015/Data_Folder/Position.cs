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
    
    public partial class Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            this.Staff = new HashSet<Staff>();
        }
    
        public short PositionId { get; set; }
        public string PosintionName { get; set; }
        public string PositionDescription { get; set; }
        public decimal Payrate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
