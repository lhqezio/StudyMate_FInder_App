using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Models
{
    public class Course{
        [Key]
        public int CourseId{get;set;}

        public string CourseName{get;set;} = null!;

        //Many-to-Many (Events/Profile - Courses)
        [InverseProperty("Courses")]
        public List<Event> Events {get; set;} = new List<Event>();

        [InverseProperty("CourseTaken")]
        public List<Profile> StudentsTakingCourse {get; set;} = new List<Profile>();
        [InverseProperty("CourseNeedHelpWith")]
        public List<Profile> StudentsNeedHelpCourse {get; set;} = new List<Profile>();
        [InverseProperty("CourseCanHelpWith")]
        public List<Profile>? StudentsTutoringCourse {get; set;} = new List<Profile>();

        public Course(){}
        public Course(string courseName){
            CourseName=courseName;
        }
    }
}