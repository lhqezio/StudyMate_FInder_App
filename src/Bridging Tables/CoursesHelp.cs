namespace StudyMate
{
    public class CoursesHelp
    {
        public Courses Course => (int)Courses;
        public string ProfileId { get; set; }
        public Profile profile{get;set;}=null!;        
        public CoursesHelp()
        {
        }

        public CoursesHelp(Courses course, string profileId)
        {
            Course = course;
            ProfileId=profileId;
        }
    }
}
