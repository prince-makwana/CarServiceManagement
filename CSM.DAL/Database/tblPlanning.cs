//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSM.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPlanning
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int MechanicId { get; set; }
        public int AppointmentServiceId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<decimal> Duration { get; set; }
    
        public virtual tblAppointment tblAppointment { get; set; }
        public virtual tblAppointmentService tblAppointmentService { get; set; }
        public virtual tblMechanic tblMechanic { get; set; }
    }
}
