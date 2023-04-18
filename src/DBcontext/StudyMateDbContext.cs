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
        public DbSet<CoursesMapping>? CoursesMappings { get; set; }
        // The following configures EF to connect to an oracle database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string? oracleUser=Environment.GetEnvironmentVariable("ORACLE_APP_USER");
            string? oraclePassword=Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
            string dataSource=@"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
            optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoursesMapping>()
                .HasKey(c => new { c.ProfileId, c.Course });

            modelBuilder.Entity<CoursesMapping>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.Course)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CoursesMapping>()
                .HasOne(c => c.Profile)
                .WithMany(p => p.CoursesMappings)
                .HasForeignKey(c => c.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}