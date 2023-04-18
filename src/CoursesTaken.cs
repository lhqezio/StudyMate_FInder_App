namespace StudyMate
{
    public class CoursesTaken
    {
        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public Profile profile{get;set;}=null!;        
        public string ProfileId { get; set; }
        public Profile Profile { get; set; }

        public CoursesTaken()
        {
        }

        public CoursesTaken(Courses course)
        {
            Course = course;
        }
    }
}
