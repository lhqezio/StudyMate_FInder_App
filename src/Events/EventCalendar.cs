//EventCalendar class represents user's event.
//It also reminds the user of an event when it is approaching.
//Editing is implicitly done through set to be able to edit specific fields
using System.Collections.Generic;
using System;


namespace StudyMate
{
    public class EventCalendar
    {
        //Properties - Validation done here since it will also work when edited 
        private string __title;
        public string Title{
            get { return __title; }
            set{
                if(String.IsNullOrEmpty(value)||String.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("Title can't be empty, null, whitespaces");
                }
                __title = value;
            }
        }
        

        private Profile __creator;
        public Profile Creator{
            get { return __creator; }
            set{
                if (value == null)
                {
                    throw new ArgumentNullException("Creator can't be null");
                    }
                    __creator = value;
            }
        }
        

        private List<Profile> __participants;
        public List<Profile> Participants{
            get { return __participants; }
            set{
                if (value == null)
                {
                    throw new ArgumentNullException("There should be at least one participant");
                    }
                    __participants = value;
            }
        }


        public int EventId {get; } //Will be dealt with in dtb part


        private DateTimeOffset __date;
        public DateTimeOffset Date {
            get { return __date; }
            set {
                if(value < DateTimeOffset.Now){
                    throw new ArgumentException("The event can't should be in the future");
                }
                __date = value;
            }
        }


        public bool IsSent {get; set;}


        private string __description;
        public string Description{
            get { return __description; }
            set { 
                if(String.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("Your description can't be empty");
                }
                __description = value; 
            }
        }


        public List<Courses> CourseList {get; set;}

        public List<string> SubjectSchoolProjectList {get; set;}
        


        //Constructors
        public EventCalendar(string title, Profile creator, List<Profile> participants, DateTimeOffset date, bool isSent, string description, List<Courses> courses, List<string> SubjectSchoolProjectList){
            this.Title = title;
            this.Creator = creator;
            this.Participants = participants; 
            this.Date = date;
            this.IsSent = isSent;
            this.Description = description;
            this.CourseList = courses;
            this.SubjectSchoolProjectList = SubjectSchoolProjectList;
        }

        private EventCalendar(){} //For EF

        public override string ToString(){
            string printedEvent="";
            string stringParticipants = "";
            foreach (var participant in this.Participants)
            {
                stringParticipants = stringParticipants + participant.Name+", ";
            }
            printedEvent =  "Title: "+this.Title+
                            " \nCreator: "+this.Creator.Name+
                            " \nParticipants: "+stringParticipants+
                            " \nDate: "+this.Date+
                            " \nDescription: "+this.Description+
                            " \nCourse(s), nSubject(s), School(s) associated: "+this.SubjectSchoolProjectList;
            return printedEvent;
        }
    }
}