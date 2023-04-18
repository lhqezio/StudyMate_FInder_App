namespace StudyMate
{
    public class ProfileInterests
    {
        public Interests interests { get; set; }
        public string ProfileId { get; set; }
        public Profile profile{get;set;}=null!;        
        public ProfileInterests()
        {
        }

        public ProfileInterests(Courses course)
        {
            Course = course;
        }
    }
}
