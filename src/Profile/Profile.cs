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
        // one-to-many relationship with the bridging tables
        public List<CourseTaken> CourseTaken{get;set;} = new();
        public List<CourseCanHelpWith> CourseCanHelpWith{get;set;} = new();
        public List<CourseNeedHelpWith> CourseNeedHelpWith{get;set;} = new();
        // Many-to-many relationship
        public List<Hobby> Hobbies { get;} = new();
        public List<EventCalendar> ParticipatingEvents { get; set;} = new List<EventCalendar>(); //Parents
        public List<EventCalendar> CreatorEvents { get; set;} = new List<EventCalendar>(); //Parents
        
        //other properties
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
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

        //This mehtod allows to clear all the fields of the profile class in one shot.
        public void ClearProfile()
        {
            Name = "";
            Gender = null;
            Age = null;
            School=null;
            Program = "";
            PersonalDescription = "";
            Hobbies.Clear();
        }

        //Override of Equals method. This is used to compare two profile objects.
        //It is very useful for testing the ClearProfile method.
        public override bool Equals(object? obj)
        {
            if (obj is not Profile other)
                return false;
            return Name == other.Name
                && Gender == other.Gender
                && Age == other.Age
                && School == other.School
                && Program == other.Program
                && PersonalDescription == other.PersonalDescription
                && Hobbies.SequenceEqual(other.Hobbies);
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                Gender.GetHashCode() ^
                Age.GetHashCode() ^
                School.GetHashCode() ^
                Program.GetHashCode() ^
                PersonalDescription.GetHashCode() ^
                Hobbies.GetHashCode();
        }
    }
}
