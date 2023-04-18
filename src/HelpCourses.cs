namespace StudyMate
{
    public class HelpCourses
    {
        public int CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<CoursesHelp> CoursesHelp{get;}=new();

        public HelpCourses(Courses course)
        {
            Course = course;
        }
    }
}
