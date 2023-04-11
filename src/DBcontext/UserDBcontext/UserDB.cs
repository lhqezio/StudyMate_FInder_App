using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate;
public class UserDB
{
    //Generates a random primary key for the UserDB class
    [Key]
    public string UserId{get;set;}

    //Links the Profile Primary key to this foreign key
    [ForeignKey("Profile")]
    public string ProfileId{get;set;}

    public string Username { get; set; }
    public string Email { get; set; }
    public string? Salt { get; set; }
    public string? PasswordHash { get; set; }
    public string? Password {get;set;}
    
    
    public UserDB(string username, string email,string salt,string password)
    {
        UserId = Guid.NewGuid().ToString();
        Username = username;
        Email = email;
        Salt = salt;
        Password = password;
    }
}

public class UserDbContext:DbContext
{
    public DbSet<UserDB>? Users {get;set;}
    public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
    {}
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