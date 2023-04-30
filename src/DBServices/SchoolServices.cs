using Microsoft.EntityFrameworkCore;

namespace StudyMate;
public class SchoolServices
{
    private StudyMateDbContext _context = null!;
    private static School? __trackedSchool = new();
    private static SchoolServices? _instance;
    public static SchoolServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new SchoolServices(context);
        }
        return _instance;
    }
    public SchoolServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual void AddSchool(School school)
    {
        // Get the School from the database
        __trackedSchool = _context.Schools?.SingleOrDefault(s => s.SchoolName == school.SchoolName);

        // If the School already exists, don't add the school
        if (__trackedSchool != null)
        {
            if (ProfileServices.__trackedProfile is not null)
            {
                ProfileServices.__trackedProfile.School=__trackedSchool;
            }
            if (EventServices.__trackedEvent is not null)
            {
                EventServices.__trackedEvent.School=__trackedSchool;
            }
            System.Console.WriteLine("This school already exist in the database.");
        }else{
            __trackedSchool=school;
            _context.Schools!.Add(__trackedSchool);
            _context.SaveChanges();
            if (ProfileServices.__trackedProfile is not null)
            {
                ProfileServices.__trackedProfile.School=__trackedSchool;
            }
            if (EventServices.__trackedEvent is not null)
            {
                EventServices.__trackedEvent.School=__trackedSchool;
            }
        }
    }

    public virtual void RemoveSchool(School school)
    {
        // Get the School from the database
        __trackedSchool = _context.Schools?.SingleOrDefault(s => s.SchoolName == school.SchoolName);

        // If the School already exists, then delete it.
        if (__trackedSchool != null)
        {
            _context.Schools!.Remove(__trackedSchool);
            _context.SaveChanges();
        }else{
            System.Console.WriteLine("The school you are trying to remove does not exist");
        }
    }

    public virtual void UpdateSchool(School school)
    {
        // Get the School from the database
        __trackedSchool = _context.Schools?.SingleOrDefault(s => s.SchoolId == school.SchoolId);

        // If the School already exists, then update it.
        if (__trackedSchool != null)
        {
            if (ProfileServices.__trackedProfile is not null)
            {
                ProfileServices.__trackedProfile.School=__trackedSchool;
            }else{
                 __trackedSchool=school;
                _context.Schools!.Update(__trackedSchool);
                _context.SaveChanges();
            }
        }else{
            __trackedSchool=school;
            _context.Schools!.Add(__trackedSchool);
            _context.SaveChanges();
            if (ProfileServices.__trackedProfile is not null)
            {
                ProfileServices.__trackedProfile.School=__trackedSchool;
            }
        }
    }

    public virtual School? GetSchool(string schoolId){
        __trackedSchool = _context.Schools!.SingleOrDefault(s => s.SchoolId == schoolId);
        return __trackedSchool;
    }
}
