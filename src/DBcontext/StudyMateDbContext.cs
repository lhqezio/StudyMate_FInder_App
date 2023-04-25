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

        //AddEvent Method => Add event to the list of events
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCalendar>()
                .HasOne(e => e.EventCreator)
                .WithMany(p => p.EventsCreated)
                .HasForeignKey(e => e.ProfileId);
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

        public virtual string GenerateSessionKey(string userId)
        {
            // Generate a session key
            string sessionKey = Guid.NewGuid().ToString();

            // Create a new session
            SessionDB session = new SessionDB(sessionKey, userId, DateTime.Now.AddMinutes(30));

            // Add the session to the database
            Sessions.Add(session);
            SaveChanges();

            return sessionKey;
        }

        public virtual bool ValidateSessionKey(string sessionKey)
        {
            // Get the session from the database
            SessionDB session = Sessions.FirstOrDefault(s => s.SessionKey == sessionKey);

            // If the session doesn't exist, return false
            if (session == null)
            {
                return false;
            }

            // If the session has expired, return false
            if (session.Expiration < DateTime.Now)
            {
                return false;
            }

            // If the session is valid, return true
            return true;
        }
        
        public virtual User Login(string username, string password)
        {
            // Get the user from the database
            UserDB user = Users.FirstOrDefault(u => u.Username == username);

            // If the user doesn't exist, return null
            if (user == null)
            {
                return null;
            }

            // If the password is incorrect, return null
            if (!PasswordHasher.VerifyPassword(password, $"{user.Salt}.{user.PasswordHash}"))
            {
                return null;
            }
            var sessionKey = GenerateSessionKey(user.Id);
            // If the user is valid, return a User object
            return new User(user.Username, sessionKey, user.Id);
        }

        public virtual User LoginFromSessionKey(string session_key){
            // Get the session from the database
            SessionDB session = Sessions.FirstOrDefault(s => s.SessionKey == session_key);

            // If the session doesn't exist, return null
            if (session == null)
            {
                return null;
            }

            // If the session has expired, return null
            if (session.Expiration < DateTime.Now)
            {
                return null;
            }

            // Get the user from the database
            UserDB user = Users.FirstOrDefault(u => u.Id == session.UserId);

            // If the user doesn't exist, return null
            if (user == null)
            {
                return null;
            }

            // If the user is valid, return a User object
            return new User(user.Username, session_key, user.Id);
        }

        public virtual User Register(string username, string email, string password)
        {
            // Get the user from the database
            UserDB user = Users.FirstOrDefault(u => u.Username == username);

            // If the user already exists, return null
            if (user != null)
            {
                return null;
            }

            // Create a new user
            user = new UserDB(username, email, password);

            // Add the user to the database
            Users.Add(user);
            SaveChanges();
            return Login(username, password);
        }

        public virtual void Logout(string sessionKey)
        {
            // Get the session from the database
            SessionDB session = Sessions.FirstOrDefault(s => s.SessionKey == sessionKey);

            // If the session doesn't exist, return
            if (session == null)
            {
                return;
            }

            // Remove the session from the database
            Sessions.Remove(session);
            SaveChanges();
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
            UserDB user = Users.FirstOrDefault(u => u.Id == session.UserId);

            // If the user doesn't exist, return
            if (user == null)
            {
                return;
            }

            // Change the user's password
            user.Password = newPassword;

            // Update the user in the database
            Users.Update(user);
            SaveChanges();
        }
    }
}

