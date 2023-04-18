namespace StudyMate
{
    public class TakenCourses
    {
        public int CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<CoursesTaken> CoursesTaken{get;}=new();

        public TakenCourses(Courses course)
        {
            Course = course;
        }
    }
}
