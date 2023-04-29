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
        public virtual DbSet<EventCalendar>? Events { get; set; }
        public virtual  DbSet<CanHelpCourses>? CanHelpCourses { get; set; }
        public virtual  DbSet<NeedHelpCourses>? NeedHelpCourses { get; set;}
        public virtual  DbSet<TakenCourses>? TakenCourses { get; set;}
        public virtual  DbSet<School>? Schools { get; set;}
        public virtual  DbSet<SessionDB>? Sessions { get; set; }
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
            modelBuilder.Entity<EventCalendar>()
                .HasOne(e => e.EventCreator)
                .WithMany(u => u.EventsCreated)
                .HasForeignKey(e => e.ProfileId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
                
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
        }
    }
}