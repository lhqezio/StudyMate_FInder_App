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
        [ForeignKey("UserId")]
        public User User{get;set;} = null!;
        
        [InverseProperty("Creator")]
        public List<Event> CreatorEvents { get; set;} = new List<Event>(); //Parents
        [InverseProperty("Participants")]
        public List<Event> ParticipantEvents { get; set;} = new List<Event>(); //Parents

        // one-to-many relationship with the bridging tables
        [InverseProperty("StudentsTakingCourse")]
        public List<Course>? CourseTaken{get;set;} = new();
        
        [InverseProperty("StudentsTutoringCourse")]
        public List<Course>? CourseCanHelpWith{get;set;} = new();

        [InverseProperty("StudentsNeedHelpCourse")]
        public List<Course>? CourseNeedHelpWith{get;set;} = new();

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        [InverseProperty("Profiles")]
        public List<Hobby> Hobbies { get; set;} = new();
    
        //other properties
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Program { get; set; }
        public string PersonalDescription { get; set; }
        
        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.

        public Profile(){}
        public Profile(User user, string name, List<Event> creatorEvents, List<Event> participantEvents, string gender, School school, List<, int age, string program,string PersonalDescription)
        {
            this.User = user;
            
            this.Name = name;
            this.Gender = gender;
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
            // Hobbies.Clear();
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
                && PersonalDescription == other.PersonalDescription;
                // && Hobbies.SequenceEqual(other.Hobbies);
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                Gender.GetHashCode() ^
                Age.GetHashCode() ^
                School.GetHashCode() ^
                Program.GetHashCode() ^
                PersonalDescription.GetHashCode();
                // Hobbies.GetHashCode();
        }
    }
}
