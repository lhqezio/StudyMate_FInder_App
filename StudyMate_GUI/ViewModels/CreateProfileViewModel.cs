using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
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

        private string _hobbieName;
        public string HobbieName
        {
            get => _hobbieName;
            set => this.RaiseAndSetIfChanged(ref _hobbieName, value);
        }

        private string _personalDescription;
        public string PersonalDescription
        {
            get => _personalDescription;
            set => this.RaiseAndSetIfChanged(ref _personalDescription, value);
        }

        public ReactiveCommand<Unit, Unit> CreateProfile { get; }

        public CreateProfileViewModel()
        {

        }
    }
}