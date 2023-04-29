using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate;
public class User
{
    //Generates a random primary key for the User class
    [Key]
    public string UserId{get;set;}

    //Links the Profile Primary key to this foreign key
    public Profile? Profile{get;set;}
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public List<Conversation> Conversations { get; set; } = new();

    public User(string userId,string username, string email,string passwordHash)
    {
        UserId = userId;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }
}