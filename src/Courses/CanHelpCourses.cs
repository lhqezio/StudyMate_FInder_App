using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class CanHelpCourses
    {
        [Key]
        public string CourseId{get;set;}
        public Courses Course{get;set;}       
        public List<User> Profiles{get;}=new();

        public CanHelpCourses(){}
        public CanHelpCourses(Courses course)
        {
            CourseId=Guid.NewGuid().ToString();
            Course = course;
        }

        //Override of Equals method. This is used to compare two course objects.
        public override bool Equals(object? obj)
        {
            if (obj is not CanHelpCourses other)
                return false;

            return CourseId == other.CourseId
                && Course == other.Course
                && Profiles == other.Profiles;
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return CourseId.GetHashCode() ^
                Course.GetHashCode() ^
                Profiles.GetHashCode();
        }
    }
}
