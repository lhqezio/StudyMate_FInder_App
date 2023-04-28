using StudyMate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyMate
{

    public class StudyMateService : IDisposable
    {

        private static readonly Lazy<StudyMateService> _instance = new Lazy<StudyMateService>(() => new StudyMateService());
        public static StudyMateService Instance => _instance.Value;

        private StudyMateDbContext _context;
        private StudyMateService()
        {
            _context = new StudyMateDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //EVENT FCTS
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e, User u)
        {
            if (ValidateSessionKey(u.__session_key))
            {
                _context.Events!.Add(e);
                _context.SaveChanges();
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar e, User u)
        {
            if (ValidateSessionKey(u.__session_key))
            {
                _context.Events!.Remove(e);
                _context.SaveChanges();
            }
        }

        //CreateEvent Method => Create an event
        public virtual void CreateEvent(User u, string title, Profile profileCreator, List<Profile> participants, DateTimeOffset date, string description, School school, List<CourseEvent> courseEvents, string location)
        {
            EventCalendar newEvent = new EventCalendar(title, profileCreator, participants, date, description, school, courseEvents, location);
            AddEvent(newEvent, u);
        }

        //EditEvent Method => Edit an event
        public virtual void EditEvent(User u, EventCalendar editEvent, string? title = null, List<Profile>? participants = null, DateTimeOffset? date = null, School? school = null, List<CourseEvent>? courseEvents = null, string? location = null, bool? sent = null)
        {
            if (ValidateSessionKey(u.__session_key))
            {
                if (title != null)
                {
                    editEvent.Title = title;
                }
                if (participants != null)
                {
                    editEvent.Participants = participants;
                }
                if (date != null)
                {
                    editEvent.Date = (DateTimeOffset)date;
                }
                if (school != null)
                {
                    editEvent.School = school;
                }
                if (courseEvents != null)
                {
                    editEvent.CourseEvents = courseEvents;
                }
                if (location != null)
                {
                    editEvent.Location = location;
                }
                if (sent != null)
                {
                    editEvent.IsSent = (bool)sent;
                }
                _context.SaveChanges();
            }
        }

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(User u, EventCalendar e, Profile p)
        {
            if (ValidateSessionKey(u.__session_key))
            {
                e.AddParticipant(p);
                _context.SaveChanges();
            }
        }

        //RemoveParticipant => Add participant to event
        public virtual void RemoveParticipant(User u, EventCalendar e, Profile p)
        {
            if (ValidateSessionKey(u.__session_key))
            {
                e.RemoveParticipant(p);
                _context.SaveChanges();
            }
        }

        //ShowParticipant => Add participant to event
        public virtual string ShowParticipants(User u, EventCalendar e)
        {
            if (ValidateSessionKey(u.__session_key))
            {
                List<Profile> participants = e.ShowParticipants();
                string pString = "";
                foreach (Profile participant in participants)
                {
                    pString = pString + participant.Name + "; ";
                }
                return pString;
            }
            else
            {
                return "User not Authorized";
            }
        }


        public virtual string GenerateSessionKey(string userId)
        {
            return _context.GenerateSessionKey(userId);
        }

        public virtual bool ValidateSessionKey(string sessionKey)
        {
            return _context.ValidateSessionKey(sessionKey);
        }

        public virtual User Login(string username, string password)
        {
            return _context.Login(username, password);
        }

        public virtual User LoginFromSessionKey(string session_key)
        {
            return _context.LoginFromSessionKey(session_key);
        }

        public virtual User Register(string username, string email, string password)
        {
            return _context.Register(username, email, password);
        }

        public virtual void Logout(string sessionKey)
        {
            _context.Logout(sessionKey);
        }
        public virtual void ChangePassword(string sessionKey, string newPassword)
        {
           _context.ChangePassword(sessionKey, newPassword);
        }
    }
}
