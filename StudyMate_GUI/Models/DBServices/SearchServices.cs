using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using StudyMate.Models;
namespace StudyMate.Services;
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
        var query = _context.StudyMate_Events?
                                .Include( e => e.Creator)
                                .Include( e => e.School)
                                .Include( e => e.Courses)
                                .Include( e => e.Participants)
                                .Where(e => e.Creator.ProfileId.Equals(profile.ProfileId))
                                .ToList<Event>();
            
        return query!;
    }
        
    //GetEventById => Return events based on event id
    public Event GetEventById(int id){
        var query = _context.StudyMate_Events?
                                .Include( e => e.Creator)
                                .Include( e => e.School)
                                .Include( e => e.Courses)
                                .Include( e => e.Participants)
                                .Where(e => e.EventId.Equals(id))
                                .ToList<Event>();
            
        Event? trackedEvent = query!.Any() ? query!.FirstOrDefault() : null;
        return trackedEvent!;
    }

    //SEARCH FOR PROFILE

    //GetProfileByName => Return profile based on name
    public virtual List<Profile> GetProfilesByName(string name) {
        return _context.StudyMate_Profiles!.Where(p => p.Name == name).ToList();
    }

    public virtual Profile? GetProfileById(int profileId) {
        return _context.StudyMate_Profiles!.SingleOrDefault(p => p.ProfileId == profileId);
    }

    public virtual Profile? GetProfileByUserId(string userId) {
        return _context.StudyMate_Profiles!.SingleOrDefault(p => p.User.UserId == userId);
    }

    //SEARCH FCTS
    //SearchEventsCourseSchool Method => Search Events based on Course and School
    public virtual List<Event> SearchEventsCourseSchool(string keyword){
        Search sc = new Search(_context);
        return sc.SearchEventsCourseSchool(keyword);
    }

    //SearchEventsCreator Method => Search Events based on the creator (profile)
    public virtual List<Event> SearchEventsCreator(int creatorId){
            var query = _context.StudyMate_Events?
                                .Include( e => e.Creator)
                                .Include( e => e.School)
                                .Include( e => e.Courses)
                                .Include( e => e.Participants)
                                .Where(e => e.Creator.ProfileId.Equals(creatorId))
                                .ToList<Event>();
        List<Event> events =  query!;
        return events!;
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
        
        var queryProfile = _context.StudyMate_Profiles?
                                .Include( p => p.CourseCanHelpWith)
                                .Include( p => p.CourseNeedHelpWith)
                                .Include( p => p.CourseTaken)
                                .Include( p => p.CreatorEvents)
                                .Include( p => p.Hobbies)
                                .Include( p => p.ParticipantEvents)
                                .Include( p => p.School)
                                .Include( p => p.User)
                                .Where( p => p.User.UserId.Equals(userId))
                                .ToList<Profile>();
            Profile? profile = queryProfile!.Any() ? queryProfile!.FirstOrDefault() : null;
            return profile!;
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
        return null!;
    }
}


