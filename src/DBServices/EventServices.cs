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
    
    private EventServices(StudyMateDbContext context)
    {
        _context = context;
    }

    //EVENT FCTS
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e, User u){
            // if(_context.ValidateSessionKey(u.__session_key)){
                _context.Events!.Add(e);
                _context.SaveChanges();
            // }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar eventToDelete, User u){
            // if(_context.ValidateSessionKey(u.__session_key)){ 
                var getEvent = _context.Events.SingleOrDefault(e => e.EventId == eventToDelete.EventId);
                _context.Events!.Remove(getEvent);
                _context.SaveChanges();
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
                //var getEvent = _context.Events.SingleOrDefault(e => e.EventId == oldEvent.EventId);
                 
                _context.Entry(eventToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            // }
        }
        

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(User u, EventCalendar e, Profile participant){
            // if(_context.ValidateSessionKey(u.__session_key)){
                e.AddParticipant(participant);
                _context.SaveChanges();
            // }
        }

        //RemoveParticipant => Add participant to event
        public virtual void RemoveParticipant(User u, EventCalendar e, Profile participant){
            // if(_context.ValidateSessionKey(u.__session_key)){
                e.RemoveParticipant(participant);
                _context.SaveChanges();
            // }
        }

        //ShowParticipant => Add participant to event
        public virtual string ShowParticipants(User u, EventCalendar e){
            // if(_context.ValidateSessionKey(u.__session_key)){
                List<Profile> participants = e.ShowParticipants();
                string pString = "";
                foreach (Profile participant in participants){
                    pString = pString + participant.Name + "; ";
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
