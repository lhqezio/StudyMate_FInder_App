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

        //Override of Equals method. This is used to compare two course objects.
        public override bool Equals(object? obj)
        {
            if (obj is not CourseEvent other){
                 return false;
            }
            return Course == other.Course;   
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Course.GetHashCode();   
        }
    }
}
