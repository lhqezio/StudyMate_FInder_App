using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudyMate.Models;

namespace StudyMate.ViewModels
{
    public class ProfileDisplayViewModel : ViewModelBase
    {
        public ProfileDisplayViewModel(Profile p)
        {
            Profile = p;
        }

        public Profile Profile { get; }
    }
}