﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApartmentAutomationEntities : DbContext
    {
        public ApartmentAutomationEntities()
            : base("name=ApartmentAutomationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<Expanse> Expanse { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseHost> HouseHost { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
