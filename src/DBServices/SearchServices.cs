using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace StudyMate;
public class SearchServices
{
    private StudyMateDbContext _context = null!;

    private static SearchServices? _instance;
    
    public static SearchServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new SearchServices(context);
        }
        return _instance;
    }
    
    public SearchServices(StudyMateDbContext context)
    {
        _context = context;
    }

    //SEARCH FOR EVENT
    //GetAllProfileEvent => Return events based on profile
    public List<Event> GetAllProfileEvent(Profile profile){
        return _context.StudyMate_Events!.Where(e => e.Participants!.Any(p => p.ProfileId == profile.ProfileId))
            .ToList();
    }
        
    //GetEventById => Return events based on event id
    public Event GetEventById(int id){
        return _context.StudyMate_Events!.SingleOrDefault(e => e.EventId == id)!;
    }

    //SEARCH FOR PROFILE

    //GetProfileByName => Return profile based on name
    public virtual List<Profile> GetProfilesByName(string name) {
        return _context.StudyMate_Profiles!.Where(p => p.Name == name).ToList();
    }

    public virtual Profile? GetProfileById(int profileId) {
        return _context.StudyMate_Profiles!.SingleOrDefault(p => p.ProfileId == profileId);
    }
    public virtual List<Event> GetProfileEvents(Profile profile){
        return _context.StudyMate_Events!.Where(e => e.Creator.ProfileId == profile.ProfileId).ToList();
    }

    //SEARCH FCTS
    //SearchEventsCourseSchool Method => Search Events based on Course and School
    public virtual List<Event> SearchEventsCourseSchool(string keyword){
        Search sc = new Search(_context);
        return sc.SearchEventsCourseSchool(keyword);
    }

    //SearchEventsCreator Method => Search Events based on the creator (profile)
    public virtual List<Event> SearchEventsCreator(string creatorId){
        Search sc = new Search(_context);
        return sc.SearchEventsCreator(creatorId);
    }

    //SearchEventTitleDescription Method => Search Event by title and description
    public virtual List<Event> SearchEventTitleDescription(string keyword){
        Search sc = new Search(_context);
        return sc.SearchEventTitleDescription(keyword);
    }

    //SearchProfileCourseSchool Method => Search profile by Course or School
    public virtual List<Profile> SearchProfileCourseSchool(string keyword){
        Search sc = new Search(_context);
        return sc.SearchProfileCourseSchool(keyword);
    }

    //SearchProfileBlurbInterest Method => Search Profile by Blurb and Interest
    public virtual List<Profile> SearchProfileBlurbInterest(string keyword){
        Search sc = new Search(_context);
        return sc.SearchProfileBlurbInterest(keyword);
    }
        
    //SearchProfileByUser Method => Search Profile by Associated User
    public virtual Profile SearchProfileByUser(string userId){
        Search sc = new Search(_context);
        return sc.SearchProfileByUser(userId);
    }

    //SearchAllProfile Method => Search All Profile 
    public virtual List<Profile> SearchAllProfile(){
        return _context.StudyMate_Profiles!.ToList();
    }

    //SearchAllProfile Method => Search All Profile 
    public virtual Profile SearchProfileByProfileId(int profileId){
        List<Profile> profiles =  _context.StudyMate_Profiles!.Where(p => p.ProfileId == profileId).ToList();
        if (profiles.Count != 0){
            return profiles[0];
        }
        return null;
    }
}


