using System.Linq;

namespace StudyMate
{
    public class EventCalendar
    {
        // Fields
        private string _title;
        private Profile _creator;
        private List<Profile> _participants;
        private DateTimeOffset _date;
        private string _description;


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
        
        public int EventId { get; } //Will be dealt with in dtb part
        
        public bool IsSent { get; set; }
        
        public List<Courses> CourseList { get; set; }
        
        public List<string> SubjectSchoolProjectList { get; set; }

        // Constructors
        public EventCalendar(string title, Profile creator, List<Profile> participants, DateTimeOffset date, bool isSent, string description, List<Courses> courses, List<string> subjectSchoolProjectList)
        {
            Title = title;
            Creator = creator;
            Participants = participants; 
            Date = date;
            IsSent = isSent;
            Description = description;
            CourseList = courses;
            SubjectSchoolProjectList = subjectSchoolProjectList;
        }

        //Method to add Participants
        public void AddParticipant(Profile participant){
            if(_participants.Contains(participant)){
                throw new ArgumentException("This participant is already part of the event");
            }
        }

        //Method to remove Participants
        public void RemoveParticipant(Profile participant){
            if(!_participants.Contains(participant)){
                throw new ArgumentException("This participant isn't part of the event in the first place");
            }
        }

    }
}
