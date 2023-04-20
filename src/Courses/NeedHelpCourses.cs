using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class NeedHelpCourses
    {
        [Key]
        public string CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<Profile> profiles{get;}=new();

        public NeedHelpCourses(){}
        public NeedHelpCourses(Courses course)
        {
            CourseId=Guid.NewGuid().ToString();
            Course = course;
        }
    }
}
