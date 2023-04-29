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
    public List<EventCalendar> GetAllProfileEvent(Profile profile){
        return _context.Events!.Where(e => e.Participants.Any(p => p.ProfileId == profile.ProfileId))
            .ToList();
    }
        
    //GetEventById => Return events based on event id
    public EventCalendar GetEventById(string id){
        return _context.Events!.SingleOrDefault(e => e.EventId == id)!;
    }

    //SEARCH FOR PROFILE

    //GetProfileByName => Return profile based on name
    public virtual List<Profile> GetProfileByName(string name) {
        return _context.Profiles!.Where(p => p.Name == name).ToList();
    }

    //SEARCH FCTS
    //SearchEventsCourseSchool Method => Search Events based on Course and School
    public virtual List<EventCalendar> SearchEventsCourseSchool(string courseSchool){
        Search sc = new Search(_context);
        return sc.SearchEventsCourseSchool(courseSchool);
    }

    //SearchEventsCreator Method => Search Events based on the creator (profile)
    public virtual List<EventCalendar> SearchEventsCreator(string creatorId){
        Search sc = new Search(_context);
        return sc.SearchEventsCreator(creatorId);
    }

    //SearchEventTitleDescription Method => Search Event by title and description
    public virtual List<EventCalendar> SearchEventTitleDescription(string keyword){
        Search sc = new Search(_context);
        return sc.SearchEventTitleDescription(keyword);
    }

    //SearchProfileCourseSchool Method => Search profile by Course or School
    public virtual List<Profile> SearchProfileCourseSchool(string courseSchool){
        Search sc = new Search(_context);
        return sc.SearchProfileCourseSchool(courseSchool);
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

}


