using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class EventCalendar
    {
        // Fields
        [Key]
        public string EventId { get; set;}
        // private string _title; 
        public string Title{get;set;}
        public List<Profile> Participants {get;set;}=new();
        public string ProfileId{get;set;}
        public Profile EventCreator {get;set;}=null!;
        public List<CourseEvent> CourseEvents {get;set;}=new();
        public DateTimeOffset Date {get;set;}
        public string Description {get;set;}
        public string Location {get;set;}
        public bool IsSent { get; set; }
        public List<School> Schools{get; set;} //Will be a dropdown list for user input

        // Properties - Validation done here since it will also work when edited 
        // public string Title
        // {
        //     get { return _title; }
        //     set
        //     {
        //         if (string.IsNullOrWhiteSpace(value))
        //         {
        //             throw new ArgumentException("Title can't be empty, null, or whitespace.");
        //         }
        //         _title = value;
        //     }
        // }
        
        // public Profile Creator
        // {
        //     get { return _creator; }
        //     set
        //     {
        //         if (value == null)
        //         {
        //             throw new ArgumentNullException("Creator can't be null.");
        //         }
        //         _creator = value;
        //     }
        // }
        
        // public List<Profile> Participants
        // {
        //     get { return _participants; }
        //     set
        //     {
        //         if (value == null || value.Count == 0)
        //         {
        //             throw new ArgumentException("There should be at least one participant.");
        //         }
        //         _participants = value;
        //     }
        // }
        
        // public DateTimeOffset Date
        // {
        //     get { return _date; }
        //     set
        //     {
        //         if (value < DateTimeOffset.Now)
        //         {
        //             throw new ArgumentException("The event can't be in the past.");
        //         }
        //         _date = value;
        //     }
        // }
        
        // public string Description
        // {
        //     get { return _description; }
        //     set
        //     {
        //         if (string.IsNullOrWhiteSpace(value))
        //         {
        //             throw new ArgumentException("Your description can't be empty.");
        //         }
        //         _description = value; 
        //     }
        // }
        
        // Constructors
        public EventCalendar(){}
        public EventCalendar(string title, Profile eventCreator, List<Profile> participants, DateTimeOffset date, string description,  List<School>schools, List<CourseEvent> courseEvents, string location , bool isSent=false)
        {
            EventId = Guid.NewGuid().ToString();
            Title = title;
            EventCreator = eventCreator;
            ProfileId=EventCreator.ProfileId;
            Participants = participants; 
            Date = date;
            Description = description;
            Schools = schools;
            Location = location;
            CourseEvents=courseEvents;
            IsSent=isSent;
        }

   
        //Method to add Participants
        public void AddParticipant(Profile newParticipant){
            if(Participants.Contains(newParticipant)){
                throw new ArgumentException("This participant is already part of the event");
            }
            Participants.Add(newParticipant);
        }

        //Method to remove Participants
        public void RemoveParticipant(Profile participant){
            if(!Participants.Contains(participant)){
                throw new ArgumentException("This participant isn't part of the event in the first place");
            }
            Participants.Remove(participant);
        }

        //Method to Check if participant is attending the event
        public bool Attends(Profile participant)
        {
            return Participants.Contains(participant);
        }
    }
}
