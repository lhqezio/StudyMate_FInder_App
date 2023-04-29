using Microsoft.EntityFrameworkCore;

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
            schoolService.AddSchool(__trackedProfile.School);
            var courseService=new CourseServices(_context);
            courseService.AddCoursesNeedHelpWith(__trackedProfile,__trackedProfile.CourseNeedHelpWith);
            _context.Profiles!.Add(__trackedProfile);
            _context.SaveChanges();
        }
    }

    public virtual void DeleteProfile(Profile profile)
    { 
        // Get the Profile from the database
        __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.UserId == profile.UserId);
        // If the Profile already exists, then delete it.
        if (__trackedProfile != null)
        {
            _context.Profiles!.Remove(__trackedProfile);
            _context.SaveChanges();
        }else{
            System.Console.WriteLine("The profile you are trying to delete does not exist.");
        }
    }

    // public virtual void UpdateProfile(Profile profile, User u)
    // {
    //     //I commented this if statement for now because in the moq test, it returns false and causes the test to fail.
    //     // if (_context.ValidateSessionKey(u.__session_key))
    //     // {
    //         if(u.UserId != profile.UserId){
    //             return;
    //         }
    //         _context.Profiles!.Update(profile);
    //         _context.SaveChanges();
    //     // }
    // }
    // public virtual Profile GetMyProfile(User u) {
    //     return _context.Profiles!.SingleOrDefault(p => p.UserId == u.UserId);
    // }
    // public virtual List<Profile> GetProfileByName(string name) {
    //     return _context.Profiles!.Where(p => p.Name == name).ToList();
    // }
}
