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

    //This method adds a course to the StudyCourses table in the database.
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

    //When a profile is created,it is possible the the course they need help with does not already exist in the Courses table.
    //This method will check if the course is already existing. If not, it adds it to the Courses table to prevent
    //missing parent key for CourseID exception.
    public virtual void CheckCourses(List<CourseNeedHelpWith> courseNeedHelpWith)
    {
         for (int i=0;i<courseNeedHelpWith.Count;i++)
         {
            __trackedCourse = _context.StudyCourses?.SingleOrDefault(c => c.CourseId == courseNeedHelpWith[i].CourseId);
            if (ProfileServices.__trackedProfile is not null && __trackedCourse is null)
            {
                __trackedCourse = new Course(courseNeedHelpWith[i].CourseId,courseNeedHelpWith[i].CourseName);
                AddCourse(__trackedCourse);
            }
         }
    }
}
