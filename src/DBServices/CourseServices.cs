using Microsoft.EntityFrameworkCore;

namespace StudyMate;
public class CourseServices
{
    private StudyMateDbContext _context = null!;
    private static Course? __trackedCourse = new();
    private static CourseNeedHelpWith? __trackedNeedHelpWithCourse = new();
    private static CourseServices? _instance;
    public static CourseServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new CourseServices(context);
        }
        return _instance;
    }
    public CourseServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual void AddCoursesNeedHelpWith(Profile profile,List<CourseNeedHelpWith> courseNeedHelpWith)
    {
         // Get the Course from the database
         foreach (var item in courseNeedHelpWith)
         {
            __trackedCourse = _context.StudyCourses?.SingleOrDefault(c => c.CourseId == item.CourseId);
            // If the Course already exists, it will not be added to the database.
            if (__trackedCourse != null)
            {
                System.Console.WriteLine("This course already exist in the database.");
            }else{
                __trackedCourse=item.Course;
                _context.StudyCourses!.Add(__trackedCourse);
                ProfileServices.__trackedProfile=profile;
                AddNeedHelpBridge(ProfileServices.__trackedProfile,__trackedCourse);
                _context.SaveChanges();
            }
         }
    }

    public virtual void AddNeedHelpBridge(Profile profile, Course course){
        __trackedNeedHelpWithCourse = _context.CoursesNeedHelpWith?.SingleOrDefault(c => c.CourseId == course.CourseId && c.ProfileId == profile.ProfileId);
        if (__trackedNeedHelpWithCourse is not null)
        {
            System.Console.WriteLine("This need help with course already exist in the database.");
        }else{
            __trackedNeedHelpWithCourse=new CourseNeedHelpWith(profile,course);
            _context.CoursesNeedHelpWith!.Add(__trackedNeedHelpWithCourse);
            _context.SaveChanges();
        }
    }

    // public virtual void DeleteProfile(Profile profile)
    // { 
    //     // Get the Profile from the database
    //     __trackedProfile = _context.Profiles?.SingleOrDefault(p => p.UserId == profile.UserId);
    //     // If the Profile already exists, then delete it.
    //     if (__trackedProfile != null)
    //     {
    //         _context.Profiles!.Remove(__trackedProfile);
    //         _context.SaveChanges();
    //     }else{
    //         System.Console.WriteLine("The profile you are trying to delete does not exist.");
    //     }
    // }

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
