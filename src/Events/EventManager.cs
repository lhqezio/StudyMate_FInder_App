//In EventManager the events can be deleted/added from an array that will contain * events
using System.Collections.Generic;

namespace StudyMate{

    public class EventManager
    {
        //Property
        public List<EventCalendar> listEvents {get; set;}

        //Constructor
        public EventManager(){
            listEvents = new List<EventCalendar>();
        }

        //AddEvent Method => Add event to the list of events
        public void AddEvent(EventCalendar e){
            listEvents.Add(e);
        }

        //DeleteEvent Method => Delete event to the list of events
        public void DeleteEvent(EventCalendar e){
            listEvents.Remove(e);
        }

        //StoreEvents Method => Takes this list and store in dtb
        public void StoreEvents(EventCalendar e){

        }
    }
}