using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class CourseCanHelpWith : Course{ //Bridging Tbl
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public Course Course { get; set; } = null!;
        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
        public CourseCanHelpWith(){}
        public CourseCanHelpWith(Profile profile, Course course){
            this.CourseId=course.CourseId;
            this.ProfileId=profile.ProfileId;
            this.CourseName=course.CourseName;
        }
    }
}