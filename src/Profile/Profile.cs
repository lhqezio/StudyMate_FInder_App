// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Profile
    {
        // Primary Key
        [Key]
        public string ProfileId { get; set; }
        // One-to-one relationship
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User{get;set;} = null!;
        // one-to-many relationship
        [ForeignKey("SchoolId")]
        public string SchoolId {get;set;}
        public School School {get;set;} = null!;
        public CourseTaken courseTaken{get;} = new();
        // Many-to-many relationship
        public List<Hobby> Hobbies { get;} = new();
        //public List<EventCalendar> Events { get; set; } = new();
        //other properties
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Program { get; set; }
        public string PersonalDescription { get; set; }
        
        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.
        public Profile(string ProfileId,User user,string name,string gender, School school,int age, string program,string PersonalDescription="Hi I am using this app")
        {
            this.ProfileId=ProfileId;
            this.UserId=user.UserId;
            this.Name = name;
            this.Gender = gender;
            this.SchoolId = school.SchoolId;
            this.Age=age;
            this.Program=program;
            this.PersonalDescription = PersonalDescription;
        }
    }
}
