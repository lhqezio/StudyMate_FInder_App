//EventCalendar class represents user's event.
//It also reminds the user of an event when it is approaching.
//Deleting, Modifying, Adding events will be delt with in EventManager.

namespace StudyMate
{
    public class EventCalendar
    {
        //Properties
        public string Title {get; set;}
        public User CreatorId {get; set;}
        public List<User> Participants {get; set;}
        public int EventId {get; set;}
        public DateTime Date {get; set;} 
        public bool IsSent {get; set;}
        public string Note {get; set;}
        public Courses Course {get; set;}
        public string Subject {get; set;}
        public string School {get; set;}
        public string Project {get; set;}


        //Constructor
        public EventCalendar(string title, User creatorId, List<User> participants, DateTime date, bool isSent, string note, Courses course, string subject, string school, string project){
            this.Title = title;
            this.CreatorId = creatorId;
            this.Participants = participants;
            this.EventId = ; //Generated 
            this.Date = date;
            this.IsSent = isSent;
            this.Note = note;
            this.Course = course;
            this.Subject = subject;
            this.School = school;
            this.Project = project;
        }

        public string toString(){
            string printedEvent="";
            printedEvent =  "Title: "+this.Title+
                            " \nEventId: "+this.EventId+
                            " \nCreatorId: "+this.CreatorId+
                            " \nParticipants: "+this.Participants+
                            " \nCreatorId: "+this.CreatorId+
                            " \nDate: "+this.Date+
                            " \nDescription: "+this.Note+
                            " \nAssociated to: "+this.Course+this.Subject+this.School+this.Project;
            return printedEvent;
        }
    }
}