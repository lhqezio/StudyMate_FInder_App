namespace StudyMate
{
    public class CoursesCanHelp
    {
        public Courses Course { get; set; }
        public string ProfileId { get; set; }
        public Profile profile{get;set;}=null!;        
        public CoursesCanHelp()
        {
        }

        public CoursesCanHelp(Courses course , string profileId)
        {
            Course = course;
            ProfileId=profileId;
        }
    }
}
