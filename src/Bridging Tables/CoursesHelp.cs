namespace StudyMate
{
    public class CoursesHelp
    {
        public int CourseId{get;set;}
        public Courses Course {get;set;}
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
