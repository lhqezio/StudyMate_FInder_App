using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudyMate;
public class ProfileServices
{
    private StudyMateDbContext _context = null!;
    public static Profile? __trackedProfile = new();
    private static ProfileServices? _instance;
    public static ProfileServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new ProfileServices(context);
        }
        return _instance;
    }
    public ProfileServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual void AddProfile(Profile profile)
    {
         // Get the Profile from the database
        __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.UserId == profile.UserId);

        // If the Profile already exists, it will not be added to the database.
        if (__trackedProfile != null)
        {
            System.Console.WriteLine("This profile already exist in the database.");
        }else{
            __trackedProfile=profile;
            var schoolService=new SchoolServices(_context);
            var courseService=new CourseServices(_context);
            schoolService.AddSchool(__trackedProfile.School);
            courseService.CheckCourses(__trackedProfile.CourseNeedHelpWith);
            _context.Profiles!.Add(__trackedProfile);
            _context.SaveChanges();
        }
    }

    public virtual void DeleteProfile(User u)
    { 
        // Get the Profile from the database
        __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.UserId == u.UserId);
        // If the Profile already exists, then delete it.
        if (__trackedProfile != null)
        {
            _context.Profiles!.Remove(__trackedProfile);
            _context.SaveChanges();
        }else{
            System.Console.WriteLine("The profile you are trying to delete does not exist.");
        }
    }

    public virtual void UpdateProfile(Profile profile)
    {
        // Get the Profile from the database
        __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.UserId == profile.UserId);
        // If the Profile already exists, it will be updated.
        if (__trackedProfile != null)
        {
            __trackedProfile=profile;
            if (profile.School is not null)
            {
                var schoolService=new SchoolServices(_context);
                schoolService.UpdateSchool(__trackedProfile.School);
            }
            _context.Profiles!.Update(__trackedProfile);
            _context.SaveChanges();
        }else{
           System.Console.WriteLine("The profile you are trying to update does not exist.");
        }
    }
    public virtual Profile? GetMyProfile(User u) {
        __trackedProfile = _context.Profiles!.SingleOrDefault(p => p.UserId == u.UserId);
        return __trackedProfile;
    }

    public virtual List<Profile> GetProfileByName(string name) {
        return _context.Profiles!.Where(p => p.Name == name).ToList();
    }

    public virtual void CheckParticipants(List<EventProfile> participants)
    {
         for (int i=0;i<participants.Count;i++)
         {
            __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.ProfileId == participants[i].ProfileId);
            if (EventServices.__trackedEvent is not null && __trackedProfile is null)
            {
                System.Console.WriteLine("The participant you are trying to add does not exist");
                EventServices.__trackedEvent.EventProfile.Remove(participants[i]);
                i--;
            }
         }
    }
}
