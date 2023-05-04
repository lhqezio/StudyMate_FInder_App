using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate;
public class User
{
    //Generates a random primary key for the User class
    [Key]
    public string UserId{get;set;} //Should be an int not a string
    //Links the Profile Primary key to this foreign key
    public Profile? Profile{get;set;}
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    [InverseProperty("Users")]
    public List<Conversation> Conversations { get; set; } = new();
    

    public User(){}
    public User(string Id,string username, string email,string passwordHash) //Id shouldn't be an int
    {
        this.UserId = Id;
        this.Username = username;
        this.Email = email;
        this.PasswordHash = passwordHash;
    }
}