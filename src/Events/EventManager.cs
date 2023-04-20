//In EventManager the events can be deleted/added from an array that will contain * events
using System.Collections.Generic;

namespace StudyMate{

    public class EventManager
    {
        
         //Properties
        private static EventManager? _instance;
        private StudyMateDbContext _context = null!;

        private EventManager(){

        }

        public static EventManager getInstance(){
            if(_instance is null){
                _instance = new EventManager();
            }
            return _instance;
        }
        
        //Constructor
        public EventManager(StudyMateDbContext context){
              _context = context;
        }

        //AddEvent Method => Add event to the list of events
        public void AddEvent(EventCalendar e){
            _context.Events.Add(e);
            _context.SaveChanges();
        }

        //DeleteEvent Method => Delete event to the list of events
        public void DeleteEvent(EventCalendar e){

            _context.Events.Remove(e);
            _context.SaveChanges();
        }
    }
}