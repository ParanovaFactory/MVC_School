﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_School.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Db_MVC_SchoolEntities : DbContext
    {
        public Db_MVC_SchoolEntities()
            : base("name=Db_MVC_SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCours> tblCourses { get; set; }
        public virtual DbSet<tblScore> tblScores { get; set; }
        public virtual DbSet<tblSocialClub> tblSocialClubs { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
    }
}
