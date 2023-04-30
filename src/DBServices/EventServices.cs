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
        //CreateEvent Method => Create an event
        public virtual void CreateEvent(EventCalendar e){
            // Get the event from the database
            __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == e.EventId);
            // If the event already exists, it will not be added to the database.
            if (__trackedEvent != null)
            {
                System.Console.WriteLine("This event already exist in the database.");
            }else{
                __trackedEvent=e;
                var schoolService=new SchoolServices(_context);
                schoolService.AddSchool(__trackedEvent.School);
                var courseService=new CourseServices(_context);
                courseService.CheckCoursesEvent(__trackedEvent.EventCourse);
                var profileService=new ProfileServices(_context);
                profileService.CheckParticipants(__trackedEvent.EventProfile);
                if (ProfileServices.__trackedProfile is not null)
                {
                    __trackedEvent.Creator=ProfileServices.__trackedProfile;
                }
                _context.Events!.Add(__trackedEvent);
                _context.SaveChanges(); 
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(string eventId){
            // Get the event from the database
            __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == eventId);
            // If the event already exists, then delete it.
            if (__trackedEvent != null)
            {
                _context.Events!.Remove(__trackedEvent);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The profile you are trying to delete does not exist.");
            }
        }

        public virtual void AddParticipant(EventCalendar ev, Profile profile){
            // Get the event from the database
            __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == ev.EventId);
            ProfileServices.__trackedProfile = _context.Profiles?.SingleOrDefault(p => p.ProfileId == profile.ProfileId);
            // If the event already exists, then delete it.
            if (__trackedEvent != null && ProfileServices.__trackedProfile != null)
            {
                _context.EventProfiles!.Add(new EventProfile( __trackedEvent,ProfileServices.__trackedProfile));
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The profile you are trying to delete does not exist.");
            }
        }

        //EditEvent Method => Edit an event
         public virtual void UpdateEvent(EventCalendar eventToUpdata)
        {
            // Get the event from the database
            __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == eventToUpdata.EventId);
            // If the Event already exists, it will be updated.
            if (__trackedEvent != null)
            {
                __trackedEvent=eventToUpdata;
                var schoolService=new SchoolServices(_context);
                var courseService=new CourseServices(_context);
                foreach (var item in __trackedEvent.EventCourse)
                {
                    courseService.AddCourse(new Course(item.CourseId,item.CourseName));
                }
                // schoolService.UpdateSchool(__trackedEvent.School);
                // _context.Events!.Update(__trackedEvent);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The event you are trying to update does not exist.");
            }
        }
        
        // //AddParticipant => Add participant to event
        // public virtual void AddParticipant(EventCalendar eventC, Profile participant){
        //     __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == eventC.EventId);
        //     if(__trackedEvent != null){
        //         if(__trackedEvent.Participants.Any(p => p.ProfileId != participant.ProfileId)){
        //             __trackedEvent.AddParticipant(participant);
        //             participant.ParticipatingEvents.Add(__trackedEvent);    
        //         }
        //     }
        //     else{
        //         throw new ArgumentException("Event doesn't exist. Create it");
        //     }
        // }

        // //RemoveParticipant => Remove participant to event
        // public virtual void RemoveParticipant(EventCalendar eventC, Profile participant){
            
        //     __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == eventC.EventId);
        //     if(__trackedEvent != null){
        //         if(__trackedEvent.Participants.Any(p => p.ProfileId == participant.ProfileId)){
        //             __trackedEvent.RemoveParticipant(participant);
        //             participant.ParticipatingEvents.Add(__trackedEvent);                   
        //         }
        //     }
        //     else{
        //         throw new ArgumentException("Event doesn't exist. Create it");
        //     }
        // }
}


