namespace StudyMate
{
    public class CanHelpCourses
    {
        public int CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<CoursesCanHelp> CoursesCanHelp{get;}=new();

        public CanHelpCourses(Courses course)
        {
            Course = course;
        }
    }
}
