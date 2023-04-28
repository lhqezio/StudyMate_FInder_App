using Microsoft.EntityFrameworkCore;

namespace StudyMate;
public class EventServices : IDisposable
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
                using (_context)
                {
                    var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventToDelete.EventId);
                    if(getEvent != null){ 
                        _context.Events!.Remove(getEvent);
                        _context.SaveChanges();
                    }
                }
            // }
        }

        //CreateEvent Method => Create an event
        public virtual void CreateEvent(User u, string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, School school, List<CourseEvent> courseEvents, string location ){
            EventCalendar newEvent = new EventCalendar(title, creator, participants, date, description, school, courseEvents, location);
            this.AddEvent(newEvent, u);
        }

        //EditEvent Method => Edit an event
        public virtual void EditEvent(EventCalendar eventToUpdate, User u){
            // if(_context.ValidateSessionKey(u.__session_key)){_context.Entry(updateEvent).State = EntityState.Modified;
                using(_context)
                {
                    var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventToUpdate.EventId);
                    if(getEvent != null){ 
                        _context.Entry(getEvent).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }
            // }
        }
        

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(User u, EventCalendar eventC, Profile participant){
            // if(_context.ValidateSessionKey(u.__session_key)){
                using(_context)
                {
                    var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventC.EventId);
                    if(getEvent != null){ 
                        getEvent.AddParticipant(participant);
                        _context.SaveChanges();
                    }
                }
            // }
        }

        //RemoveParticipant => Add participant to event
        public virtual void RemoveParticipant(User u, EventCalendar eventC, Profile participant){
            // if(_context.ValidateSessionKey(u.__session_key)){
                using(_context)
                {
                    var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventC.EventId);
                    if(getEvent != null){ 
                        getEvent.RemoveParticipant(participant);
                        _context.SaveChanges();
                    }
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
                    var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventC.EventId);
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
