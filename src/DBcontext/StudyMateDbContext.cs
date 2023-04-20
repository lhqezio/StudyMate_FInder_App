using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace StudyMate
{
    public class StudyMateDbContext : DbContext
    {
        public DbSet<Profile>? Profiles { get; set; }
        public DbSet<UserDB>? Users { get; set; }
        public DbSet<CanHelpCourses>? CanHelpCourses { get; set; }
        public DbSet<NeedHelpCourses>? NeedHelpCourses { get; set;}
        public DbSet<TakenCourses>? TakenCourses { get; set;}
        // public StudyMateDbContext(DbContextOptions<StudyMateDbContext> options):base(options)
        // {}
        // public StudyMateDbContext():base()
        // {}

        // The following configures EF to connect to an oracle database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string? oracleUser=Environment.GetEnvironmentVariable("ORACLE_APP_USER");
            string? oraclePassword=Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
            string dataSource=@"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
            optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
        }
        public override int SaveChanges()
        {
            // Hash passwords before saving to the database
            var modifiedUsers = ChangeTracker.Entries<UserDB>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified )
                .ToList();
            
            foreach (var entry in modifiedUsers)
            {
                var user = entry.Entity;

                if (!string.IsNullOrEmpty(user.Password))
                {
                    string hashedPassword = PasswordHasher.HashPassword(user.Password);
                    string[] parts = hashedPassword.Split('.');
                    user.PasswordHash=parts[1];
                    user.Salt=parts[0];
                    user.Password = null;
                }
            }

            return base.SaveChanges();
        }
    }
}