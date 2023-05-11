using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using StudyMate.Models;
namespace StudyMate.Services
{
    public class StudyMateDbContext : DbContext
    {
        public virtual  DbSet<Profile>? StudyMate_Profiles { get; set; }
        public virtual  DbSet<User>? StudyMate_Users { get; set; }
         public virtual  DbSet<School>? StudyMate_Schools { get; set; }
        public virtual  DbSet<Course>? StudyMate_Courses { get; set; }
        public virtual DbSet<Event>? StudyMate_Events { get; set; }
        public virtual  DbSet<Conversation>? StudyMate_Conversations { get; set; }
        public virtual  DbSet<Message>? StudyMate_Messages { get; set; }
        public virtual  DbSet<Hobby>? StudyMate_Hobbies { get; set; }
       

        private StudyMateDbContext _context = null!;
        // The following configures EF to connect to an oracle database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string? oracleUser=Environment.GetEnvironmentVariable("ORACLE_APP_USER");
            string? oraclePassword=Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
            string dataSource=@"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
            optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

        //     modelBuilder.Entity<Course>()
        //         .HasIndex(c => c.CourseName)
        //         .IsUnique();

        //     modelBuilder.Entity<CourseTaken>()
        //         .HasKey(ctp => new { ctp.CourseId, ctp.ProfileId });

        //     modelBuilder.Entity<CourseCanHelpWith>()
        //         .HasKey(ctp => new { ctp.CourseId, ctp.ProfileId });
                
        //     modelBuilder.Entity<CourseNeedHelpWith>()
        //         .HasKey(ctp => new { ctp.CourseId, ctp.ProfileId });

        //     modelBuilder.Entity<EventCourse>()
        //         .HasKey(ev => new { ev.EventId, ev.CourseId });

        //     modelBuilder.Entity<EventProfile>()
        //         .HasKey(ep => new { ep.EventId, ep.ProfileId });

            modelBuilder.Entity<Conversation>().HasMany(c => c.Users)
            .WithMany(u => u.Conversations)
            .UsingEntity<Dictionary<string, object>>(
                "UserConversation",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId"),
                j => j
                    .HasOne<Conversation>()
                    .WithMany()
                    .HasForeignKey("ConversationId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
            
        //     modelBuilder.Entity<Profile>() //Link one Profile to its events (Creator) 
        //         .HasMany(p => p.CreatorEvents)
        //         .WithOne(e => e.Creator)
        //         .HasForeignKey("CreatorId")
        //         .IsRequired();
        }
    }
}