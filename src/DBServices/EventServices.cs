using Microsoft.EntityFrameworkCore;

namespace StudyMate;
class EventServices
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
    // public virtual void AddEvent(EventCalendar e, Profile u)
    // {
    //     if (_context.ValidateSessionKey(u.__session_key))
    //     {
    //         _context.Events!.Add(e);
    //         _context.SaveChanges();
    //     }
    // }

    // //DeleteEvent Method => Delete event to the list of events
    // public virtual void DeleteEvent(EventCalendar e, Profile u)
    // {
    //     if (_context.ValidateSessionKey(u.__session_key))
    //     {
    //         _context.Events!.Remove(e);
    //         _context.SaveChanges();
    //     }
    // }

    public virtual void UpdateEvent(EventCalendar updateEvent, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            // 0
            _context.Entry(updateEvent).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    //EVENT FCTS
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e, User u){
            if(_context.ValidateSessionKey(u.__session_key)){
                _context.Events!.Add(e);
                _context.SaveChanges();
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar e, User u){
            if(_context.ValidateSessionKey(u.__session_key)){ 
                _context.Events!.Remove(e);
                _context.SaveChanges();
            }
        }

        //CreateEvent Method => Create an event
        public virtual void CreateEvent(User u, string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, School school, List<CourseEvent> courseEvents, string location ){
            EventCalendar newEvent = new EventCalendar(title, creator, participants, date, description, school, courseEvents, location);
            AddEvent(newEvent, u);
        }

        //EditEvent Method => Edit an event
        public virtual void EditEvent(User u, EventCalendar editEvent, string? title = null, List<Profile>? participants = null, DateTimeOffset? date = null, School? school = null, List<CourseEvent>? courseEvents = null, string? location = null, bool? sent = null){
            if(_context.ValidateSessionKey(u.__session_key)){
                if(title != null){
                    editEvent.Title = title;
                }
                if(participants != null){
                    editEvent.Participants = participants;
                }
                if(date != null){
                    editEvent.Date = (DateTimeOffset)date;
                }
                if(school != null){
                    editEvent.School = school;
                }
                if(courseEvents != null){
                    editEvent.CourseEvents = courseEvents;
                }
                if(location != null){
                    editEvent.Location = location;
                }
                if(sent != null){
                    editEvent.IsSent = (bool)sent;
                }
                _context.SaveChanges();
            }
        }

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(User u, EventCalendar e, Profile participant){
            if(_context.ValidateSessionKey(u.__session_key)){
                e.AddParticipant(participant);
                _context.SaveChanges();
            }
        }

        //RemoveParticipant => Add participant to event
        public virtual void RemoveParticipant(User u, EventCalendar e, Profile participant){
            if(_context.ValidateSessionKey(u.__session_key)){
                e.RemoveParticipant(participant);
                _context.SaveChanges();
            }
        }

        //ShowParticipant => Add participant to event
        public virtual string ShowParticipants(User u, EventCalendar e){
            if(_context.ValidateSessionKey(u.__session_key)){
                List<Profile> participants = e.ShowParticipants();
                string pString = "";
                foreach (Profile participant in participants){
                    pString = pString + participant.Name + "; ";
                }
                return pString;
            }
            else{
                return "User not Authorized";
            }
        }

}
