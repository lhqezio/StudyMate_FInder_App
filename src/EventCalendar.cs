using System.Reflection;
//EventCalendar class is responsible to create events for the user.
//It also reminds the user of an event when it is approaching.
//Also, the events are modifiable meaning they can be delted, modified or added.
using StudyMate;

namespace StudyMate
{
    public class EventReminder
    {
        //Properties
        public string Title {get; set;}
        public User CreatorId {get; set;}
        public List<User> Participants {get; set;}
        public string EventId {get; set;}
        public DateTime Date {get; set;} 
        public bool IsSent {get; set;}
        public string Note {get; set;}

        //Constructor
        public EventReminder(string title, User creatorId, List<User> participants, string eventId, DateTime date, bool isSent, string note){
            this.Title = title;
            this.CreatorId = creatorId;
            this.Participants = participants;
            this.EventId = eventId;
            this.Date = date;
            this.IsSent = isSent;
            this.Note = note;
        }

    }
}