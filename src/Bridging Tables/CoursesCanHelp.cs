namespace StudyMate
{
    public class CoursesCanHelp
    {
        public int CourseId => (int)Courses;
        public Courses Course { get; set; }
        public string ProfileId { get; set; }
        public Profile profile{get;set;}=null!;        
        public CoursesCanHelp()
        {
        }

        public CoursesCanHelp(Courses course)
        {
            Course = course;
        }
    }
}
