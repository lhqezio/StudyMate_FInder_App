using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class Event
    {
        // Generates a random primary key for the Event class 
        [Key]
        public int EventId { get; set;}

        // Creator
        [ForeignKey("ProfileId")]
        public Profile Creator {get; set;} = null!;

        //Participants
        [InverseProperty("ParticipantEvents")]
        public List<Profile>? Participants {get; set;} = new();
        
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
        private DateTimeOffset? _date;
        public DateTimeOffset? Date
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

        //Courses
        private List<Course>? _courses {get; set;}
        [InverseProperty("Events")]
        public List<Course>? Courses
        {
            get { return _courses; }
            set{
                if (value == null){
                    throw new ArgumentException("Courses can't be empty, null.");
                }
                _courses = value;
            }
        }        
            //Many-To-Many 

        //School
        private School? _school; 
        [ForeignKey("SchoolId")]   
        public School? School
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

        //Sent or not
        public bool IsSent { get; set; }

        // Constructors
        public Event(){}
        public Event(Profile creator, string title, DateTimeOffset date, string description, string location, string subjects, List<Course>? courses, School school, bool isSent=false)
        {   
            this.Creator = creator;
            this.Title = title;
            this.Date = date;
            this.Description = description;
            this.Location = location;
            this.Subjects = subjects;
            this.Courses = courses;
            this.School = school;
            this.Participants = new List<Profile>();
            this.IsSent = isSent;
        }

        //	Creating a new event and Editing an existing event (restricted to the user who created it) will be dealt with in EventServices (which represents EventManager)


        //Method to add Participants =>	Users should be able to mark themselves as attending an event
        public void AddParticipant(Profile newParticipant){
            if(this.Participants.Contains(newParticipant)){
                throw new ArgumentException("This participant is already part of the event");
            }
            this.Participants.Add(newParticipant);
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
            foreach (var participant in this.Participants)
            {
                stringParticipant.Add(participant.Name);
            }
            return stringParticipant;
        }
    }
}
        
       
       
