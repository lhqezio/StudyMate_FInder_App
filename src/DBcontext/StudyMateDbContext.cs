using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace StudyMate
{
    public class StudyMateDbContext : DbContext
    {
        public virtual  DbSet<Profile>? Profiles { get; set; }
        public virtual  DbSet<User>? Users { get; set; }
        public virtual  DbSet<School>? Schools { get; set; }
        public virtual  DbSet<Course>? Courses { get; set; }
        public virtual DbSet<CourseTaken>? CoursesTaken {get; set;}
        // public virtual DbSet<EventCalendar>? Events { get; set; }
        public virtual  DbSet<Conversation>? Conversations { get; set; }
        public virtual  DbSet<Message>? Messages { get; set; }
       

        private StudyMateDbContext _context = null!;
        // The following configures EF to connect to an oracle database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string? oracleUser=Environment.GetEnvironmentVariable("ORACLE_APP_USER");
            string? oraclePassword=Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
            string dataSource=@"198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca";
            optionsBuilder.UseOracle($"User Id={oracleUser}; Password={oraclePassword}; Data Source={dataSource};");
        }


        //One user can have multiple events (one-to-many)            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
            modelBuilder.Entity<CourseTaken>()
                .HasKey(ctp => new { ctp.CourseId, ctp.ProfileId });

            // modelBuilder.Entity<CourseTaken>()
            //     .HasOne(ctp => ctp.Course)
            //     .WithMany(c => c.courseTaken)
            //     .HasForeignKey(ctp => ctp.CourseId);

            // modelBuilder.Entity<CourseTaken>()
            //     .HasOne(ctp => ctp.Profile)
            //     .WithMany(p => p.courseTaken)
            //     .HasForeignKey(ctp => ctp.ProfileId);

            modelBuilder.Entity<Conversation>().HasMany(c => c.Users)
            .WithMany(u => u.Conversations)
            .UsingEntity<Dictionary<string, object>>(
                "UserConversation",
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Conversation>()
                    .WithMany()
                    .HasForeignKey("ConversationId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
            // modelBuilder.Entity<EventCalendar>().HasMany(e => e.Participant)
            // .WithMany(p => p.Events)
            // .UsingEntity<Dictionary<string, object>>(
            //     "ProfileEvent",
            //     j => j
            //         .HasOne<Profile>()
            //         .WithMany()
            //         .HasForeignKey("ProfileId")
            //         .OnDelete(DeleteBehavior.Cascade),
            //     j => j
            //         .HasOne<Event>()
            //         .WithMany()
            //         .HasForeignKey("EventId")
            //         .OnDelete(DeleteBehavior.Cascade)
            // );
            // modelBuilder.Entity<User>()
            //     .HasOne<Profile>()
            //     .WithOne()
            //     .HasForeignKey<Profile>(p => p.UserId);
        }
    }
}