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
        public EventCalendar EventCalendar { get; set; } = null!;
        public EventProfile(){}
        public EventProfile(EventCalendar ev, Profile profile){
            this.ProfileId=profile.ProfileId;
            this.EventId=ev.EventId;
            this.EventTitle=ev.Title;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EventProfile))
            {
                return false;
            }
            EventProfile p = (EventProfile) obj;
            return (this.ProfileId == p.ProfileId);
        }
    }
}