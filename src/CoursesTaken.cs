namespace StudyMate
{
    public class CoursesTaken
    {
        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public string ProfileId { get; set; }
        public Profile profile{get;set;}=null!;        
        public CoursesTaken()
        {
        }

        public CoursesTaken(Courses course)
        {
            Course = course;
        }
    }
}
