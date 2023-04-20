using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class CanHelpCourses
    {
        [Key]
        public string CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<Profile> Profiles{get;}=new();

        public CanHelpCourses(){}
        public CanHelpCourses(Courses course)
        {
            CourseId=Guid.NewGuid().ToString();
            Course = course;
        }
    }
}
