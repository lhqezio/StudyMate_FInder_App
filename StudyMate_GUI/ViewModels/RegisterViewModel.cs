using StudyMate.Models;
using ReactiveUI;
using System.Reactive;
using StudyMate.Services;
namespace StudyMate.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {

        public string _username;
        public string _password;
        public string _email;
        public string Username
        {
            get => _username;
            private set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        public string Password 
        {
            get => _password;
            private set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string Email
        {
            get => _email;
            private set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        public ReactiveCommand<Unit, Unit> Login { get;set; }

        public ReactiveCommand<Unit, Unit> Register { get; }


        public RegisterViewModel()
        {
            //Enable the register button only when the user has entered a valid username
            var loginEnabled = this.WhenAnyValue(
                x => x.Username,
                x => !string.IsNullOrWhiteSpace(x));

            //Create the command to bind to the login and register buttons. Enable it only when loginEnabled is set to true.
            Register = ReactiveCommand.Create(() => {RegisterUser();}, loginEnabled);
            
        }

        public User? User { get; private set;}
        public User RegisterUser(){
            StudyMateDbContext context = new StudyMateDbContext();
            using (context)
            {
                UserServices userServices = new UserServices(context);
                User = userServices.Register(Username, Password, Email);
                return this.User;
            }
        }
    }
}