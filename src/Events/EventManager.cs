//In EventManager the events can be deleted/added from an array that will contain * events

namespace StudyMate{

    public class EventManager
    {
        //Property
        public List<Event> listEvents {get; set;}

        //Constructor
        public EventManager(){
            listEvents = new List<Event>();
        }

        //AddEvent Method => Add event to the list of events
        public void AddEvent(Event e){
            listEvents.Add(e);
        }

        //DeleteEvent Method => Delete event to the list of events
        public void DeleteEvent(Event e){
            listEvents.Remove(e);
        }

        //StoreEvents Method => Takes this list and store in dtb
        public void StoreEvents(Event e){

        }
    }
}