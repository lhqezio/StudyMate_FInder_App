using System.ComponentModel;
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

        // One-to-one relationship
        //School
        [ForeignKey("School")]
        public string SchooId { get; set; }
        private School _school;    
        public School School
        {
            get { return _school; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("School can't be empty or null.");
                }
                _school = value;
            }
        }

        //Creator - One to many relationship
        [ForeignKey("Profile")]
        public string CreatorId {get; set;} //Profile Id   //Child    
        public Profile Creator {get; set;} = null!;

        // one-to-many relationship with the bridging tables
        public List<EventProfile> EventProfile{get;set;} = new(); 
        public List<EventCourse> EventCourse{get;set;} = new();
        
        // Many-to-Many relationship
        //Participants
        private List<Profile> _participants {get; set;} = new();
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
        
        //other properties
        //Title
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
        
        //Date
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
        
        //Description
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
        
        //Location
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
        
        //Subjects
        private string _subjects {get; set;}
        public string Subjects
        {
            get { return _subjects; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Subjects can't be empty, null, or whitespace.");
                }
                _subjects = value;
            }
        }

        //Sent or not
        public bool IsSent { get; set; }

        // Constructors
        public EventCalendar(){}
        public EventCalendar(string eventId, string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, string location, string subjects, List<Course> courses, School school, bool isSent=false)
        {
            EventId = eventId;
            _title = title;
            CreatorId = creator.ProfileId; 
            _date = date;
            _description = description;
            _location = location;
            _subjects = subjects;
            _school = school;
            SchooId= school.SchoolId;
            IsSent = isSent;
        }

        //	Creating a new event and Editing an existing event (restricted to the user who created it) will be dealt with in EventServices (which represents EventManager)


        //Method to add Participants =>	Users should be able to mark themselves as attending an event
        public void AddParticipant(Profile newParticipant){
            if(Participants.Contains(newParticipant)){
                throw new ArgumentException("This participant is already part of the event");
            }
            Participants.Add(newParticipant);
        }

        //Method to remove Participants =>	Users should be able to remove themselves from an event
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

        //Method to view participants => User should be able to view the list of the other users who are attending the event.
        public List<String> ShowParticipants()
        {
            List<string> stringParticipant = new List<string>();
            foreach (var participant in _participants)
            {
                stringParticipant.Add(participant.Name);
            }
            return stringParticipant;
        }
    }
}
        
       
