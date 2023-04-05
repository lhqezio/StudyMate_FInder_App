using System;
using System.Collections.Generic;

namespace StudyMate
{
    public class EventCalendar
    {
        // Fields
        private string _title;
        private string _creatorId;
        private List<string> _participantIds;
        private DateTimeOffset _date;
        private string _description;

        // Properties
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title can't be empty, null, or whitespace.");
                }
                _title = value;
            }
        }

        public string CreatorId
        {
            get => _creatorId;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CreatorId can't be empty, null, or whitespace.");
                }
                _creatorId = value;
            }
        }

        public List<string> ParticipantIds
        {
            get => _participantIds;
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("There should be at least one participant.");
                }
                _participantIds = value;
            }
        }

        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                if (value < DateTimeOffset.Now)
                {
                    throw new ArgumentException("The date must be scheduled in the future and cannot be in the past.");
                }
                _date = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description can't be empty, null, or whitespace.");
                }
                _description = value;
            }
        }

        public int EventId { get; set; }

        public bool IsSent { get; set; }

        public List<Courses> CourseList { get; set; }

        public List<string> SubjectSchoolProjectList { get; set; }

        // Constructors
        public EventCalendar(string title, string creatorId, List<string> participantIds, DateTimeOffset date, bool isSent, string description, List<Courses> courses, List<string> subjectSchoolProjectList)
        {
            Title = title;
            CreatorId = creatorId;
            ParticipantIds = participantIds;
            Date = date;
            IsSent = isSent;
            Description = description;
            CourseList = courses ?? new List<Courses>();
            SubjectSchoolProjectList = subjectSchoolProjectList ?? new List<string>();
        }

        // Methods
        public override string ToString()
        {
            string printedEvent = "";
            string stringParticipants = "";
            foreach (var participantId in ParticipantIds)
            {
                stringParticipants = stringParticipants + participantId + ", ";
            }
            printedEvent = "Title: " + Title +
                            " \nCreator: " + CreatorId +
                            " \nParticipants: " + stringParticipants +
                            " \nDate: " + Date +
                            " \nDescription: " + Description +
                            " \nCourse(s), Subject(s), School(s) associated: " + string.Join(", ", SubjectSchoolProjectList);
            return printedEvent;
        }
    }
}