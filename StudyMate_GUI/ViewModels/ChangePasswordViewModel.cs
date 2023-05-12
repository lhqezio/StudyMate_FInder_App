using System.Collections.Generic;
using StudyMate.Models;
using StudyMate.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using Avalonia.Collections;
using System.Reactive;

namespace StudyMate.ViewModels
{
    public class ChangePasswordViewModel : ViewModelBase
    {
        public ChangePasswordViewModel(Profile p)
        {
            User = p.User;
            Change = ReactiveCommand.Create(() => {ChangeUserPassword();});
        }
        public ReactiveCommand<Unit, Unit> Change { get; }
        public User User { get; }
        private string _oldPassword;
        public string OldPassword
        {
            get => _oldPassword;
            set => this.RaiseAndSetIfChanged(ref _oldPassword, value);
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set => this.RaiseAndSetIfChanged(ref _newPassword, value);
        }
        public void ChangeUserPassword(){
            using(var db = new StudyMateDbContext()){
                var userServices = new UserServices(db);
                userServices.ChangePassword(User.Username,OldPassword,NewPassword);
            }
        }
    }
}