using Microsoft.EntityFrameworkCore;
using System.Linq;
using StudyMate.Models;
namespace StudyMate.Services;
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

    public Profile? GetProfiletByProfileId(int profileId){
        var queryProfile = _context.StudyMate_Profiles?
                                    .Include( p => p.CourseCanHelpWith)
                                    .Include( p => p.CourseNeedHelpWith)
                                    .Include( p => p.CourseTaken)
                                    .Include( p => p.CreatorEvents)
                                    .Include( p => p.Hobbies)
                                    .Include( p => p.ParticipantEvents)
                                    .Include( p => p.School)
                                    .Include( p => p.User)
                                    .Where( p => p.ProfileId.Equals(profileId))
                                    .ToList<Profile>();
        Profile? trackedProfile = queryProfile!.Any() ? queryProfile!.FirstOrDefault() : null;
        return trackedProfile;
    }

    public virtual void checkUser(Profile profile){
        var existingUser = _context.StudyMate_Users!.Find(profile.User.UserId);
        if (existingUser != null){
            profile.User = existingUser;
        }       
    }

    public virtual void checkCourses(Profile profile){
        for (int i = 0; i < profile.CourseCanHelpWith!.Count; i++)
        {
            var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(co => co.CourseName.Equals(profile.CourseCanHelpWith[i].CourseName));
            if (existingCourse == null)
            {
                var newCourse = new Course { CourseName = profile.CourseCanHelpWith[i].CourseName };
                _context.StudyMate_Courses!.Add(newCourse);
                profile.CourseCanHelpWith[i] = newCourse;
            }else{
                profile.CourseCanHelpWith[i] = existingCourse;
            }
        }
        for (int i = 0; i < profile.CourseNeedHelpWith!.Count; i++)
        {
            var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(co => co.CourseName.Equals(profile.CourseNeedHelpWith[i].CourseName));
            if (existingCourse == null)
            {
                var newCourse = new Course { CourseName = profile.CourseNeedHelpWith[i].CourseName };
                _context.StudyMate_Courses!.Add(newCourse);
                profile.CourseNeedHelpWith[i] = newCourse;
            }else{
                profile.CourseNeedHelpWith[i] = existingCourse;
            }
        }
        for (int i = 0; i < profile.CourseTaken!.Count; i++)
        {
            var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(co => co.CourseName.Equals(profile.CourseTaken[i].CourseName));
            if (existingCourse == null)
            {
                var newCourse = new Course { CourseName = profile.CourseTaken[i].CourseName };
                _context.StudyMate_Courses!.Add(newCourse);
                profile.CourseTaken[i] = newCourse;
            }else{
                profile.CourseTaken[i] = existingCourse;
            }
        }
    }

    public virtual void checkEditCourses(Profile updatedProfile, Profile trackedProfile){
        for (int i = 0; i < trackedProfile.CourseCanHelpWith!.Count; i++)
        {
            var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(co => co.CourseName == trackedProfile.CourseCanHelpWith[i].CourseName);
            if (existingCourse == null){
                var newCourse = new Course { CourseName = trackedProfile.CourseCanHelpWith[i].CourseName };
                _context.StudyMate_Courses!.Add(newCourse);
                trackedProfile.CourseCanHelpWith[i] = newCourse;
            }else{
                trackedProfile.CourseCanHelpWith[i] = existingCourse;
            }
        }
        for (int i = 0; i < trackedProfile.CourseNeedHelpWith!.Count; i++)
        {
            var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(co => co.CourseName == trackedProfile.CourseNeedHelpWith[i].CourseName);
            if (existingCourse == null){
                var newCourse = new Course { CourseName = trackedProfile.CourseNeedHelpWith[i].CourseName };
                _context.StudyMate_Courses!.Add(newCourse);
                trackedProfile.CourseNeedHelpWith[i] = newCourse;
            }else{
                trackedProfile.CourseNeedHelpWith[i] = existingCourse;
            }
        }
        for (int i = 0; i < trackedProfile.CourseTaken!.Count; i++)
        {
            var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(co => co.CourseName == trackedProfile.CourseTaken[i].CourseName);
            if (existingCourse == null){
                var newCourse = new Course { CourseName = trackedProfile.CourseTaken[i].CourseName };
                _context.StudyMate_Courses!.Add(newCourse);
                trackedProfile.CourseTaken[i] = newCourse;
            }else{
                trackedProfile.CourseTaken[i] = existingCourse;
            }
        }
    }

    public virtual void checkHobbies(Profile profile){
        for (int i = 0; i < profile.Hobbies!.Count; i++)
        {
            var existingHobby = _context.StudyMate_Hobbies!.FirstOrDefault(ho => ho.HobbyName.Equals(profile.Hobbies[i].HobbyName));
            if (existingHobby == null)
            {
                var newHobby = new Hobby { HobbyName = profile.Hobbies[i].HobbyName };
                _context.StudyMate_Hobbies!.Add(newHobby);
                profile.Hobbies[i] = newHobby;
            }else{
                profile.Hobbies[i] = existingHobby;
            }
        }
    }
    
    public virtual void checkEditHobbies(Profile newProfile, Profile trackedProfile){
        for (int i = 0; i < trackedProfile.Hobbies!.Count; i++)
        {
            var existingHobby = _context.StudyMate_Hobbies!.FirstOrDefault(ho => ho.HobbyName == trackedProfile.Hobbies[i].HobbyName);
            if (existingHobby == null){
                var newHobby = new Hobby { HobbyName = trackedProfile.Hobbies[i].HobbyName };
                _context.StudyMate_Hobbies!.Add(newHobby);
                trackedProfile.Hobbies[i] = newHobby;
            }else{
                trackedProfile.Hobbies[i] = existingHobby;
            }
        }
    }

    public virtual void checkSchool(Profile profile){
       var existingSchool = _context.StudyMate_Schools!.FirstOrDefault(s => s.SchoolName == profile.School!.SchoolName);
        if (existingSchool == null){
            var newSchool = new School { SchoolName = profile.School!.SchoolName };
            _context.StudyMate_Schools!.Add(newSchool);
            profile.School = newSchool;
        }else{
            profile.School = existingSchool;
        }
    }

    public virtual void checkEditSchool(Profile updatedProfile, Profile trackedProfile){
       var existingSchool = _context.StudyMate_Schools!.FirstOrDefault(s => s.SchoolName == updatedProfile.School!.SchoolName);
        if (existingSchool == null){
            var newSchool = new School { SchoolName = updatedProfile.School!.SchoolName };
            _context.StudyMate_Schools!.Add(newSchool);
            trackedProfile.School = newSchool;
        }else{
            trackedProfile.School = existingSchool;
        }
    }


    public virtual void AddProfile(Profile profile)
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
        
        Profile? trackedProfile = query!.Any() ? query!.FirstOrDefault() : null;
        
        // If the Profile already exists, it will not be added to the database.
        if (trackedProfile != null)
        {
            System.Console.WriteLine("This profile already exist in the database.");
        }else
        {
            //Check User
            checkUser(profile);
            //No duplicate School
            checkSchool(profile);
            //No duplicate Courses
            checkCourses(profile);
            //No duplicate Hobbies
            checkHobbies(profile);
            _context.StudyMate_Profiles!.Add(profile);
            _context.SaveChanges();
        }
    }

    public virtual void DeleteProfile(Profile profile)
    { 
        // Get the Profile from the database
        Profile? trackedProfile = GetProfiletByProfileId(profile.ProfileId);
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
        Profile? trackedProfile = GetProfiletByProfileId(profileToChange.ProfileId);
        // If the Profile already exists, it will be updated.
        if (trackedProfile != null)
        {
            trackedProfile.Name = updatedProfile.Name;
            trackedProfile.Gender = updatedProfile.Gender;
            //No school duplicate
            checkEditSchool(updatedProfile,trackedProfile);
            //No courses duplicate
            checkEditCourses(updatedProfile, trackedProfile);
            //No hobbies duplicate
            checkEditHobbies(updatedProfile, trackedProfile);
            trackedProfile.Age = updatedProfile.Age;
            trackedProfile.Program = updatedProfile.Program;
            trackedProfile.PersonalDescription = updatedProfile.PersonalDescription; 
            _context.StudyMate_Profiles!.Update(trackedProfile);
            _context.SaveChanges();
        }else{
           System.Console.WriteLine("The profile you are trying to update does not exist.");
        }
    }

    public void GetOrCreateCourseByName(string courseName){
        var existingCourse = _context.StudyMate_Courses!.FirstOrDefault(c => c.CourseName.Equals(courseName));
        if (existingCourse == null){
            var newCourse = new Course { CourseName = courseName };
            _context.StudyMate_Courses!.Add(newCourse);
        }
    }

}

