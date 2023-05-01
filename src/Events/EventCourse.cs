using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class EventCourse{ //Bridging Tbl
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public Course Course { get; set; } = null!;
        [ForeignKey("EventCalendar")]
        public string EventId { get; set; }
        public EventCalendar EventCalendar { get; set; } = null!;
        public EventCourse(){}
        public EventCourse(EventCalendar ev, Course course){
            this.CourseId=course.CourseId;
            this.EventId=ev.EventId;
            this.CourseName=course.CourseName;
        }
    }
}