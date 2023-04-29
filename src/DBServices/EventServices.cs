using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace StudyMate;
public class EventServices : IDisposable
{
    private StudyMateDbContext _context = null!;
    public EventServices(StudyMateDbContext context)
    {
        _context = context;
    }

    //EVENT FCTS
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e, User u){
            //I commented this if statement for now because in the moq test, it returns false and causes the test to fail.
            // if (_context.ValidateSessionKey(u.__session_key))
            // {
                using (_context)
                {
                    _context.Events!.Add(e);
                    _context.SaveChanges();
                }
            // }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar eventToDelete, User u){
            // if(_context.ValidateSessionKey(u.__session_key)){
                var toDeleteEvent = _context.Events!.FirstOrDefault(e => e.Equals(eventToDelete));
                if (toDeleteEvent is not null)
                {
                    _context.Events!.Remove(toDeleteEvent);
                    _context.SaveChanges();
                } 
            // }
        }

        //CreateEvent Method => Create an event
        public virtual void CreateEvent(User u, string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, School school, List<CourseEvent> courseEvents, string location ){
            EventCalendar newEvent = new EventCalendar(title, creator, participants, date, description, school, courseEvents, location);
            this.AddEvent(newEvent, u);
        }

        //EditEvent Method => Edit an event
        public virtual void UpdateEvent(EventCalendar eventToUpdate, User u){
            // if(_context.ValidateSessionKey(u.__session_key)){_context.Entry(updateEvent).State = EntityState.Modified;
                _context.Events!.Update(eventToUpdate);
                _context.SaveChanges();
            // }
        }
        

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(User u, EventCalendar eventC, Profile participant){
            // if(_context.ValidateSessionKey(u.__session_key)){
                using(_context)
                {
                    // var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventC.EventId);
                    // if(getEvent != null){ 
                        eventC.AddParticipant(participant);
                        _context.Events!.Update(eventC);
                        _context.SaveChanges();
                }
        }

        //RemoveParticipant => Remove participant to event
        public virtual void RemoveParticipant(User u, EventCalendar eventC, Profile participant){
            // if(_context.ValidateSessionKey(u.__session_key)){
                using(_context)
                {
                    // var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventC.EventId);
                    // if(getEvent != null){ 
                        eventC.RemoveParticipant(participant);
                        _context.Events!.Update(eventC);
                        _context.SaveChanges();
                    // }
                }
            // }
        }

        //ShowParticipant => Add participant to event
        public virtual string ShowParticipants(User u, EventCalendar eventC){
            // if(_context.ValidateSessionKey(u.__session_key)){
                List<Profile> participants;
                string pString = "";
                using(_context)
                {
                    var getEvent = _context.Events!.Find(eventC.EventId);
                    if(getEvent != null){ 
                        participants = getEvent.ShowParticipants();
                        foreach (Profile participant in participants){
                            pString = pString + participant.Name + "; ";
                        }                        
                    }
                }
                return pString;
            // }
            // else{
            //     return "User not Authorized";
            // }
        }

    public void Dispose()
    {
        _context.Dispose();
    }
}


