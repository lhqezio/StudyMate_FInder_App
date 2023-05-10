using System.Reactive;
using StudyMate.Models;
using ReactiveUI;
using StudyMate.Services;

namespace StudyMate.ViewModels
{
    public class EventEditViewModel : ViewModelBase
    {

        public Event Event { get; set; }
        private StudyMateDbContext _context;
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public EventEditViewModel(Event e, StudyMateDbContext db)
        {
            Event = e;

            Ok = ReactiveCommand.Create(() => { });

        }
    }
}
