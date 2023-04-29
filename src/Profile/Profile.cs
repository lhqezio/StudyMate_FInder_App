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
        //Generates a random primary key for the Profile class
        [Key]
        public string ProfileId { get; set; }
        
        public string UsrId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string School {get;set;}
        public int Age { get; set; }
        public string Program { get; set; }
        public string PersonalDescription { get; set; }
        public string ProfilePicture { get; set; } //Subject to change because we still do not know exactly if we must use a string to store a picture
        public string Hobbies { get; set; }
        public string TakenCourses { get; set; }
        public string NeedHelpCourses { get; set; }
        public List<Event> Events { get; set; } = new();
        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.
        public Profile(string ProfileId,string name, int age, string program,string gender,string school,string UsrId,string needHelpCourses,string takenCourses,string hobbies,string PersonalDescription,string ProfilePicture)
        {
            this.ProfileId=ProfileId;
            Name = name;
            Age = age;
            Program = program;
            Gender = gender;
            School = school;
            NeedHelpCourses = needHelpCourses;
            TakenCourses = takenCourses;
            Hobbies = hobbies;
            this.UsrId=UsrId;
            this.PersonalDescription=PersonalDescription;
            this.ProfilePicture=ProfilePicture;
        }
    }
}
