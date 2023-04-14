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
                Dictionary<int, int> bestMatches = new Dictionary<int, int>();
                List<Profile> profiles = dbContext.Profiles.ToList();
                for (int i = 0; i < profiles.Count; i++)
                {
                    int points=0;
                    if(profiles[i].Equals(this.__profile)){
                        continue;
                    }
                    for (int x = 0; x < __profile.NeedHelpCourses.Count; x++)
                    {
                        for (int y = 0; y < profiles[i].CanHelpCourses.Count; y++)
                        {
                            if (__profile.NeedHelpCourses[x]==profiles[i].CanHelpCourses[y])
                            {
                                points++;
                            }
                        }
                    }
                    bestMatches.Add(points,i);
                }
                return profiles;
            }
        }  
    }

}