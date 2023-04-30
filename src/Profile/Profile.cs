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
        public List<EventCalendar> CreatorEvents { get; set;} = new List<EventCalendar>(); //Parents

        // one-to-many relationship with the bridging tables
        public List<CourseTaken> CourseTaken{get;set;} = new();
        public List<CourseCanHelpWith> CourseCanHelpWith{get;set;} = new();
        public List<CourseNeedHelpWith> CourseNeedHelpWith{get;set;} = new();
        public List<EventProfile> EventProfile{get;set;} = new();

        // Many-to-many relationship
        public List<Hobby> Hobbies { get; set;} = new();
        public List<EventCalendar> ParticipatingEvents { get; set;} = new List<EventCalendar>(); //Parents
    
        //other properties
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Program { get; set; }
        public string PersonalDescription { get; set; }
        
        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.

        public Profile(){}
        public Profile(string ProfileId,User user,string name,string gender, School school,int age, string program,string PersonalDescription="Hi I am using this app")
        {
            this.ProfileId=ProfileId;
            this.UserId=user.UserId;
            this.Name = name;
            this.Gender = gender;
            this.SchoolId = school.SchoolId;
            this.School=school;
            this.Age=age;
            this.Program=program;
            this.PersonalDescription = PersonalDescription;
        }
    }
}
