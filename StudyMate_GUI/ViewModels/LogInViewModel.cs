using StudyMate.Models;
using ReactiveUI;
using System.Reactive;
using StudyMate.Services;
namespace StudyMate.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        public bool IsLoginFailed{get;set;} = false;
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

        public ReactiveCommand<Unit, Unit> Login { get; }

        public ReactiveCommand<Unit, Unit>? Register { get; set; }

        private StudyMateDbContext _context;

        public LogInViewModel(StudyMateDbContext db)
        {
            //Enable the register button only when the user has entered a valid username
            var loginEnabled = this.WhenAnyValue(
                x => x.Username,
                (username) => !string.IsNullOrWhiteSpace(username));


            //Create the command to bind to the login and register buttons. Enable it only when loginEnabled is set to true.
            Login = ReactiveCommand.Create(() => { LoginUser(); }, loginEnabled);
            _context = db;

        }

        public User? User { get; private set; }
        public User LoginUser()
        {
            UserServices userServices = new UserServices(_context);
            try {
                User = userServices.Login(Username, Password);
            }
            catch {
                return null;
            }
            return this.User;
        }

    }
}