using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class CourseEvent
    {
        [Key]
        public string CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<EventCalendar> Events{get;}=new();

        public CourseEvent(){}
        public CourseEvent(Courses course)
        {
            CourseId=Guid.NewGuid().ToString();
            Course = course;
        }
    }
}
