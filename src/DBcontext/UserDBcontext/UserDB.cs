using Microsoft.EntityFrameworkCore;
namespace StudyMate;
[PrimaryKey(nameof(Id))]
public class UserDB
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Salt { get; set; }
    public string? PasswordHash { get; set; }
    public string? Password {get;set;}
    
    
    public UserDB(string username, string email,string salt,string password)
    {
        Id = Guid.NewGuid().ToString();
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