using Microsoft.EntityFrameworkCore;

namespace StudyMate;
public class ProfileServices
{
    private StudyMateDbContext _context = null!;
    public ProfileServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual void AddProfile(Profile profile)
    {
        _context.Profiles!.Add(profile);
        _context.SaveChanges();
    }

    public virtual void DeleteProfile(Profile profile)
    {
        var toDeleteProfile = _context.Profiles!.FirstOrDefault(p => p.UserId==profile.UserId);
        if (toDeleteProfile is not null)
        {
            _context.Profiles!.Remove(toDeleteProfile);
            _context.SaveChanges();
        }
    }

    public virtual void UpdateProfile(Profile profile)
    {
        _context.Profiles!.Update(profile);
        _context.SaveChanges();
    }

    public virtual List<Profile> GetAllProfiles()
    {
        return _context.Profiles!.ToList();
    }

    public virtual Profile? GetSpecificProfileById(string userId)
    {
        return _context.Profiles!.FirstOrDefault(p => p.UserId == userId);
    }

    public virtual Profile? GetSpecificProfile(Profile profile)
    {
        return _context.Profiles!.FirstOrDefault(p => p.Equals(profile));
    }
}
