using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using StudyMate.Models;
using StudyMate.Services;

namespace StudyMate.ViewModels
{
    public class CreateProfileViewModel : ViewModelBase
    {
        public User User{get;set;}
        public List<Course> CoursesTaken { get; set; } = new List<Course>();
        public List<Course> CoursesCanHelpWith { get; set; } = new List<Course>();
        public List<Course> CoursesNeedHelpWith { get; set; } = new List<Course>();
        public List<Hobby> Hobbies { get; set; } = new List<Hobby>();
        public Profile Profile {get;set;} = new Profile();
        public School School{get;set;} = new School();
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

        private string _schoolName;
        public string SchoolName
        {
            get => _schoolName;
            set => this.RaiseAndSetIfChanged(ref _schoolName, value);
        }

        private string _program;
        public string Program
        {
            get => _program;
            set => this.RaiseAndSetIfChanged(ref _program, value);
        }

        private string _courseTakenName;
        public string CourseTakenName
        {
            get => _courseTakenName;
            set => this.RaiseAndSetIfChanged(ref _courseTakenName, value);
        }

        private string _courseCanHelpWithName;
        public string CourseCanHelpWithName
        {
            get => _courseCanHelpWithName;
            set => this.RaiseAndSetIfChanged(ref _courseCanHelpWithName, value);
        }

        private string _courseNeedHelpWithName;
        public string CourseNeedHelpWithName
        {
            get => _courseNeedHelpWithName;
            set => this.RaiseAndSetIfChanged(ref _courseNeedHelpWithName, value);
        }

        private string _hobbyName;
        public string HobbyName
        {
            get => _hobbyName;
            set => this.RaiseAndSetIfChanged(ref _hobbyName, value);
        }

        private string _personalDescription;
        public string PersonalDescription
        {
            get => _personalDescription;
            set => this.RaiseAndSetIfChanged(ref _personalDescription, value);
        }

        public ReactiveCommand<Unit, Unit> CreateProfile { get; }
        public ReactiveCommand<Unit, Unit> AddCoursesTakenCommand { get; }
        public ReactiveCommand<Unit, Unit> AddCoursesCanHelpWithCommand { get; }
        public ReactiveCommand<Unit, Unit> AddCoursesNeedHelpWithCommand { get; }
        public ReactiveCommand<Unit, Unit> AddHobbiesCommand { get; }

        public CreateProfileViewModel(User user)
        {
            this.User=user;
            AddCoursesTakenCommand = ReactiveCommand.Create(() => {
                var Course = new Course(this.CourseTakenName);
                this.CoursesTaken.Add(Course);
            });
            AddCoursesCanHelpWithCommand = ReactiveCommand.Create(() => {
                var Course = new Course(this.CourseCanHelpWithName);
                this.CoursesCanHelpWith.Add(Course);
            });
            AddCoursesNeedHelpWithCommand = ReactiveCommand.Create(() => {
                var Course = new Course(this.CourseNeedHelpWithName);
                this.CoursesNeedHelpWith.Add(Course); 
            });
            AddHobbiesCommand = ReactiveCommand.Create(() => {
                var Hobby = new Hobby(this.HobbyName);
                this.Hobbies.Add(Hobby);
            });
            CreateProfile = ReactiveCommand.Create(() => {
                this.School=new School(this.SchoolName);
                this.Profile= new Profile(this.User,this.Name,this.Gender,this.School,
                this.CoursesTaken,this.CoursesCanHelpWith,this.CoursesNeedHelpWith,
                this.Hobbies,this.Age,this.Program,this.PersonalDescription);
                using (var db = new StudyMateDbContext())
                {
                    ProfileServices ProfileService= new ProfileServices(db);
                    ProfileService.AddProfile(this.Profile);
                }
            });
        }
    }
}