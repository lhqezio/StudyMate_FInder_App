using System.Linq;
using System.Reflection.Emit;
//This class takes of searching. It uses REGEX to find the profile that user wants to see.
//Its constructor takes as input a DatabaseReader object and 

namespace StudyMate
{
    public class Search
    {
        //Properties
        private static Search? _instance;
        private StudyMateDbContext _context = null!;

        private Search(){}

        public static Search getInstance(){
            if(_instance is null){
                _instance = new Search();
            }
            return _instance;
        }

        //Constructor
        public Search(StudyMateDbContext context){
               _context = context;
        }

        //SearchEventsCourseSchool
        public List<EventCalendar> SearchEventsCourseSchool(CourseEvent? course = null, School? school = null)
        {
            var events = _context.Events!
                        .Where(e => e.CourseEvents.Contains(course!) || e.Schools.Contains(school!))
                        .ToList();

           return events;
        }

        //SearchProfileCourseSchool
        public List<Profile> SearchProfileCourseSchool(CourseEvent? course = null, School? school = null)
        {
            var events = _context.Profiles!
                        .Where(p => p..Contains(course!) || e.Schools.Contains(school!))
                        .ToList();

           return events;
        }

        public List<Profile> SearchProfileByCourseProgramSchool(Courses? course = null, string? program = null, string? school = null)
        {
            var profiles = _context.Profiles
                        .Where(p => p.TakenCourses.Where(tc => tc.Course.CompareTo(course)) || p.CanHelpCourses.Contains((Courses)course) || p.NeedHelpCourses.Contains((Courses)course) || p.Program == program || p.School == school)
                        .ToList();

               return profiles;
           }

           public List<EventCalendar> SearchEventsByKeyword(string keyword)
           {
               var events = _context.Events
               .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
                 .ToList();

             return events;
         }

         public List<UserDB> SearchUsersByKeyword(string keyword)
         {
             var users = _context.Users
                 .Where(u => u.Username.Contains(keyword) || u.Email.Contains(keyword))
                 .ToList();

             return users;
         }

         public List<Profile> SearchProfileByKeyword(string keyword)
         {
             var profiles = _context.Profiles
                 .Where(p => p.Name.Contains(keyword) || p.Age.ToString().Contains(keyword) || p.School.Contains(keyword) || p.Program.Contains(keyword) || p.PersonalDescription.Contains(keyword))
                 .ToList();

             return profiles;
         }

        public List<Profile> SearchProfileByHobbies(Interests hobbies)
         {
             var profiles = _context.Profiles
                 .Where(p => p.Hobbies.Contains(hobbies))
                 .ToList();

             return profiles;
         }
     }
 }
