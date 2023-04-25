using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class InterestsProfile
    {
        [Key]
        public string InterestId{get;set;}
        public Interests Interests{get;set;}       
        public List<Profile> Profiles{get;}=new();

        public InterestsProfile(){}
        public InterestsProfile(Interests interest)
        {
            InterestId=Guid.NewGuid().ToString();
            Interests = interest;
        }

        //Override of Equals method. This is used to compare two course objects.
        public override bool Equals(object? obj)
        {
            if (obj is not InterestsProfile other){
                return false;
            }   
            return Interests == other.Interests;
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Interests.GetHashCode();
        }
    }
}
