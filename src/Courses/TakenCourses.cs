using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class TakenCourses
    {
        [Key]
        public string CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<Profile> Profiles{get;}=new();

        public TakenCourses(){}
        public TakenCourses(Courses course)
        {
            CourseId=Guid.NewGuid().ToString();
            Course = course;
        }
    }
}
