using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class EventProfile{ //Bridging Tbl
        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
        [ForeignKey("EventCalendar")]
        public string EventId { get; set; }
        public string EventTitle{get;set;}
        public EventCalendar e { get; set; } = null!;
        public EventProfile(){}
        public EventProfile(EventCalendar ev, Profile profile){
            this.ProfileId=profile.ProfileId;
            this.EventId=ev.EventId;
            this.EventTitle=ev.Title;
        }
    }
}