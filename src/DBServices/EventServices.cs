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
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e){
            if(_context.Events!.Contains(e) == null){ //Make sure the event doesn't already exist
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
        public virtual EventCalendar CreateEvent(string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, string location, string subjects, List<Course> courses, School school){
            EventCalendar newEvent = new EventCalendar(Guid.NewGuid().ToString(), title, creator, participants, date, description, location, subjects, courses, school);
            this.AddEvent(newEvent);
            return newEvent;
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar eventToDelete, Profile u){
            if(u.ProfileId == eventToDelete.CreatorId){ //Check to make sure it's only the creator that can delete the event
                _context.Events!.Remove(eventToDelete);
            }
            _context.SaveChanges();
        }

        //EditEvent Method => Edit an event
        public virtual void EditEvent(EventCalendar eventToUpdate, Profile u){
            if(u.ProfileId == eventToUpdate.CreatorId){ //Check to make sure it's only the creator that can delete the event
                _context.Events!.Update(eventToUpdate);
            }
            _context.SaveChanges();
        }
        

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(EventCalendar eventC, Profile participant){
            if(eventC.Participants.Any(p => p.ProfileId != participant.ProfileId)){
                eventC.AddParticipant(participant);
                participant.ParticipatingEvents.Add(eventC);    
            }
        }

        //RemoveParticipant => Remove participant to event
        public virtual void RemoveParticipant(EventCalendar eventC, Profile participant){
            if(eventC.Participants.Any(p => p.ProfileId == participant.ProfileId)){
                eventC.RemoveParticipant(participant);
                participant.ParticipatingEvents.Add(eventC);                   
            }
        }
}


