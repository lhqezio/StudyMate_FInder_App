using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace StudyMate;
public class EventServices
{
    private StudyMateDbContext _context = null!;
    private static EventServices? _instance;
    public static EventServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new EventServices(context);
        }
        return _instance;
    }
    public EventServices(StudyMateDbContext context)
    {
        _context = context;
    }

    //EVENT FCTS
        //CreateEvent Method => Create an event
        public virtual void CreateEvent(Event newEvent){
                // Get the event from the database
            var trackedEvent = _context.StudyMate_Events?.FirstOrDefault(ev => ev.EventId == newEvent.EventId);
                // If the event already exists, it will not be added to the database.
            if (trackedEvent == null)
            {               
                _context.StudyMate_Events!.Add(newEvent);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("This event already exist in the database."); //Will be changed to a raised error to be displayed to the user
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(Event ev){
            // Get the event from the database
            var trackedEvent = _context.StudyMate_Events?.SingleOrDefault(e => e.EventId == ev.EventId);
            // If the event already exists, then delete it.
            if (trackedEvent != null)
            {
                _context.StudyMate_Events!.Remove(trackedEvent);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The event you are trying to delete does not exist."); //Will be changed to a raised error to be displayed to the user
            }
        }

        //AddParticpant Method => Add one person (profile) in the participant list
        public virtual void AddParticipant(Event ev, Profile profile){
            // Get the event from the database
            var trackedEvent = _context.StudyMate_Events?.SingleOrDefault(e => e.EventId == ev.EventId);
            // If the event already exists, then delete it.
            if (trackedEvent != null){
                    trackedEvent.AddParticipant(profile);
                    _context.SaveChanges();
            }else{
                System.Console.WriteLine("The event does not exist."); //Will be changed to a raised error to be displayed to the user
            }
        }

        //RemoveParticpant Method => Add one person (profile) in the participant list
        public virtual void RemoveParticpant(Event ev, Profile profile){
            // Get the event from the database
            var trackedEvent = _context.StudyMate_Events?.SingleOrDefault(e => e.EventId == ev.EventId);
            // If the event already exists, then delete it.
            if (trackedEvent != null)
            {   
                trackedEvent.RemoveParticipant(profile);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The event does not exist."); //Will be changed to a raised error to be displayed to the user
            }
        }

        //GetParticipant Method => Return a List<Profile> representing all participant of a certain event 
        public virtual List<Profile> GetParticipants(Event ev){
            var trackedEvent = _context.StudyMate_Events?.SingleOrDefault(e => e.EventId == ev.EventId);
            return trackedEvent.Participants;
        }


        //ShowParticipant Method => Return a List<String> representing all participants' name of a certain event 
        public virtual List<String> ShowParticipants(Event ev){
            var trackedEvent = _context.StudyMate_Events?.SingleOrDefault(e => e.EventId == ev.EventId);
            return trackedEvent.ShowParticipants();
        }

        //EditEvent Method => Edit an event
         public virtual void EditEvent(Event eventToChange, Event updatedEvent)
        {
            // Get the event from the database
            var trackedEvent = _context.StudyMate_Events?.SingleOrDefault(e => e.EventId == eventToChange.EventId);
            // If the Event already exists, it will be updated.
            if(trackedEvent != null){
                _context.StudyMate_Events!.Update(trackedEvent);
                _context.SaveChanges();
            }
            else{
                System.Console.WriteLine("The event you are trying to update does not exist.");
            }
        }
}


