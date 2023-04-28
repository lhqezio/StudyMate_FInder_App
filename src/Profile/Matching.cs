using Microsoft.EntityFrameworkCore;
// This class stores all the profiles that may be a good match for the user calling it.
namespace StudyMate
{

    public class Matching{
        private Profile __profile{get;set;}
        private ProfileServices __profileService{get;set;}
        public Matching(Profile profile, ProfileServices profileService){
            __profile=profile;
            __profileService=profileService;
        }
        
        public List<Profile> BestMatches(){
            List<Profile> profiles = __profileService.GetAllProfiles();
            // I want to add anonymous object to this list so the type must be dynamic
            var bestMatches = new List<dynamic>();
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
                        if (__profile.NeedHelpCourses[x].Equals(profiles[i].CanHelpCourses[y]))
                        {
                            points++;
                        }
                    }
                }
                // Since a Profile object does not have a Points property, I make an anonymous
                // object that contains a profile and points in order to avoid adding points 
                // property to Profile Class.
                var tempProfile = new { Profile = profiles[i], Points = points };
                // I then add the anonymous profile to this list defined earlier. Later on, this list will
                //be sorted in and descending order and the best profiles will lbe retrieved.
                bestMatches.Add(tempProfile);
            }
            var sortedDynamic = bestMatches.OrderByDescending(p => p.Points);
            List<Profile> sortedProfiles= new List<Profile>();
            foreach (var item in sortedDynamic)
            {
                sortedProfiles.Add(item.Profile);
            }
            return sortedProfiles;
        }
    }  
}