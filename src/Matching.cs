using Microsoft.EntityFrameworkCore;

namespace StudyMate
{

    public class Matching{
        private Profile __profile{get;set;}
        public Matching(Profile profile){
            __profile=profile;
        }
        public List<Profile> BestMatches(){
            using (var dbContext = new StudyMateDbContext())
            {
                List<Profile> profiles = dbContext.Profiles.ToList();
                for (int i = 0; i < profiles.Count; i++)
                {
                    if(profiles[i].Equals(this.__profile)){
                        continue;
                    }
                    
                }
                return profiles;
            }
        }  
    }

}