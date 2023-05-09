using System.Reactive;
using StudyMate.Models;
using ReactiveUI;

namespace StudyMate.ViewModels
{
    public class EventEditViewModel : ViewModelBase
    {
        
        public Event Event {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public EventEditViewModel(Event e)
        {
            Event = e;

            Ok = ReactiveCommand.Create(() => { });

        }


        
    }
}
