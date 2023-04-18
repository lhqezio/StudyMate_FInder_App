namespace StudyMate
{
    public class InterestsProfile
    {
        public int InterestId{get;set;}
        public Interests Interests{get;set;}       
        public List<ProfileInterests> CoursesCanHelp{get;}=new();

        public InterestsProfile(Interests interest)
        {
            Interests = interest;
        }
    }
}
