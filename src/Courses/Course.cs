using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Course{
        [Key]
        public int CourseId{get;set;}

        public string CourseName{get;set;}

        //Many-to-Many (Events/Profile - Courses)
        [InverseProperty("Courses")]
        public List<Event> Events {get; set;}

        [InverseProperty("CourseTaken")]
        public List<Profile> StudentsTakingCourse {get; set;}
        [InverseProperty("CourseNeedHelpWith")]
        public List<Profile> StudentsNeedHelpCourse {get; set;}
        [InverseProperty("CourseCanHelpWith")]
        public List<Profile>? StudentsTutoringCourse {get; set;}

        public Course(){}
        public Course(string courseName){
            CourseName=courseName;
        }
    }
}