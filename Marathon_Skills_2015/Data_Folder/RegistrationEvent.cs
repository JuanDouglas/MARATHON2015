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
    
    public partial class RegistrationEvent
    {
        public int RegistrationEventId { get; set; }
        public int RegistrationId { get; set; }
        public Nullable<int> EventId { get; set; }
        public Nullable<short> BibNumber { get; set; }
        public Nullable<int> RaceTime { get; set; }
    
        public virtual C_Event C_Event { get; set; }
        public virtual Registration Registration { get; set; }
    }
}
