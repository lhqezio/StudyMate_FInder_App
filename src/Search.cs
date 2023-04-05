//This class takes of searching. It uses REGEX to find the profile that user wants to see.
//Its constructor takes as input a DatabaseReader object and 
using System.Collections.Generic;
using System;

namespace StudyMate
{
    public class Search
    {
        //Properties
        
        // Dtbcontext needed
        public Search(){

        }

        public List<EventCalendar> searchEventsByCourseProgramSchool(string course, string program, string school){
            var events = /*dtb*/.EventCalendar
                        .Where(e => e.Course == course || e.Program == program || e.School == school)
                        .ToList();

            return events;
        }

        public List<User> FindUsersByCourseProgramSchool(string course, string program, string school)
        {
            var users = /*dtb*/.Users
                        .Where(u => u.Course == course || u.Program == program || u.School == school)
                        .ToList();

        return users;
        }

        public List<EventCalendar> FindEventsByKeyword(string keyword)
        {
            var events = /*dtb*/.Events
                .Where(e => e.Title.Contains(keyword) || e.Description.Contains(keyword))
                .ToList();

            return events;
        }

        public List<User> FindUsersByKeyword(string keyword)
        {
            var users = /*dtb*/.Users
                .Where(u => u.Blurb.Contains(keyword) || u.Interests.Contains(keyword))
                .ToList();

            return users;
        }
    }
}