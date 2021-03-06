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
    
    public partial class tblAppointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAppointment()
        {
            this.tblAppointmentServices = new HashSet<tblAppointmentService>();
            this.tblPlannings = new HashSet<tblPlanning>();
        }
    
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string LicencePlate { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int DealerId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<float> TotalPrice { get; set; }
        public Nullable<decimal> TotalTime { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual tblDealer tblDealer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAppointmentService> tblAppointmentServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPlanning> tblPlannings { get; set; }
    }
}
