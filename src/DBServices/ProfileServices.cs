using Microsoft.EntityFrameworkCore;

namespace StudyMate;
public class ProfileServices
{
    private StudyMateDbContext _context = null!;
    private static ProfileServices? _instance;
    public static ProfileServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new ProfileServices(context);
        }
        return _instance;
    }
    private ProfileServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual void AddProfile(Profile profile, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            _context.Profiles!.Add(profile);
            _context.SaveChanges();
        }
    }

    public virtual void DeleteProfile(Profile profile, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            _context.Profiles!.Remove(profile);
            _context.SaveChanges();
        }
    }

    public virtual void UpdateProfile(Profile profileToUpdate,Profile updateProfile, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            updateProfile.ProfileId=profileToUpdate.ProfileId;
            _context.Entry(updateProfile).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
