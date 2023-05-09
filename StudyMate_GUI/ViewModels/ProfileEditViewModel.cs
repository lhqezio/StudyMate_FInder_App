using System.Reactive;
using StudyMate.Models;
using ReactiveUI;

namespace StudyMate.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(Profile p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => { });

        }


        
    }
}
