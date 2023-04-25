using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace StudyMate
{
    public class StudyMateDbContext : DbContext
    {
        public virtual  DbSet<Profile>? Profiles { get; set; }
        public virtual  DbSet<UserDB>? Users { get; set; }
        public virtual DbSet<EventCalendar>? Events { get; set; }
        public virtual  DbSet<CanHelpCourses>? CanHelpCourses { get; set; }
        public virtual  DbSet<NeedHelpCourses>? NeedHelpCourses { get; set;}
        public virtual  DbSet<TakenCourses>? TakenCourses { get; set;}
        public virtual  DbSet<SessionDB>? Sessions { get; set; }

        // The following configures EF to connect to an oracle database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string? oracleUser=Environment.GetEnvironmentVariable("ORACLE_APP_USER");
            string? oraclePassword=Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
            string dataSource=@"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
            optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCalendar>()
                .HasOne(e => e.EventCreator)
                .WithMany(p => p.EventsCreated)
                .HasForeignKey(e => e.ProfileId);
        }
        
    }
}

