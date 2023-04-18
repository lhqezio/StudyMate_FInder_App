namespace StudyMate
{
    public class CoursesTaken
    {
        public Courses Course { get; set; }
        public string ProfileId { get; set; }
        public Profile profile{get;set;}=null!;        
        public CoursesTaken()
        {
        }

        public CoursesTaken(Courses course, string profileId)
        {
            Course = course;
            ProfileId=profileId;
        }
    }
}
