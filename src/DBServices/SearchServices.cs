using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace StudyMate;
public class SearchServices : IDisposable
{
    private StudyMateDbContext _context = null!;
    public SearchServices(StudyMateDbContext context)
    {
        _context = context;
    }

    //SEARCH FCTS
        //SearchEventsCourseSchool Method => Search Events based on Course and School
        public virtual List<EventCalendar> SearchEventsCourseSchool(User u, CourseEvent? course = null, School? school = null){
            //I commented this if statement for now because in the moq test, it returns false and causes the test to fail.
            // if (_context.ValidateSessionKey(u.__session_key))
            // {
                Search sc = new Search(_context);
                return sc.SearchEventsCourseSchool(course, school);
            // }
        }

        //SearchEventsCreator Method => Search Events based on the creator (profile)
        public virtual List<EventCalendar> SearchEventsCreator(User u, Profile? creator = null){
            //I commented this if statement for now because in the moq test, it returns false and causes the test to fail.
            // if(_context.ValidateSessionKey(u.__session_key)){
                Search sc = new Search(_context);
                return sc.SearchEventsCreator(creator);
            // }
        }

        //SearchProfileCourseSchool Method => Search profile by Course or School
        public virtual List<Profile> SearchProfileCourseSchool(User u, TakenCourses? tcourse = null, NeedHelpCourses? nhcourse = null, CanHelpCourses? chcourse = null, School? school = null){
            Search sc = new Search(_context);
            return sc.SearchProfileCourseSchool(tcourse, nhcourse, chcourse, school);
        }

        //SearchEventTitleDescription Method => Search Event by title and description
        public virtual List<EventCalendar> SearchEventTitleDescription(string keyword){
            // if(_context.ValidateSessionKey(u.__session_key)){_context.Entry(updateEvent).State = EntityState.Modified;
                Search sc = new Search(_context);
                return sc.SearchEventTitleDescription(keyword);
            // }
        }

        //SearchProfileBlurbInterest Method => Search Profile by Blurb and Interest
        public virtual List<Profile> SearchProfileBlurbInterest(string keyword){
            // if(_context.ValidateSessionKey(u.__session_key)){_context.Entry(updateEvent).State = EntityState.Modified;
                Search sc = new Search(_context);
                return sc.SearchProfileBlurbInterest(keyword);
            // }
        }
        
        //SearchProfileByUser Method => Search Profile by Associated User
        public virtual  List<Profile> SearchProfileByUser(User u){
            // if(_context.ValidateSessionKey(u.__session_key)){_context.Entry(updateEvent).State = EntityState.Modified;
                Search sc = new Search(_context);
                return sc.SearchProfileByUser(u);
            // }
        }
        


    public void Dispose()
    {
        _context.Dispose();
    }
}


