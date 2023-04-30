using System.Linq;
using System.Reflection.Emit;

//This class takes of searching. It uses REGEX to find the profile that user wants to see.
//Its constructor takes as input a DatabaseReader object and 
namespace StudyMate
{   
    public class Search{

        private StudyMateDbContext _context = null!;
        
        private Search(){}

        //Constructor
        public Search(StudyMateDbContext context){
               _context = context;
        }

        //EVENT
        //SearchEventsCourseSchool
        public List<EventCalendar> SearchEventsCourseSchool(School sch = null, Course course = null)
        {
            var events = _context.Events!
                        .Where(e => e.Courses.Contains(course) || e.School.Equals(sch))
                        .ToList();

           return events;
        }

        //SearchEventsCreator
        public List<EventCalendar> SearchEventsCreator(string creatorId)
        {
            var events = _context.Events!
                        .Where(e => e.CreatorId.Equals(creatorId))
                        .ToList();

           return events;
        }

        //SearchEventTitleDescription
        public List<EventCalendar> SearchEventTitleDescription(string keyword)
        {
               var events = _context.Events!
               .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
                 .ToList();

             return events;
        }

        //PROFILE
        //SearchProfileCourseSchool
        public List<Profile> SearchProfileCourseSchool(School sch = null, Course course = null)
        {
            var events = _context.Profiles!
                        .Where(p => p.CourseCanHelpWith.Contains(course!) || p.CourseNeedHelpWith.Contains(course!) || p.CourseTaken.Contains(course!) || p.School.Equals(sch))
                        .ToList();

           return events;
        }

        //SearchProfileBlurbInterest
        public List<Profile> SearchProfileBlurbInterest(string keyword = null, Hobby hobby = null)
        {
             var profiles = _context.Profiles!
                 .Where(p => p.PersonalDescription.Contains(keyword) || p.Hobbies.Contains(hobby))
                 .ToList();
             return profiles;
        }

        //SearchProfileByUser
        public Profile SearchProfileByUser(string userId)
        {
             var profiles =  _context.Profiles!.SingleOrDefault(p => p.UserId == userId);
            return profiles;
        }
     }
 }
