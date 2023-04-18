namespace StudyMate
{
    public class CoursesTaken
    {
        public int CourseId{get;set;}
        public Courses Course { get; set; }
        public string ProfileId { get; set; }
        public Profile Profile{get;set;}=null!;        
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
