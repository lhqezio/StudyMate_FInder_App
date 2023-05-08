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

    public Event? GetEventByTitle(string eventTitle){
        var query = _context.StudyMate_Events?
                                .Include( e => e.Creator)
                                .Include( e => e.School)
                                .Include( e => e.Courses)
                                .Include( e => e.Participants)
                                .Where(e => e.Title.Equals(eventTitle))
                                .ToList<Event>();
            
        Event? trackedEvent = query.Any() ? query.FirstOrDefault() : null;
        return trackedEvent;
    }

    public Profile? GetProfiletByUserId(string userId){
        var queryProfile = _context.StudyMate_Profiles?
                                    .Include( p => p.CourseCanHelpWith)
                                    .Include( p => p.CourseNeedHelpWith)
                                    .Include( p => p.CourseTaken)
                                    .Include( p => p.CreatorEvents)
                                    .Include( p => p.Hobbies)
                                    .Include( p => p.ParticipantEvents)
                                    .Include( p => p.School)
                                    .Include( p => p.User)
                                    .Where( p => p.User.UserId.Equals(userId))
                                    .ToList<Profile>();
        Profile? trackedProfile = queryProfile.Any() ? queryProfile.FirstOrDefault() : null;
        return trackedProfile;
    }

    
    //EVENT FCTS
        //CreateEvent Method => Create an event
        public virtual void CreateEvent(Event newEvent){
                // Get the event from the database
            Event? trackedEvent = GetEventByTitle(newEvent.Title);
                // If the event already exists, it will not be added to the database.
            if (trackedEvent == null)
            {
                var existingUser = _context.StudyMate_Users.Find(newEvent.Creator.User.UserId);
                if (existingUser != null)
                {
                    newEvent.Creator.User = existingUser;
                }               
                _context.StudyMate_Events!.Add(newEvent);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("This event already exist in the database."); //Will be changed to a raised error to be displayed to the user
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(Event eventToDelete){
            // Get the event from the database
            Event? trackedEvent = GetEventByTitle(eventToDelete.Title);
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
            Event? trackedEvent = GetEventByTitle(ev.Title);
            // If the event already exists, then delete it.
            if (trackedEvent != null){
                    trackedEvent.AddParticipant(profile);
                    _context.SaveChanges();
            }else{
                System.Console.WriteLine("The event does not exist."); //Will be changed to a raised error to be displayed to the user
            }
        }

        //RemoveParticpant Method => Add one person (profile) in the participant list
        public virtual void RemoveParticipant(Event ev, Profile profile){
            // Get the event from the database
            Event? trackedEvent = GetEventByTitle(ev.Title);
            // If the event already exists, then delete it.
            if (trackedEvent != null)
            {   
                trackedEvent.RemoveParticipant(profile);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The event does not exist."); //Will be changed to a raised error to be displayed to the user
            }
        }


        //ShowParticipant Method => Return a List<String> representing all participants' name of a certain event 
        public virtual List<String> ShowParticipants(Event ev){
            Event? trackedEvent = GetEventByTitle(ev.Title);
            return trackedEvent.ShowParticipants();
        }

        //EditEvent Method => Edit an event
         public virtual void EditEvent(Event eventToChange, Event updatedEvent, User user)
        {
            // Get the event related profile from the database
            Event? trackedEvent = GetEventByTitle(eventToChange.Title);
            Profile? trackedProfile = GetProfiletByUserId(user.UserId);
            
            // If the Event already exists, it will be updated.
            if(trackedEvent != null){
                if(trackedProfile.ProfileId.Equals(trackedEvent.Creator.ProfileId)){
                    trackedEvent = updatedEvent;
                    _context.StudyMate_Events!.Update(trackedEvent);    
                    _context.SaveChanges();
                }else{
                    System.Console.WriteLine("You are not authorized to edit this event.");                    
                }
            }
            else{
                System.Console.WriteLine("The event you are trying to update does not exist.");
            }
        }
}


