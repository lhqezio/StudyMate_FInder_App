using System;
using System.Reactive.Linq;
using ReactiveUI;
using StudyMate.Models;
using System.Reactive;
using StudyMate.Services;

namespace StudyMate.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        private Boolean _visibleNavigation;
        User? LoggedInUser;
        StudyMateDbContext context = new StudyMateDbContext();
        public Boolean VisibleNavigation
        {
            get => _visibleNavigation;
            private set => this.RaiseAndSetIfChanged(ref _visibleNavigation, value);
        }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public ReactiveCommand<Unit, Unit> Profile { get; }
        public ReactiveCommand<Unit, Unit> NewEvent { get; }
        public ReactiveCommand<Unit, Unit> Search { get; }
        public ReactiveCommand<Unit, Unit> Message { get; }
        public ReactiveCommand<Unit, Unit> Logout { get; }

        public MainWindowViewModel()
        {
            Profile = ReactiveCommand.Create(() => {ShowPersonalProfile();});
            NewEvent =  ReactiveCommand.Create(() => {CreateEvent();});
            Search  = ReactiveCommand.Create(() => {OpenSearch();});
            Message = ReactiveCommand.Create(() => {OpenMessages();});
            Logout = ReactiveCommand.Create(() => {ShowLogin();});
            ShowRegister();
        }

        private void ShowLogin(){
            VisibleNavigation = false;

            LogInViewModel vm = new LogInViewModel(context);
            vm.Register = ReactiveCommand.Create(() => {ShowRegister();});
            vm.Login.Subscribe(x => {PrepareMainPage(vm.LoginUser());});
            Content = vm;
        }

        private void ShowRegister(){
            System.Console.WriteLine("ShowRegister");
            VisibleNavigation = false;
            var vm = new RegisterViewModel(context);
            vm.Register.Subscribe(x => {PrepareMainPage(vm.RegisterUser());});
            vm.Login = ReactiveCommand.Create(() => {ShowLogin();});
            Content = vm;
        }

        public void PrepareMainPage(User u){
            VisibleNavigation = true;
            LoggedInUser = u;
            ShowPersonalProfile();
        }

        //Show profile of logged in user
        private void ShowPersonalProfile()
        {
            if (LoggedInUser == null)
            {
                throw new Exception("User not logged in");
            }
            Profile p = LoggedInUser.Profile;
            if (p == null)
            {
                throw new Exception("User does not have a profile");

            }
            DisplayProfile(p);
        }

        //Show profile of a specified user
        private void DisplayProfile(Profile p)
        {
            Content = new ProfileDisplayViewModel(p);
        }

        //Navigate to edit profile view from profile display view
        public void EditProfile()
        {
            ProfileDisplayViewModel dispvm = (ProfileDisplayViewModel) Content;
            var vm = new ProfileEditViewModel(dispvm.Profile);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
        }

        //Create and display a new event
        private void CreateEvent()
        {
           DisplayEvent(new Event());
        }

        //Display an existing event
        private void DisplayEvent(Event e){
            Content = new EventDisplayViewModel(e) ;
        }

        //Navigate to edit event view from event display view
        public void EditEvent()
        {
            EventDisplayViewModel dispvm = (EventDisplayViewModel) Content;
            var vm = new EventEditViewModel(dispvm.Event,context);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
        }

        //Navigate to message view
        private void OpenMessages()
        {
            throw new NotImplementedException();
        }

        //Navigate to search view
        private void OpenSearch()
        {
            Content = new SearchViewModel();
        }

    }
}