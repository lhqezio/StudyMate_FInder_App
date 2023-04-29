using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class NeedHelpCourses
    {
        [Key]
        public string CourseId{get;set;}
        public string Course{get;set;}       
        public List<Profile> Profiles{get;}=new();

        public NeedHelpCourses(){}
        public NeedHelpCourses(Courses course)
        {
            CourseId=Guid.NewGuid().ToString();
            Course = course.ToString();
        }

        //Override of Equals method. This is used to compare two course objects.
        public override bool Equals(object? obj)
        {
            if (obj is not NeedHelpCourses other){
                return false;
            }
            return Course == other.Course; 
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return  Course.GetHashCode();
        }

    }
}
