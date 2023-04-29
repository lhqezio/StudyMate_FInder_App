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

            modelBuilder.Entity<School>()
                .HasIndex(n => n.Name)
                .IsUnique();
        }


        public virtual User Login(string username, string password)
        {
            // Get the user from the database
            User user = Users.FirstOrDefault(u => u.Username == username);

            // If the user doesn't exist, return null
            if (user == null)
            {
                return null;
            }

            // If the password is incorrect, return null
            if (!PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }
            // If the user is valid, return a User object
            return new User(user.UserId,user.Username, user.PasswordHash, user.UserId);
        }
        public virtual User Register(string username, string email, string password)
        {
            System.Console.WriteLine(username);
            // Get the user from the database
            User user = Users.FirstOrDefault(u => u.Username == "alain");

            // If the user already exists, return null
            if (user != null)
            {
                return null;
            }

            // Create a new user
            user = new User(Guid.NewGuid().ToString(),username, email, PasswordHasher.HashPassword(password));

            // Add the user to the database
            Users.Add(user);
            SaveChanges();
            return Login(username, password);
        }

        public virtual void ChangePassword(string sessionKey, string newPassword)
        {
            // Get the session from the database
            SessionDB session = Sessions.FirstOrDefault(s => s.SessionKey == sessionKey);

            // If the session doesn't exist, return
            if (session == null)
            {
                return;
            }

            // Get the user from the database
            User user = Users.FirstOrDefault(u => u.UserId == session.UserId);

            // If the user doesn't exist, return
            if (user == null)
            {
                return;
            }

            // Change the user's password
            user.PasswordHash = PasswordHasher.HashPassword(newPassword);

            // Update the user in the database
            Users.Update(user);
            SaveChanges();
        }
    }
}