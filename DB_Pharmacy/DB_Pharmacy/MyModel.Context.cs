﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_Pharmacy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NEWDBEntities : DbContext
    {
        public NEWDBEntities()
            : base("name=NEWDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_employee> tbl_employee { get; set; }
        public virtual DbSet<tbl_Item> tbl_Item { get; set; }
        public virtual DbSet<tbl_patient> tbl_patient { get; set; }
        public virtual DbSet<tbl_plogin> tbl_plogin { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
