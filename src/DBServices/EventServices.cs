// using Microsoft.EntityFrameworkCore;
// using System.Linq;
// using System.Reflection.Emit;

// namespace StudyMate;
// public class EventServices
// {
//     private StudyMateDbContext _context = null!;
//     public static EventCalendar? __trackedEvent = new();
//     public static EventProfile? __trackedEventProfile = new();
//     private static EventServices? _instance;
//     public static EventServices getInstance(StudyMateDbContext context)
//     {
//         if (_instance is null)
//         {
//             _instance = new EventServices(context);
//         }
//         return _instance;
//     }
//     public EventServices(StudyMateDbContext context)
//     {
//         _context = context;
//     }

//     //EVENT FCTS
//         //CreateEvent Method => Create an event
//         public virtual void CreateEvent(EventCalendar e){
//             // Get the event from the database
//             __trackedEvent = _context.Events?.SingleOrDefault(ev => ev.EventId == e.EventId);
//             // If the event already exists, it will not be added to the database.
//             if (__trackedEvent != null)
//             {
//                 System.Console.WriteLine("This event already exist in the database.");
//             }else{
//                 __trackedEvent=e;
//                 var schoolService=new SchoolServices(_context);
//                 schoolService.AddSchool(__trackedEvent.School);
//                 var courseService=new CourseServices(_context);
//                 courseService.CheckCoursesEvent(__trackedEvent.EventCourse);
//                 var profileService=new ProfileServices(_context);
//                 profileService.CheckParticipants(__trackedEvent.EventProfile);
//                 ProfileServices.__trackedProfile=_context.Profiles?.SingleOrDefault(p => p.ProfileId == __trackedEvent.CreatorId);
//                 _context.Events!.Add(__trackedEvent);
//                 _context.SaveChanges(); 
//             }
//         }

//         //DeleteEvent Method => Delete event to the list of events
//         public virtual void DeleteEvent(string eventId){
//             // Get the event from the database
//             __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == eventId);
//             // If the event already exists, then delete it.
//             if (__trackedEvent != null)
//             {
//                 _context.Events!.Remove(__trackedEvent);
//                 _context.SaveChanges();
//             }else{
//                 System.Console.WriteLine("The profile you are trying to delete does not exist.");
//             }
//         }

//         public virtual void AddParticipant(EventCalendar ev, Profile profile){
//             //For some reason, the EventProfile entity of the participant gets tracked and causes an exception
//             //I detach the instance of EventProfile that is causing the problem and re-track it later
//             //in this function using the Add method so that only one instance of EventProfile which is the one
//             //of participant is tracked.
//             var eventProfileTrackedEntities=_context.ChangeTracker.Entries<EventProfile>();
//             var entity = eventProfileTrackedEntities.FirstOrDefault(ep => ep.Entity.EventId == ev.EventId && ep.Entity.ProfileId == profile.ProfileId);
//             if (entity != null)
//             {
//                 _context.Entry(entity.Entity).State = EntityState.Detached;
//             }
//             // Get the event from the database
//             __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == ev.EventId);
//             ProfileServices.__trackedProfile = _context.Profiles?.SingleOrDefault(p => p.ProfileId == profile.ProfileId);
//             if (__trackedEvent != null && ProfileServices.__trackedProfile != null)
//             {
//                 __trackedEventProfile=new EventProfile( __trackedEvent,ProfileServices.__trackedProfile);
//                 _context.EventProfiles!.Add(__trackedEventProfile);
//                 _context.SaveChanges();
//             }else{
//                 System.Console.WriteLine("The profile you are trying to delete does not exist.");
//             }
//         }

//         public virtual List<Profile> GetParticipants(String eventId){
//             List<Profile>? profiles=new List<Profile>();
//             __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == eventId);
//             if(__trackedEvent is not null){
//                 List<EventProfile>? eP = _context.EventProfiles?.Where(ep => ep.EventId == __trackedEvent.EventId).ToList();
//                 if (eP is not null)
//                 {
//                     foreach (var item in eP)
//                     {
//                         Profile? profile = _context.Profiles?.SingleOrDefault(p => p.ProfileId == item.ProfileId);
//                         if (profile is not null)
//                         {
//                             profiles.Add(profile);
//                         }
                        
//                     }
//                 }
//             }
//             return profiles;
//         }

//         //UpdateEvent Method => Edit an event
//          public virtual void UpdateEvent(EventCalendar eventToUpdate)
//         {
//             // Get the event from the database
//             __trackedEvent = _context.Events?.SingleOrDefault(e => e.EventId == eventToUpdate.EventId);
//             // If the Event already exists, it will be updated.
//             if (__trackedEvent != null)
//             {
//                 __trackedEvent=eventToUpdate;
//                 var schoolService=new SchoolServices(_context);
//                 var courseService=new CourseServices(_context);
//                 foreach (var item in __trackedEvent.EventCourse)
//                 {
//                     courseService.AddCourse(new Course(item.CourseId,item.CourseName));
//                 }
//                 schoolService.UpdateSchool(__trackedEvent.School);
//                 _context.Events!.Update(__trackedEvent);
//                 _context.SaveChanges();
//             }else{
//                 System.Console.WriteLine("The event you are trying to update does not exist.");
//             }
//         }
// }


