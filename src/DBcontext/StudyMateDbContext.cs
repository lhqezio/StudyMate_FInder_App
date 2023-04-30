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
        public virtual  DbSet<Course>? StudyCourses { get; set; }
        public virtual DbSet<CourseTaken>? CoursesTaken {get; set;}
        public virtual DbSet<CourseCanHelpWith>? CoursesCanHelpWith {get; set;}
        public virtual DbSet<CourseNeedHelpWith>? CoursesNeedHelpWith {get; set;}
        public virtual DbSet<EventCalendar>? Events { get; set; }
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

            modelBuilder.Entity<CourseCanHelpWith>()
                .HasKey(ctp => new { ctp.CourseId, ctp.ProfileId });
                
            modelBuilder.Entity<CourseNeedHelpWith>()
                .HasKey(ctp => new { ctp.CourseId, ctp.ProfileId });

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
            
            modelBuilder.Entity<Profile>() //Link one Profile to its events (Creator) 
                .HasMany(p => p.CreatorEvents)
                .WithOne(e => e.Creator)
                .HasForeignKey("CreatorId")
                .IsRequired();

            modelBuilder.Entity<Profile>() //Link multiple Profile to multiple Events 
                .HasMany(p => p.ParticipatingEvents)
                .WithMany(e => e.Participants)
                .UsingEntity(
                    "EventProfile",
                    l => l.HasOne(typeof(EventCalendar)).WithMany().HasForeignKey("EventsId").HasPrincipalKey(nameof(EventCalendar.EventId)),
                    r => r.HasOne(typeof(Profile)).WithMany().HasForeignKey("ProfilesId").HasPrincipalKey(nameof(Profile.ProfileId)),
                    j => j.HasKey("EventsId", "ProfilesId")
                );
        }
    }
}