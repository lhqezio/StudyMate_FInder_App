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
    public virtual void AddCoursesNeedHelpWith(List<CourseNeedHelpWith> courseNeedHelpWith)
    {
         // Get the Course that the user needs help with from the database
         for (int i=0;i<=courseNeedHelpWith.Count;i++)
         {
            //Fix the issue here Amir
            __trackedCourse = _context.StudyCourses?.SingleOrDefault(c => c.CourseId == courseNeedHelpWith[0].CourseId);
            if (ProfileServices.__trackedProfile is not null && __trackedCourse is not null)
            {
                __trackedNeedHelpWithCourse = new CourseNeedHelpWith(ProfileServices.__trackedProfile,__trackedCourse);
            }
            // If the Course already exists in the bridging table, it will be deleted.
            if (__trackedCourse != null && ProfileServices.__trackedProfile is not null && __trackedNeedHelpWithCourse is not null)
            {
                ProfileServices.__trackedProfile.CourseNeedHelpWith.Remove(__trackedNeedHelpWithCourse);
            }
            else if (__trackedCourse is null){
                __trackedNeedHelpWithCourse=courseNeedHelpWith[i];
                AddCourse(__trackedNeedHelpWithCourse.Course);
                __trackedNeedHelpWithCourse.Course=__trackedCourse;
                __trackedNeedHelpWithCourse.Profile=ProfileServices.__trackedProfile;
                _context.CoursesNeedHelpWith!.Add(__trackedNeedHelpWithCourse);
                _context.SaveChanges();
            }
         }
    }

    // public virtual void RemoveDependency(List<CourseNeedHelpWith> courseNeedHelpWith)
    // { 
    //     // Get the Course that the user needs help with from the database
    //      foreach (var item in courseNeedHelpWith)
    //      {
    //         __trackedNeedHelpWithCourse = _context.CoursesNeedHelpWith?.SingleOrDefault(c => c.CourseId == item.CourseId && c.ProfileId == item.ProfileId);
    //         // If the Course already exists, then delete it.
    //         if (__trackedNeedHelpWithCourse != null)
    //         {
    //             _context.CoursesNeedHelpWith!.Remove(__trackedNeedHelpWithCourse);
    //             _context.SaveChanges();
    //         }else{
    //             System.Console.WriteLine("The dependency you are trying to remove does not exist");
    //         }
    //     }
    // }
}
