using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Course{
        [Key]
        public string CourseId{get;set;}
        public string CourseName{get;set;}
        // One-to-many relationship with the bridging tables
        public List<CourseTaken> courseTaken{get;} = new();
        public List<CourseCanHelpWith> CourseCanHelpWith{get;} = new();
        public List<CourseNeedHelpWith> CourseNeedHelpWith{get;} = new();

        //Many-to-Many relationship with Event
        public List<EventCalendar> Events {get;} = new();

        public Course(){}
        public Course(string courseId, string courseName){
            CourseId=courseId;
            CourseName=courseName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Course))
            {
                return false;
            }
            Course other = (Course) obj;
            return this.CourseName == other.CourseName;
        }

        public override int GetHashCode()
        {
            return CourseName.GetHashCode();
        }

    }
}