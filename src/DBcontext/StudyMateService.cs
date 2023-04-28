using StudyMate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyMate{

    public class StudyMateService{

        private static readonly Lazy<StudyMateService> _instance = new Lazy<StudyMateService>(() => new StudyMateService());
        public static StudyMateService Instance => _instance.Value;

        private StudyMateDbContext _context;
        private StudyMateService(){
            _context = new StudyMateDbContext();
        }

        public void Dispose(){
            _context.Dispose();
        }
        
        //EVENT FCTS
        //AddEvent Method => Add event to the list of events
        public virtual void AddEvent(EventCalendar e, User u){
            if(ValidateSessionKey(u.__session_key)){
                _context.Events!.Add(e);
                _context.SaveChanges();
            }
        }

        //DeleteEvent Method => Delete event to the list of events
        public virtual void DeleteEvent(EventCalendar e, User u){
            if(ValidateSessionKey(u.__session_key)){ 
                _context.Events!.Remove(e);
                _context.SaveChanges();
            }
        }

        //CreateEvent Method => Create an event
        public virtual void CreateEvent(User u, string title, Profile profileCreator, List<Profile> participants, DateTimeOffset date, string description, School school, List<CourseEvent> courseEvents, string location ){
            EventCalendar newEvent = new EventCalendar(title, profileCreator, participants, date, description, school, courseEvents, location);
            AddEvent(newEvent, u);
        }

        //EditEvent Method => Edit an event
        public virtual void EditEvent(User u, EventCalendar editEvent, string? title = null, List<Profile>? participants = null, DateTimeOffset? date = null, School? school = null, List<CourseEvent>? courseEvents = null, string? location = null, bool? sent = null){
            if(ValidateSessionKey(u.__session_key)){
                if(title != null){
                    editEvent.Title = title;
                }
                if(participants != null){
                    editEvent.Participants = participants;
                }
                if(date != null){
                    editEvent.Date = (DateTimeOffset)date;
                }
                if(school != null){
                    editEvent.School = school;
                }
                if(courseEvents != null){
                    editEvent.CourseEvents = courseEvents;
                }
                if(location != null){
                    editEvent.Location = location;
                }
                if(sent != null){
                    editEvent.IsSent = (bool)sent;
                }
                _context.SaveChanges();
            }
        }

        //AddParticipant => Add participant to event
        public virtual void AddParticipant(User u, EventCalendar e, Profile p){
            if(ValidateSessionKey(u.__session_key)){
                e.AddParticipant(p);
                _context.SaveChanges();
            }
        }

        //RemoveParticipant => Add participant to event
        public virtual void RemoveParticipant(User u, EventCalendar e, Profile p){
            if(ValidateSessionKey(u.__session_key)){
                e.RemoveParticipant(p);
                _context.SaveChanges();
            }
        }

        //ShowParticipant => Add participant to event
        public virtual string ShowParticipants(User u, EventCalendar e){
            if(ValidateSessionKey(u.__session_key)){
                List<Profile> participants = e.ShowParticipants();
                string pString = "";
                foreach (Profile participant in participants){
                    pString = pString + participant.Name + "; ";
                }
                return pString;
            }
            else{
                return "User not Authorized";
            }
        }


            public virtual string GenerateSessionKey(string userId)
            {
                // Generate a session key
                string sessionKey = Guid.NewGuid().ToString();

                // Create a new session
                SessionDB session = new SessionDB(sessionKey, userId, DateTime.Now.AddMinutes(30));

                // Add the session to the database
                _context.Sessions!.Add(session);
                _context.SaveChanges();

                return sessionKey;
            }

            public virtual bool ValidateSessionKey(string sessionKey)
            {
                // Get the session from the database
                SessionDB session = _context.Sessions!.FirstOrDefault(s => s.SessionKey == sessionKey)!;

                // If the session doesn't exist, return false
                if (session == null)
                {
                    return false;
                }

                // If the session has expired, return false
                if (session.Expiration < DateTime.Now)
                {
                    return false;
                }

                // If the session is valid, return true
                return true;
            }
            
            public virtual User Login(string username, string password)
            {
                // Get the user from the database
                UserDB user = _context.Users!.FirstOrDefault(u => u.Username == username)!;

                // If the user doesn't exist, return null
                if (user == null)
                {
                    return null;
                }

                // If the password is incorrect, return null
                if (!PasswordHasher.VerifyPassword(password, $"{user.Salt}.{user.PasswordHash}"))
                {
                    return null;
                }
                var sessionKey = GenerateSessionKey(user.Id);
                // If the user is valid, return a User object
                return new User(user.Username, sessionKey, user.Id);
            }

            public virtual User GetUserFromSessionKey(string session_key){
                // Get the session from the database
                SessionDB session = _context.Sessions!.FirstOrDefault(s => s.SessionKey == session_key)!;

                // If the session doesn't exist, return null
                if (session == null)
                {
                    return null;
                }

                // If the session has expired, return null
                if (session.Expiration < DateTime.Now)
                {
                    return null;
                }

                // Get the user from the database
                UserDB user = _context.Users!.FirstOrDefault(u => u.Id == session.UserId)!;

                // If the user doesn't exist, return null
                if (user == null)
                {
                    return null;
                }

                // If the user is valid, return a User object
                return new User(user.Username, session_key, user.Id);
            }

            public virtual User Register(string username, string email, string password)
            {
                // Get the user from the database
                UserDB user = _context.Users!.FirstOrDefault(u => u.Username == username)!;

                // If the user already exists, return null
                if (user != null)
                {
                    return null;
                }

                // Create a new user
                user = new UserDB(username, email, password);

                // Add the user to the database
                _context.Users!.Add(user);
                _context.SaveChanges();
                return Login(username, password);
            }

            public virtual void Logout(string sessionKey)
            {
                // Get the session from the database
                SessionDB session = _context.Sessions!.FirstOrDefault(s => s.SessionKey == sessionKey)!;

                // If the session doesn't exist, return
                if (session == null)
                {
                    return;
                }

                // Remove the session from the database
                _context.Sessions!.Remove(session);
                _context.SaveChanges();
            }
            public virtual void changePassword(string sessionKey, string newPassword)
            {
                // Get the session from the database
                SessionDB session = _context.Sessions!.FirstOrDefault(s => s.SessionKey == sessionKey)!;

                // If the session doesn't exist, return
                if (session == null)
                {
                    return;
                }

                // Get the user from the database
                UserDB user = _context.Users!.FirstOrDefault(u => u.Id == session.UserId)!;

                // If the user doesn't exist, return
                if (user == null)
                {
                    return;
                }

                // Change the user's password
                user.Password = newPassword;

                // Update the user in the database
                _context.Users!.Update(user);
                _context.SaveChanges();
            }
    }
}
