//Also, the events are modifiable meaning they can be delted or added.

namespace StudyMate
{
    public class EventManager
    {
        //Property
        public List<EventCalendar> listEvents {get; set;}

        //Constructor
        public EventManager(){
            listEvents = new List<EventCalendar>();
        }

        public void AddEvent(EventCalendar e){
            listEvents.Add(e);
        }

        public void DeleteEvent(EventCalendar e){
            listEvents.Remove(e);
        }
    }
}