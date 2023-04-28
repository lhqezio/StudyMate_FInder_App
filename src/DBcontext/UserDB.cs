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
    public Profile? Profile{get;set;}

    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    public UserDB(string username, string email,string password)
    {
        UserId = Guid.NewGuid().ToString();
        Username = username;
        Email = email;
        PasswordHash = PasswordHasher.HashPassword(password);
    }
}