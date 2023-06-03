using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using StudyMate.Models;
using StudyMate.Services;

namespace StudyMate.ViewModels
{
    public class CreateEventViewModel : ViewModelBase
    {
        public Profile Creator{get;set;}
        public List<Course> Courses { get; set; } = new List<Course>();
        public School School{get;set;} = new School();
        private string _courseName;
        public string CourseName
        {
            get => _courseName;
            set => this.RaiseAndSetIfChanged(ref _courseName, value);
        }
        private string _schoolName;
        public string SchoolName
        {
            get => _schoolName;
            set => this.RaiseAndSetIfChanged(ref _schoolName, value);
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        private DateTimeOffset _date;
        public DateTimeOffset Date
        {
            get => _date;
            set => this.RaiseAndSetIfChanged(ref _date, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        private string _location;
        public string Location
        {
            get => _location;
            set => this.RaiseAndSetIfChanged(ref _location, value);
        }

        private string _subjects;
        public string Subjects
        {
            get => _subjects;
            set => this.RaiseAndSetIfChanged(ref _subjects, value);
        }

        private string _personalDescription;
        public string PersonalDescription
        {
            get => _personalDescription;
            set => this.RaiseAndSetIfChanged(ref _personalDescription, value);
        }

        public ReactiveCommand<Unit, Unit> CreateEvent { get; }
        public ReactiveCommand<Unit, Unit> AddCourses { get; }

        public CreateEventViewModel(User user)
        {
            this.Date=DateTimeOffset.Now;
            this.Creator=findCreator(user.UserId);
            AddCourses = ReactiveCommand.Create(() => {
                var Course = new Course(this.CourseName);
                this.Courses.Add(Course);
            });
            CreateEvent = ReactiveCommand.Create(() => {
                this.School=new School(this.SchoolName);
                var newEvent= new Event(this.Creator,this.Title,this.Date,this.Description,this.Location,this.Subjects,
                this.Courses,this.School);
                using (var db = new StudyMateDbContext())
                {
                    EventServices eventServices= new EventServices(db);
                    eventServices.CreateEvent(newEvent);
                }
            });
        }
        private static Profile? findCreator(string UserId){
            using (var ressource = new StudyMateDbContext())
            {
                var searchServices = new SearchServices(ressource);
                return searchServices.GetProfileByUserId(UserId);
            }
        }   
    }
}