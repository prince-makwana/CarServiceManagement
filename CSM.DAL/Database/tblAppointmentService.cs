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
    
    public partial class tblAppointmentService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAppointmentService()
        {
            this.tblPlannings = new HashSet<tblPlanning>();
        }
    
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public string CostType { get; set; }
        public string SalesPart { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public float PricePerUnit { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float FixPrice { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsAdditional { get; set; }
    
        public virtual tblAppointment tblAppointment { get; set; }
        public virtual tblService tblService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPlanning> tblPlannings { get; set; }
    }
}
