﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace facebook_mvc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_facebookEntities : DbContext
    {
        public db_facebookEntities()
            : base("name=db_facebookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<friend_requests> friend_requests { get; set; }
        public virtual DbSet<friend> friends { get; set; }
        public virtual DbSet<like> likes { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<user_profile> user_profile { get; set; }
    }
}
