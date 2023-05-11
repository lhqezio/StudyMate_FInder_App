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
        public EventEditViewModel(Event e, StudyMateDbContext db,User u)
        {
            Event = e;
            var TempEvent = findOldEvent(Event.EventId);
            Ok = ReactiveCommand.Create(() => {
                using(var ressource = new StudyMateDbContext()){
                    var eventServices = new EventServices(ressource);
                    eventServices.EditEvent(TempEvent,Event,u);
                }
            });
        }

        private static Event? findOldEvent(int EventId){
            using (var ressource = new StudyMateDbContext())
            {
                var searchServices = new SearchServices(ressource);
                return searchServices.GetEventById(EventId);
            }
        }
    }
}
