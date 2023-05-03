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
        __trackedProfile = _context.StudyMate_Profiles?.SingleOrDefault(p => p.ProfileId == profile.ProfileId);

        // If the Profile already exists, it will not be added to the database.
        if (__trackedProfile != null)
        {
            System.Console.WriteLine("This profile already exist in the database.");
        }else{
            __trackedProfile = profile;
            _context.StudyMate_Profiles!.Add(__trackedProfile);
            _context.SaveChanges();
        }
    }

    public virtual void DeleteProfile(Profile profile)
    { 
        // Get the Profile from the database
        __trackedProfile = _context.StudyMate_Profiles?.SingleOrDefault(p => p.ProfileId == profile.ProfileId);
        // If the Profile already exists, then delete it.
        if (__trackedProfile != null)
        {
            _context.StudyMate_Profiles!.Remove(__trackedProfile);
            _context.SaveChanges();
        }else{
            System.Console.WriteLine("The profile you are trying to delete does not exist.");
        }
    }

    public virtual void UpdateProfile(Profile profile)
    {
        // Get the Profile from the database
        __trackedProfile = _context.StudyMate_Profiles?.SingleOrDefault(p => p.ProfileId == profile.ProfileId);
        // If the Profile already exists, it will be updated.
        if (__trackedProfile != null)
        {
            __trackedProfile=profile;
            _context.StudyMate_Profiles!.Update(__trackedProfile);
            _context.SaveChanges();
        }else{
           System.Console.WriteLine("The profile you are trying to update does not exist.");
        }
    }
    // public virtual void CheckParticipants(List<Profile> participants)
    // {
    //      for (int i=0;i<participants.Count;i++)
    //      {
    //         __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.ProfileId == participants[i].ProfileId);
    //         if (EventServices.__trackedEvent is not null && __trackedProfile is null)
    //         {
    //             System.Console.WriteLine("The participant you are trying to add does not exist");
    //             EventServices.__trackedEvent.EventProfile.Remove(participants[i]);
    //             i--;
    //         }
    //      }
    // }
}
