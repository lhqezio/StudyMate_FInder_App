using System.Reactive;
using StudyMate.Models;
using ReactiveUI;
using StudyMate.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudyMate.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        public ObservableCollection<Course> CoursesTaken { get; set; }
        public ObservableCollection<Course> CoursesCanHelpWith { get; set; }
        public ObservableCollection<Course> CoursesNeedHelpWith { get; set; }
        public ObservableCollection<Hobby> Hobbies { get; set; }
        public Profile Profile {get; set;}
        public Profile? TempProfile{get;set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(Profile p)
        {
            Profile = p;
            CoursesTaken= new ObservableCollection<Course>(Profile.CourseTaken);
            CoursesCanHelpWith= new ObservableCollection<Course>(Profile.CourseCanHelpWith);
            CoursesNeedHelpWith= new ObservableCollection<Course>(Profile.CourseNeedHelpWith);
            Hobbies = new ObservableCollection<Hobby>(Profile.Hobbies);
            TempProfile=findOldProfile(Profile.User.UserId);
            Ok = ReactiveCommand.Create(() => {
                using(var ressource = new StudyMateDbContext()){
                    var profileServices = new ProfileServices(ressource);
                    profileServices.UpdateProfile(TempProfile,Profile);
                }
             });

        }

        private static Profile? findOldProfile(string UserId){
            using (var ressource = new StudyMateDbContext())
            {
                var searchServices = new SearchServices(ressource);
                return searchServices.GetProfileByUserId(UserId);
            }
        }        
    }
}
