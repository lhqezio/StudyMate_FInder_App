using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class InterestsProfile
    {
        [Key]
        public string InterestId{get;set;}
        public Interests Interests{get;set;}       
        public List<User> Profiles{get;}=new();

        public InterestsProfile(){}
        public InterestsProfile(Interests interest)
        {
            InterestId=Guid.NewGuid().ToString();
            Interests = interest;
        }
    }
}
