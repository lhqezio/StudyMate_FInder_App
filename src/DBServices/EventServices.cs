// namespace StudyMate;
// public class EventServices
// {
//     private StudyMateDbContext _context = null!;
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
//     public void AddEvent(User u, List<Profile> participants,string title,string description,DateTime date,string location,string courses)
//     {
//         var e = new Event(Guid.NewGuid().ToString(),u.Id,title,description,date,location,courses);
//         participants.Count();
//         e.Participant = participants;
//         foreach (var p in participants)
//         {
//             p.Events.Add(e);
//         }
//         _context.Events.Add(e);
//     }
//     public void DeleteEvent(User u, Event e)
//     {
//         if(u.Id != e.CreatorId){
//             return;
//         }
//         _context.Events.Remove(e);
//     }
//     public void UpdateEvent(User u, Event e)
//     {
//         if(u.Id != e.CreatorId){
//             return;
//         }
//         _context.Events.Update(e);
//     }
//     public List<Event> GetAllMyEvents(Profile p)
//     {
//         var profileId = p.ProfileId;
//         return _context.Events.Where(e => e.Participant.Any(p => p.ProfileId == profileId))
//                .ToList();
//     }
//     public void MarkAttending(Profile p, Event e)
//     {
//         if(e.Participant.Any(c => c.ProfileId == p.ProfileId)){
//             return;
//         }
//         e.Participant.Add(p);
//         p.Events.Add(e);
//     }
    
//     public Event GetEventById(string id)
//     {
//         return _context.Events.SingleOrDefault(e => e.EventId == id);
//     }
// }
