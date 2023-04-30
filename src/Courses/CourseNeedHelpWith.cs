using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class CourseNeedHelpWith{ //Bridging Tbl
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; } = null!;
        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
        public CourseNeedHelpWith(){}
        public CourseNeedHelpWith(Profile profile, Course course){
            this.CourseId=course.CourseId;
            this.Course=course;
            this.ProfileId=profile.ProfileId;
            this.Profile=profile;
        }
    }
}