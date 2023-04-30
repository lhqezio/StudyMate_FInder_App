// using System.Linq;
// using System.Reflection.Emit;

// //This class takes of searching. It uses REGEX to find the profile that user wants to see.
// //Its constructor takes as input a DatabaseReader object and 
// namespace StudyMate
// {   
//     public class Search{

//         private StudyMateDbContext _context = null!;
        
//         private Search(){}

//         //Constructor
//         public Search(StudyMateDbContext context){
//                _context = context;
//         }

//         //EVENT
//         //SearchEventsCourseSchool
//         public List<EventCalendar> SearchEventsCourseSchool(string courseSchool)
//         {
//             var events = _context.Events!
//                         .Where(e => e.Courses.Contains(courseSchool) || e.School.Equals(courseSchool))
//                         .ToList();

//            return events;
//         }

//         //SearchEventsCreator
//         public List<EventCalendar> SearchEventsCreator(string creatorId)
//         {
//             var events = _context.Events!
//                         .Where(e => e.CreatorId.Equals(creatorId))
//                         .ToList();

//            return events;
//         }

//         //SearchEventTitleDescription
//         public List<EventCalendar> SearchEventTitleDescription(string keyword)
//         {
//                var events = _context.Events!
//                .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
//                  .ToList();

//              return events;
//         }

//         //PROFILE
//         //SearchProfileCourseSchool
//         public List<Profile> SearchProfileCourseSchool(string courseSchool)
//         {
//             var events = _context.Profiles!
//                         .Where(p => p.TakenCourses.Contains(courseSchool!) || p.NeedHelpCourses.Contains(courseSchool!) || p.School.Equals(courseSchool))
//                         .ToList();

//            return events;
//         }

//         //SearchProfileBlurbInterest
//         public List<Profile> SearchProfileBlurbInterest(string keyword)
//         {
//              var profiles = _context.Profiles!
//                  .Where(p => p.PersonalDescription.Contains(keyword) || p.Hobbies.Contains(keyword))
//                  .ToList();

//              return profiles;
//         }

//         //SearchProfileByUser
//         public Profile SearchProfileByUser(string userId)
//         {
//              var profiles =  _context.Profiles!.SingleOrDefault(p => p.UsrId == userId);
//             return profiles;
//         }
//      }
//  }
