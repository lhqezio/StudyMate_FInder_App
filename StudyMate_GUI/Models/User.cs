using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Models;
public class User
{
    //Generates a random primary key for the User class
    [Key]
    public string UserId{get;set;} = null!;
    //Links the Profile Primary key to this foreign key
    public Profile? Profile{get;set;}
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public List<Conversation> Conversations { get; set; } = new();
    

    public User(){}
    public User(string Id,string username, string email,string passwordHash) //Id shouldn't be in constructor
    {
        this.UserId = Id;
        this.Username = username;
        this.Email = email;
        this.PasswordHash = passwordHash;
    }
}