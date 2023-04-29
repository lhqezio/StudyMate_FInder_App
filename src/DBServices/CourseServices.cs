using Microsoft.EntityFrameworkCore;

namespace StudyMate;
public class CourseServices
{
    private StudyMateDbContext _context = null!;
    private static Course? __trackedCourse = new();
    public static CourseNeedHelpWith? __trackedNeedHelpWithCourse = new();
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

    public virtual void AddCourses(List<Course> courses){
        foreach (var item in courses)
         {
            __trackedCourse = _context.StudyCourses?.SingleOrDefault(c => c.CourseId == item.CourseId);
            // If the Course already exists, it will not be added to the database.
            if (__trackedCourse != null)
            {
                System.Console.WriteLine("This course already exist in the database.");
            }else{
                __trackedCourse=item;
                _context.StudyCourses!.Add(__trackedCourse);
                _context.SaveChanges();
            }
         }
    }

    public virtual void AddCourse(Course course){
        __trackedCourse = _context.StudyCourses?.SingleOrDefault(c => c.CourseId == course.CourseId);
        // If the Course already exists, it will not be added to the database.
        if (__trackedCourse != null)
        {
            System.Console.WriteLine("This course already exist in the database.");
        }else{
            __trackedCourse=course;
            _context.StudyCourses!.Add(__trackedCourse);
            _context.SaveChanges();
        }
    }
    public virtual void AddCoursesNeedHelpWith(Profile profile,List<CourseNeedHelpWith> courseNeedHelpWith)
    {
         // Get the Course that the user needs help with from the database
         foreach (var item in courseNeedHelpWith)
         {
            __trackedCourse = _context.StudyCourses?.SingleOrDefault(c => c.CourseId == item.CourseId);
            __trackedNeedHelpWithCourse = _context.CoursesNeedHelpWith?.SingleOrDefault(c => c.CourseId == item.CourseId && c.ProfileId == item.ProfileId);
            // If the Course already exists in the bridging table, it will not be added to the database.
            if (__trackedNeedHelpWithCourse != null)
            {
                System.Console.WriteLine("This course already exist in the database's bridging table.");
            }else{
                __trackedNeedHelpWithCourse=item;
                if (__trackedCourse is null)
                {
                    AddCourse(__trackedNeedHelpWithCourse.Course);
                }else{
                    __trackedNeedHelpWithCourse.Course=__trackedCourse;
                }
                ProfileServices.__trackedProfile=profile;
                __trackedNeedHelpWithCourse.Profile=ProfileServices.__trackedProfile;
                _context.CoursesNeedHelpWith!.Add(__trackedNeedHelpWithCourse);
                _context.SaveChanges();
            }
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
