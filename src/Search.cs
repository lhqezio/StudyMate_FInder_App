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

        private Search()
        {
        }

        public static Search getInstance(){
            if(_instance is null){
                _instance = new Search();
            }
            return _instance;
        }

        public void setStudyMateDbContext(StudyMateDbContext context){
            _context = context;
        }

        public List<EventCalendar> SearchEventsByCourseProgramSchool(string course, string program, string school)
        {
            var events = _context.EventCalendar
                        .Where(e => e.Course == course || e.Program == program || e.School == school)
                        .ToList();

            return events;
        }

        public List<User> SearchUsersByCourseProgramSchool(string course, string program, string school)
        {
            var users = dtb.Users
                        .Where(u => u.Course == course || u.Program == program || u.School == school)
                        .ToList();

            return users;
        }

        public List<EventCalendar> SearchEventsByKeyword(string keyword)
        {
            var events = dtb.Events
                .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
                .ToList();

            return events;
        }

        public List<User> SearchUsersByKeyword(string keyword)
        {
            var users = dtb.Users
                .Where(u => u.Blurb.Contains(keyword) || u.Interests.Contains(keyword))
                .ToList();

            return users;
        }
    }
}
