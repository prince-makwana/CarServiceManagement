﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutomotiveDBEntities : DbContext
    {
        public AutomotiveDBEntities()
            : base("name=AutomotiveDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAppointment> tblAppointments { get; set; }
        public virtual DbSet<tblAppointmentService> tblAppointmentServices { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblDealer> tblDealers { get; set; }
        public virtual DbSet<tblDealersMechanic> tblDealersMechanics { get; set; }
        public virtual DbSet<tblMechanic> tblMechanics { get; set; }
        public virtual DbSet<tblPlanning> tblPlannings { get; set; }
        public virtual DbSet<tblService> tblServices { get; set; }
        public virtual DbSet<tblVehicle> tblVehicles { get; set; }
    }
}
