using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using StudyMate.Models;


namespace StudyMate.ViewModels
{
    public class CreateProfileViewModel : ViewModelBase
    {
        public User User{get;set;}
        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set => this.RaiseAndSetIfChanged(ref _gender, value);
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => this.RaiseAndSetIfChanged(ref _age, value);
        }

        private School _school;
        public School School
        {
            get => _school;
            set => this.RaiseAndSetIfChanged(ref _school, value);
        }

        private string _program;
        public string Program
        {
            get => _program;
            set => this.RaiseAndSetIfChanged(ref _program, value);
        }

        private List<Course> _coursesTaken = new List<Course>();
        public List<Course> CoursesTaken
        {
            get => _coursesTaken;
            set => this.RaiseAndSetIfChanged(ref _coursesTaken, value);
        }

        private List<Course> _coursesCanHelpWith = new List<Course>();
        public List<Course> CoursesCanHelpWith
        {
            get => _coursesCanHelpWith;
            set => this.RaiseAndSetIfChanged(ref _coursesCanHelpWith, value);
        }

        private List<Course> _coursesNeedHelpWith = new List<Course>();
        public List<Course> CoursesNeedHelpWith
        {
            get => _coursesNeedHelpWith;
            set => this.RaiseAndSetIfChanged(ref _coursesNeedHelpWith, value);
        }

        private List<Hobby> _hobbies = new List<Hobby>();
        public List<Hobby> Hobbies
        {
            get => _hobbies;
            set => this.RaiseAndSetIfChanged(ref _hobbies, value);
        }

        private string _personalDescription;
        public string PersonalDescription
        {
            get => _personalDescription;
            set => this.RaiseAndSetIfChanged(ref _personalDescription, value);
        }


        public CreateProfileViewModel()
        {

        }
    }
}