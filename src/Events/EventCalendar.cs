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
        
        private string _title;
        private DateTimeOffset _date {get;set;}
        private string _description {get;set;}
        public string Location {get;set;}
        public bool IsSent { get; set; }

        // Many-to-many relationships
        private List<Profile> _participants {get; set;}
        public List<CourseEvent> CourseEvents {get; set;}
        
        // One-to-many relationships
        public string ProfileId{get;set;}
        private Profile _eventCreator {get;set;}
        public string SchoolId{get;set;}
        public School School{get; set;} //Will be a dropdown list for user input
        
        // Properties - Validation done here since it will also work when edited 
        public Profile EventCreator
        {
            get { return _eventCreator; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Creator can't be null.");
                }
                _eventCreator = value;
            }
        }
        
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
            return EventId == other.EventId
                && _title == other._title
                && ProfileId == other.ProfileId
                && _eventCreator == other._eventCreator 
                && _participants.SequenceEqual(other._participants)
                && _date == other._date
                && _description == other._description
                && SchoolId == other.SchoolId
                && School == other.School
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
                _eventCreator.GetHashCode() ^
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
        
       
