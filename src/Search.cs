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
        public List<Event> SearchEventsCourseSchool(string keyword)
        {
            var events = _context.StudyMate_Events!
                        .Where(e => e.Courses.Any(c => c.CourseName.Contains(keyword)) ||
                                    e.School.SchoolName.Equals(keyword))
                        .ToList();

           return events;
        }

        //SearchEventsCreator
        public List<Event> SearchEventsCreator(string creatorId)
        {
            var events = _context.StudyMate_Events!
                        .Where(e => e.Creator.ProfileId.Equals(creatorId))
                        .ToList();

           return events;
        }

        //SearchEventTitleDescription
        public List<Event> SearchEventTitleDescription(string keyword)
        {
               var events = _context.StudyMate_Events!
               .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
                 .ToList();

             return events;
        }

        //PROFILE
        //SearchProfileCourseSchool
        public List<Profile> SearchProfileCourseSchool(string keyword)
        {
            var events = _context.StudyMate_Profiles!
                        .Where(p => p.CourseCanHelpWith.Any(c => c.CourseName.Contains(keyword)) ||
                                    p.CourseNeedHelpWith.Any(c => c.CourseName.Contains(keyword)) ||
                                    p.CourseTaken.Any(c => c.CourseName.Contains(keyword)) ||
                                    p.School.SchoolName.Equals(keyword))
                        .ToList();
           return events;
        }

        //SearchProfileBlurbInterest
        public List<Profile> SearchProfileBlurbInterest(string keyword)
        {
            var profiles = _context.StudyMate_Profiles!.Where(p => p.PersonalDescription.Contains(keyword) || 
                                                    ( p.Hobbies.Any(h => h.HobbyName.Contains(keyword))))
                                            .ToList();
             return profiles;
        }

        //SearchProfileByUser
        public Profile SearchProfileByUser(string userId)
        {
            List<Profile> profiles =  _context.StudyMate_Profiles!.Where(p => p.User.UserId == userId).ToList();
            if (profiles.Count != 0){
                return profiles[0];
            }   
            return null;
        }
     }
 }
