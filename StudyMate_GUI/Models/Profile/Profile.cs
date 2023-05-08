// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudyMate
{
    public class Profile //Profile Picture ??
    {
        // Primary Key
        [Key]
        public int ProfileId { get; set; }
        // One-to-one relationship
        [ForeignKey("UserId")]
        public User User{get;set;} = null!;
        
        [InverseProperty("Creator")]
        public List<Event>? CreatorEvents { get; set;} = new List<Event>(); //Parents
        [InverseProperty("Participants")]
        public List<Event>? ParticipantEvents { get; set;} = new List<Event>(); //Parents

        // one-to-many relationship with the bridging tables
        [InverseProperty("StudentsTakingCourse")]
        public List<Course>? CourseTaken{get;set;} = new();
        
        [InverseProperty("StudentsTutoringCourse")]
        public List<Course>? CourseCanHelpWith{get;set;} = new();

        [InverseProperty("StudentsNeedHelpCourse")]
        public List<Course>? CourseNeedHelpWith{get;set;} = new();

        [ForeignKey("SchoolId")]
        public School? School { get; set; }

        [InverseProperty("Profiles")]
        public List<Hobby>? Hobbies { get; set;} = new();
    
        //other properties
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int? Age { get; set; }
        public string Program { get; set; } = null!;
        public string PersonalDescription { get; set; } = null!;
        
        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.

        public Profile(){}
        public Profile(User user, string name, string gender, School school, List<Course>? courseTaken, List<Course>? courseCanHelpWith, List<Course>? courseNeedHelpWith, List<Hobby>? hobbies, int age, string program,string PersonalDescription)
        {
            this.User = user;
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
            this.School=school;
            this.Program=program;
            this.CourseTaken = courseTaken;
            this.CourseCanHelpWith = courseCanHelpWith;
            this.CourseNeedHelpWith = courseNeedHelpWith;
            this.PersonalDescription = PersonalDescription;
            this.Hobbies = hobbies;
            
            
        }

        //This mehtod allows to clear all the fields of the profile class in one shot.
        public void ClearProfile()
        {
            Name = "";
            Gender = null!;
            Age = null;
            School=null;
            Program = "";
            CourseTaken!.Clear();
            CourseCanHelpWith!.Clear();
            CourseNeedHelpWith!.Clear();
            PersonalDescription = "";
            Hobbies!.Clear();
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
                && CourseTaken == other.CourseTaken
                && CourseCanHelpWith == other.CourseCanHelpWith
                && CourseNeedHelpWith == other.CourseNeedHelpWith
                && PersonalDescription == other.PersonalDescription
                && Hobbies!.SequenceEqual(other.Hobbies!);
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                Gender.GetHashCode() ^
                Age.GetHashCode() ^
                School!.GetHashCode() ^
                Program.GetHashCode() ^
                CourseTaken!.GetHashCode() ^
                CourseCanHelpWith!.GetHashCode() ^
                CourseNeedHelpWith!.GetHashCode() ^
                PersonalDescription.GetHashCode() ^
                Hobbies!.GetHashCode();
        }
    }
}
