using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class CourseCanHelpWith{ //Bridging Tbl
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; } = null!;
        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
        public CourseCanHelpWith(){}
        public CourseCanHelpWith(string courseId, string profileId){
            this.CourseId=courseId;
            this.ProfileId=profileId;
        }
    }
}