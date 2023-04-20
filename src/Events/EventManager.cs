//In EventManager the events can be deleted/added from an array that will contain * events
using System.Collections.Generic;

namespace StudyMate{

    public class EventManager
    {
        //Property
        public List<EventCalendar> listEvents {get; set;}
        StudyMateDbContext db = new StudyMateDbContext();
        //Constructor
        public EventManager(){
            listEvents = new List<EventCalendar>();
        }

        //AddEvent Method => Add event to the list of events
        public void AddEvent(EventCalendar e){
            listEvents.Add(e);
            db.Add(e);
            db.SaveChanges();
        }

        //DeleteEvent Method => Delete event to the list of events
        public void DeleteEvent(EventCalendar e){
            listEvents.Remove(e);
            db.Remove(e);
            db.SaveChanges();
        }
    }
}