//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marathon.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timesheet
    {
        public int TimesheetId { get; set; }
        public int StaffId { get; set; }
        public Nullable<System.DateTime> StartDateTime { get; set; }
        public Nullable<System.DateTime> EndDateTime { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
    
        public virtual Staff Staff { get; set; }
    }
}
