using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class CourseNeedHelpWith{
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; } = null!;
        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
        public CourseNeedHelpWith(){}
        public CourseNeedHelpWith(Profile profile, Course course){
            this.CourseId=course.CourseId;
            this.ProfileId=profile.ProfileId;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CourseNeedHelpWith))
            {
                return false;
            }
            CourseNeedHelpWith other = (CourseNeedHelpWith) obj;
            return this.ProfileId==other.ProfileId && this.CourseId==other.CourseId;
        }

        public override int GetHashCode()
        {
            return Course.GetHashCode();
        }
    }
}