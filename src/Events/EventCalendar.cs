//EventCalendar class represents user's event.
//It also reminds the user of an event when it is approaching.
//Editing is implicitly done through set to be able to edit specific fields
using System.Collections.Generic;
using System;


namespace StudyMate
{
    public class EventCalendar
    {
        //Properties
        public string Title {get; set;}
        
        public Profile __creatorId {get;}
        
        public List<Profile> Participants {get; set;}
        
        public int __eventId {get; }
        
        public DateTimeOffset Date {get; set;} 
        public bool IsSent {get; set;}
        public string Description {get; set;}

        public List<Courses> CourseList {get; set;}

        public List<string> SubjectSchoolProjectList {get; set;}
        


        //Constructor
        public EventCalendar(string title, Profile creatorId, List<Profile> participants, DateTimeOffset date, bool isSent, string description, List<Courses> courses, List<string> SubjectSchoolProjectList){
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
                stringParticipants = stringParticipants + participant.Name+", ";
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