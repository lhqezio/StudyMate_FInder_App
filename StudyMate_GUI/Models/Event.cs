using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudyApp.Models
{
    public class Event
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Time {get; set;}
       
        public DateTimeOffset Date {
            get{return Time.Date;}
            set{Time = value.Add(Time.TimeOfDay).DateTime;}
        }
        
        public TimeSpan TimeOfDay {
            get{return Time.TimeOfDay;}
            set{Time = Time.Date.Add(value);}
        }

        public string? Subject { get; set; }
        public string? Course { get; set; }
        public string? Program { get; set; }
        public string? School { get; set; }
        public string Description {get; set;}

        public User Owner{get; set;}
        public ObservableCollection<User> Attendees {get;} = new ObservableCollection<User>();

        public Event(){
            Title = "Study Session";
            Location = "Dawson Library";
            Time = new DateTime(2023,5,5,15,30,0);
            Subject = null;
            Course = "C Sharp";
            Program = "Computer Science";
            School = "Dawson";
            Description = "Get ready for the final exam!";
            Owner = new User("Ann","");
            Attendees = new ObservableCollection<User>{
                new User("Ann",""),
                new User("Boe",""),
                new User("Chi",""),
                new User("Dev","")
            };
        }

    }
}