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
        public List<Profile> SearchProfileCourseSchool(TakenCourses? tcourse = null, NeedHelpCourses? nhcourse = null, CanHelpCourses? chcourse = null, School? school = null)
        {
            var events = _context.Profiles!
                        .Where(p => p.TakenCourses.Contains(tcourse!) || p.NeedHelpCourses.Contains(nhcourse!) || p.CanHelpCourses.Contains(chcourse!) || p.School.Equals(school))
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

        //SearchProfileBlurbInterest
        public List<Profile> SearchProfileBlurbInterest(string? keyword = null, InterestsProfile? interestProfile = null)
        {
             var profiles = _context.Profiles!
                 .Where(p => p.PersonalDescription.Contains(keyword!) || p.Hobbies.Contains(interestProfile!))
                 .ToList();

             return profiles;
        }

     }
 }
