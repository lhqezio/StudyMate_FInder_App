using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class EventCalendar
    {
        // Fields
        [Key]
        public string EventId { get; set;} 
        private string _title;

        //Links the Profiles Primary key to this foreign key
        [ForeignKey("Profiles")]
        private string? creatorId;

        private Profile _creator;
        private List<Profile> _participants;
        private DateTimeOffset _date;
        private string _description;
        private string? _location;
        public bool IsSent { get; set; }
        public List<Courses> CourseList { get; set; }
        
        public List<School> Schools{get; set;} //Will be a dropdown list for user input
        public List<String> Subjects { get; set; }
        public List<String> Projects { get; set; }
        public string? Location{get; set;}



        // Properties - Validation done here since it will also work when edited 
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
        
        public Profile Creator
        {
            get { return _creator; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Creator can't be null.");
                }
                _creator = value;
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
        public EventCalendar(string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, List<Courses> courses, List<School>schools, List<String> subjects, List<String> projects, string? location = null)
        {
            EventId = Guid.NewGuid().ToString();
            _title = title; //Make sure if it take _title or Title
            _creator = creator;
            _participants = participants; 
            _date = date;
            IsSent = false;
            _description = description;
            CourseList = courses;
            Schools = schools;
            Subjects = subjects;
            Projects = projects;
            _location = location;
        }

   
        //Method to add Participants
        public void AddParticipant(Profile newParticipant){
            if(_participants.Contains(newParticipant)){
                throw new ArgumentException("This participant is already part of the event");
            }
            _participants.Add(newParticipant);
        }

        //Method to remove Participants
        public void RemoveParticipant(Profile participant){
            if(!_participants.Contains(participant)){
                throw new ArgumentException("This participant isn't part of the event in the first place");
            }
            _participants.Remove(participant);
        }

        //Method to Check if participant is attending the event
        public bool Attends(Profile user)
        {
            return _participants.Contains(user);
        }
    }
}
