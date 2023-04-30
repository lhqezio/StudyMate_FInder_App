using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace StudyMate;
public class EventServices
{
    private StudyMateDbContext _context = null!;
    public static EventCalendar? __trackedEvent = new();
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
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e){
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == e.EventId);
            var __trackedCreator = _context.Set<Profile>().Local.FirstOrDefault(p => p.ProfileId == e.CreatorId);
            if (__trackedCreator != null)
            {
                e.Creator = __trackedCreator;
            }
            if(__trackedEvent == null){ //Make sure the event doesn't already exist
                foreach (var participant in e.Participants)
                {
                    participant.ParticipatingEvents.Add(e);
                }
                _context.Events!.Add(e);
                _context.SaveChanges();    
            }
            else{
                throw new ArgumentException("Event already exists. Either edit it, delete it or create a new one");
            }
        } 
        
        //CreateEvent Method => Create an event
        public virtual void CreateEvent(EventCalendar e){
            // Get the event from the database
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == e.EventId);
            // If the Course already exists, it will not be added to the database.
            if (__trackedEvent != null)
            {
                System.Console.WriteLine("This event already exist in the database.");
            }else{
                __trackedEvent=e;
                var schoolService=new SchoolServices(_context);
                schoolService.AddSchool(__trackedEvent.School);
                _context.Events!.Add(__trackedEvent);
                _context.SaveChanges(); 
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar eventToDelete, Profile u){
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == eventToDelete.EventId);

            if(__trackedEvent != null){
                if(u.ProfileId == __trackedEvent.CreatorId){ //Check to make sure it's only the creator that can delete the event
                    _context.Events!.Remove(__trackedEvent);
                    _context.SaveChanges();
                }
            }
            else{
                throw new ArgumentException("Event doesn't exist. Create it");
            }
        }

        //EditEvent Method => Edit an event
        public virtual void EditEvent(EventCalendar eventToUpdate, Profile u){
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == eventToUpdate.EventId);
            
            if(__trackedEvent != null){ //Make sure the event exists
                if(u.ProfileId == __trackedEvent.CreatorId){ //Check to make sure it's only the creator that can delete the event
                    _context.Events!.Update(__trackedEvent);
                    _context.SaveChanges();
                }
            }
            else{
                throw new ArgumentException("Event doesn't exist. Create it");
            }
        }
        

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(EventCalendar eventC, Profile participant){
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == eventC.EventId);
            if(__trackedEvent != null){
                if(__trackedEvent.Participants.Any(p => p.ProfileId != participant.ProfileId)){
                    __trackedEvent.AddParticipant(participant);
                    participant.ParticipatingEvents.Add(__trackedEvent);    
                }
            }
            else{
                throw new ArgumentException("Event doesn't exist. Create it");
            }
        }

        //RemoveParticipant => Remove participant to event
        public virtual void RemoveParticipant(EventCalendar eventC, Profile participant){
            
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == eventC.EventId);
            if(__trackedEvent != null){
                if(__trackedEvent.Participants.Any(p => p.ProfileId == participant.ProfileId)){
                    __trackedEvent.RemoveParticipant(participant);
                    participant.ParticipatingEvents.Add(__trackedEvent);                   
                }
            }
            else{
                throw new ArgumentException("Event doesn't exist. Create it");
            }
        }
}


