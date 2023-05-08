using Microsoft.EntityFrameworkCore;
using System.Linq;

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
    public ProfileServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual Profile AddProfile(Profile profile)
    {
        // Get the Profile from the database
        var query = _context.StudyMate_Profiles?
                            .Include( p => p.CourseCanHelpWith)
                            .Include( p => p.CourseNeedHelpWith)
                            .Include( p => p.CourseTaken)
                            .Include( p => p.CreatorEvents)
                            .Include( p => p.Hobbies)
                            .Include( p => p.ParticipantEvents)
                            .Include( p => p.School)
                            .Include( p => p.User)
                            .Where( p => p.Name.Equals(profile.Name))
                            .ToList<Profile>();
        
        Profile? trackedProfile = query.Any() ? query.FirstOrDefault() : null;
        
        // If the Profile already exists, it will not be added to the database.
        if (trackedProfile != null)
        {
            System.Console.WriteLine("This profile already exist in the database.");
            return trackedProfile;
        }else
        {
            var existingUser = _context.StudyMate_Users.Find(profile.User.UserId);
            if (existingUser != null)
            {
                profile.User = existingUser;
            }
   
            _context.StudyMate_Profiles!.Add(profile);
            _context.SaveChanges();
            return profile;
        }
    }

    public virtual void DeleteProfile(Profile profile)
    { 
        // Get the Profile from the database
        var query = _context.StudyMate_Profiles?
                            .Include( p => p.CourseCanHelpWith)
                            .Include( p => p.CourseNeedHelpWith)
                            .Include( p => p.CourseTaken)
                            .Include( p => p.CreatorEvents)
                            .Include( p => p.Hobbies)
                            .Include( p => p.ParticipantEvents)
                            .Include( p => p.School)
                            .Include( p => p.User)
                            .Where( p => p.ProfileId.Equals(profile.ProfileId))
                            .ToList<Profile>();
        Profile? trackedProfile = query.Any() ? query.FirstOrDefault() : null;
        // If the Profile already exists, then delete it.
        if (trackedProfile != null)
        {
            _context.StudyMate_Profiles!.Remove(trackedProfile);
            _context.SaveChanges();
        }else{
            System.Console.WriteLine("The profile you are trying to delete does not exist.");
        }
    }

    public virtual void UpdateProfile(Profile profileToChange, Profile updatedProfile)
    {
        // Get the Profile from the database
        var query = _context.StudyMate_Profiles?
                            .Include( p => p.CourseCanHelpWith)
                            .Include( p => p.CourseNeedHelpWith)
                            .Include( p => p.CourseTaken)
                            .Include( p => p.CreatorEvents)
                            .Include( p => p.Hobbies)
                            .Include( p => p.ParticipantEvents)
                            .Include( p => p.School)
                            .Include( p => p.User)
                            .Where( p => p.Name.Equals(profileToChange.Name))
                            .ToList<Profile>();
        Profile? trackedProfile = query.Any() ? query.FirstOrDefault() : null;
        // If the Profile already exists, it will be updated.
        if (trackedProfile != null)
        {
            trackedProfile.Name = updatedProfile.Name;
            trackedProfile.Gender = updatedProfile.Gender;
            trackedProfile.School = updatedProfile.School;
            trackedProfile.CourseTaken = updatedProfile.CourseTaken;
            trackedProfile.CourseCanHelpWith = updatedProfile.CourseCanHelpWith;
            trackedProfile.CourseNeedHelpWith = updatedProfile.CourseNeedHelpWith;
            trackedProfile.Hobbies = updatedProfile.Hobbies;
            trackedProfile.Age = updatedProfile.Age;
            trackedProfile.Program = updatedProfile.Program;
            trackedProfile.PersonalDescription = updatedProfile.PersonalDescription; 
            _context.StudyMate_Profiles!.Update(trackedProfile);
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
