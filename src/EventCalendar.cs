//EventCalendar class represents user's event.
//It also reminds the user of an event when it is approaching.
//Editing is implicitly done through set to be able to edit specific fields

namespace StudyMate
{
    public class EventCalendar
    {
        //Properties
        public string Title {get; set;}
        private Profile __creatorId {get;}
        public List<Profile> Participants {get; set;}
        private int __eventId {get; }
        public DateTimeOffset Date {get; set;} 
        public bool IsSent {get; set;}
        public string Description {get; set;}
        public List<Courses> CourseList {get; set;}
        public List<string> SubjectList {get; set;}
        public List<string> SchoolList {get; set;}
        public List<string> ProjectList {get; set;}


        //Constructor
        public EventCalendar(string title, Profile creatorId, List<Profile> participants, DateTimeOffset date, bool isSent, string description, List<Courses> courses, List<string> subjects, List<string> schools, List<string> projects){
            this.Title = title;
            this.__creatorId = creatorId;
            this.Participants = participants;
//            this.__eventId; 
            this.Date = date;
            this.IsSent = isSent;
            this.Description = description;
            this.CourseList = courses;
            this.SubjectList = subjects;
            this.SchoolList = schools;
            this.ProjectList = projects;
        }

        public string toString(){
            string printedEvent="";
            printedEvent =  "Title: "+this.Title+
                            " \nEventId: "+this.__eventId+
                            " \nCreator: "+this.__creatorId.Name+
                            " \nParticipants: "+this.Participants+
                            " \nCreatorId: "+this.__creatorId+
                            " \nDate: "+this.Date+
                            " \nDescription: "+this.Description+
                            " \nCourse(s) associated: "+this.CourseList+
                            " \nSubject(s) associated: "+this.SubjectList+
                            " \nSchool(s) associated: "+this.SchoolList+
                            " \nProject(s) associated: "+this.ProjectList;
            return printedEvent;
        }
    }
}