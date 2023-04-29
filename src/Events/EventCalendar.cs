using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class EventCalendar
    {
        // Generates a random primary key for the EventCalendar class 
        [Key]
        public string EventId { get; set;}

        // EventCalendar specific properties
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title can't be empty, null, or whitespace.");
                }
                _title = value;
            }
        }
        private DateTimeOffset _date;
        public DateTimeOffset Date
        {
            get { return _date; }
            set
            {
                if (value < DateTimeOffset.Now)
                {
                    throw new ArgumentException("The event can't be in the past.");
                }
                _date = value;
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Your description can't be empty.");
                }
                _description = value; 
            }
        }
        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Your location can't be empty.");
                }
                _location = value; 
            }
        }

        public bool IsSent { get; set; }

        // Many-to-many relationships
        private List<Profile> _participants {get; set;}
        public List<Profile> Participants
        {
            get { return _participants; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("There should be at least one participant.");
                }
                _participants = value;
            }
        }
        public List<CourseEvent> CourseEvents {get; set;}
        
        // One-to-many relationships
        public string ProfileId{get;set;}
        public Profile EventCreator {get;set;}
        public string SchoolId{get;set;}
        public School School{get; set;} //Will be a dropdown list for user input
        
        // Constructors
        public EventCalendar(){}
        public EventCalendar(string title, Profile eventCreator, List<Profile> participants, DateTimeOffset date, string description,  School school, List<CourseEvent> courseEvents, string location , bool isSent=false)
        {
            EventId = Guid.NewGuid().ToString();
            Title = title;
            ProfileId = eventCreator.ProfileId;
            EventCreator = eventCreator;
            Participants = participants; 
            Date = date;
            Description = description;
            SchoolId=school.SchoolId;
            School = school;
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

        //Method to view participants
        public List<Profile> ShowParticipants()
        {
            return Participants;
        }

        //Override of Equals method. This is used to compare two event objects.
        public override bool Equals(object? obj)
        {
            if (obj is not EventCalendar other)
                return false;
            return _title == other._title
                && EventCreator.Equals(other.EventCreator) 
                && _participants.SequenceEqual(other._participants)
                && _date == other._date
                && _description == other._description
                && School.Equals(other.School)
                && Location == other.Location
                && CourseEvents.SequenceEqual(other.CourseEvents)
                && IsSent == other.IsSent;
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return EventId.GetHashCode() ^
                _title.GetHashCode() ^
                ProfileId.GetHashCode() ^
                EventCreator.GetHashCode() ^
                _participants.GetHashCode() ^
                _date.GetHashCode() ^
                _description.GetHashCode() ^
                SchoolId.GetHashCode() ^
                School.GetHashCode() ^
                Location.GetHashCode() ^
                CourseEvents.GetHashCode() ^
                IsSent.GetHashCode();
        }
    }
}
        
       
