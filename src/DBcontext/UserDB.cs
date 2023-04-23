using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate;
public class UserDB
{
    //Generates a random primary key for the UserDB class
    [Key]
    public string Id{get;set;}

    //Links the Profile Primary key to this foreign key
    [ForeignKey("Profile")]
    public string? ProfileId{get;set;}

    public string Username { get; set; }
    public string Email { get; set; }
    public string? Salt { get; set; }
    public string? PasswordHash { get; set; }
    public string? Password {get;set;}
    
    
    public UserDB(string username, string email,string password)
    {
        Id = Guid.NewGuid().ToString();
        Username = username;
        Email = email;
        Password = password;
    }
}