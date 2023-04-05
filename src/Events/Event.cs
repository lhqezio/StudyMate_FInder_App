using System.ComponentModel.DataAnnotations;
//EventCalendar class represents user's event.
//It also reminds the user of an event when it is approaching.
//Editing is implicitly done through set to be able to edit specific fields

namespace StudyMate
{
    public class Event
    {
        [Required(ErrorMessage = "Title is required")]
        //Properties
        public string Title {get; set;}
        
        private Profile __creatorId {get;}
        
        [MinLength(1, ErrorMessage = "At least one participant must be specified.")]
        public List<Profile> Participants {get; set;}
        private int __eventId {get; }
        
        [Required(ErrorMessage = "Date is required")]
        public DateTimeOffset Date {get; set;} 
        public bool IsSent {get; set;}
        public string Description {get; set;}

        [MinLength(1, ErrorMessage = "At least one course must be specified.")]
        public List<Courses> CourseList {get; set;}

        [MinLength(1, ErrorMessage = "At least one subject/school/project must be specified.")]
        public List<string> SubjectSchoolProjectList {get; set;}
        


        //Constructor
        public Event(string title, Profile creatorId, List<Profile> participants, DateTimeOffset date, bool isSent, string description, List<Courses> courses, List<string> SubjectSchoolProjectList){
            this.Title = title;
            this.__creatorId = creatorId;
            this.Participants = participants; 
            this.Date = date;
            this.IsSent = isSent;
            this.Description = description;
            this.CourseList = courses;
            this.SubjectSchoolProjectList = SubjectSchoolProjectList;
        }

        public override string ToString(){
            string printedEvent="";
            string stringParticipants = "";
            foreach (var participant in this.Participants)
            {
                stringParticipants += participant.Name+", ";
            }
            printedEvent =  "Title: "+this.Title+
                            " \nCreator: "+this.__creatorId.Name+
                            " \nParticipants: "+stringParticipants+
                            " \nDate: "+this.Date+
                            " \nDescription: "+this.Description+
                            " \nCourse(s), nSubject(s), School(s) associated: "+this.SubjectSchoolProjectList;
            return printedEvent;
        }
    }
}