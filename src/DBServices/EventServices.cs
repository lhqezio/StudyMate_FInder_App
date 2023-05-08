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

    public Event? GetEventById(int EventId){
        var query = _context.StudyMate_Events?
                                .Include( e => e.Creator)
                                .Include( e => e.School)
                                .Include( e => e.Courses)
                                .Include( e => e.Participants)
                                .Where(e => e.EventId.Equals(EventId))
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
            var query = _context.StudyMate_Events?
                                .Include( e => e.Creator)
                                .Include( e => e.School)
                                .Include( e => e.Courses)
                                .Include( e => e.Participants)
                                .Where(e => e.Title.Equals(newEvent.Title))
                                .ToList<Event>();
            
        Event? trackedEvent = query.Any() ? query.FirstOrDefault() : null;
                // If the event already exists, it will not be added to the database.
            if (trackedEvent == null)
            {
                var existingUser = _context.StudyMate_Users.Find(newEvent.Creator.User.UserId);
                if (existingUser != null)
                {
                    newEvent.Creator.User = existingUser;
                }       
                //No duplicate school        
                var existingSchool = _context.StudyMate_Schools.FirstOrDefault(s => s.SchoolName == newEvent.School.SchoolName);
                if (existingSchool == null)
                {
                    var newSchool = new School { SchoolName = newEvent.School.SchoolName };
                    _context.StudyMate_Schools.Add(newSchool);
                    newEvent.School = newSchool;
                }
                else
                {
                    newEvent.School = existingSchool;
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
            Event? trackedEvent = GetEventById(eventToDelete.EventId);
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
            Event? trackedEvent = GetEventById(ev.EventId);
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
            Event? trackedEvent = GetEventById(ev.EventId);
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
            Event? trackedEvent = GetEventById(ev.EventId);
            return trackedEvent.ShowParticipants();
        }

        //EditEvent Method => Edit an event
         public virtual void EditEvent(Event eventToChange, Event updatedEvent, User user)
        {
            // Get the event related profile from the database
            Event? trackedEvent = GetEventById(eventToChange.EventId);
            Profile? trackedProfile = GetProfiletByUserId(user.UserId);
            
            // If the Event already exists, it will be updated.
            if(trackedEvent != null){
                if(trackedProfile.ProfileId.Equals(trackedEvent.Creator.ProfileId)){
                    trackedEvent.Title = updatedEvent.Title;
                    trackedEvent.Date = updatedEvent.Date;
                    trackedEvent.Description = updatedEvent.Description;
                    trackedEvent.Location = updatedEvent.Location;
                    trackedEvent.Subjects = updatedEvent.Subjects;
                    var existingSchool = _context.StudyMate_Schools.FirstOrDefault(s => s.SchoolName == updatedEvent.School.SchoolName);
                    if (existingSchool == null)
                    {
                        var newSchool = new School { SchoolName = updatedEvent.School.SchoolName };
                        _context.StudyMate_Schools.Add(newSchool);
                        trackedEvent.School = newSchool;
                    }
                    else
                    {
                        trackedEvent.School = existingSchool;
                    }
                    trackedEvent.IsSent = updatedEvent.IsSent;
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

        public Course GetOrCreateCourseByName(string courseName)
        {
            var existingCourse = _context.StudyMate_Courses.FirstOrDefault(c => c.CourseName.Equals(courseName));

            if (existingCourse != null)
            {
                return existingCourse;
            }
            else
            {
                var newCourse = new Course { CourseName = courseName };
                _context.StudyMate_Courses.Add(newCourse);
                _context.SaveChanges();
                return newCourse;
            }
        }
}


