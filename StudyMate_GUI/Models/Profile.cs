using System;
using System.Collections.Generic;

namespace StudyApp.Models
{
    public class Profile
    {
        public User User{get; set;}
        public string? Name { get; set; }
        public string? Pronouns { get; set; }
        public string? Age {get; set;}
        public string? Program { get; set; }
        public string? School { get; set; }
        public string? Description {get; set;}
        public List<string> Subjects { get; set; }
        public List<string> CoursesTaking { get; set; }
        public List<string> CoursesStudying { get; set; }
        public List<string> Interests { get; set; }

        public Profile(User u){
            User = u;
            Age = "29";
            School = "Dawson";
            Description = "Looking to study for the upcoming 410 final exam!";
            Subjects = new List<string>();
            Subjects.Add("Humanities");
            Subjects.Add("Computer Science");
            Subjects.Add("English");
            CoursesTaking = new List<string>();
            CoursesStudying = new List<string>();
            Interests = new List<string>();
        }
    }
}