using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudyMate.Models;


namespace StudyMate.ViewModels
{
    public class CreateProfileViewModel : ViewModelBase
    {
        public User User{get;set;}
        public string Name{get;set;}
        public string Gender{get;set;}
        public int Age{get;set;}
        public School School{get;set;}
        public string Program{get;set;}
        public List<Course> CoursesTaken{get;set;}
        public List<Course> CoursesCanHelpWith{get;set;}
        public List<Course> CoursesNeedHelpWith{get;set;}
        public List<Hobby> hobbies{get;set;}
        public string PersonalDescription{get;set;}

        public Profile Profile {get; set;}
        public CreateProfileViewModel()
        {

        }
    }
}