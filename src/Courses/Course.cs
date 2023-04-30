using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Course{
        [Key]
        public string CourseId{get;set;}
        public string CourseName{get;set;}
        // One-to-many relationship with the bridging tables
        public List<CourseTaken> courseTaken{get;set;} = new();
        public List<CourseCanHelpWith> CourseCanHelpWith{get;set;} = new();
        public List<CourseNeedHelpWith> CourseNeedHelpWith{get;set;} = new();
        public Course(){}
        public Course(string courseId, string courseName){
            CourseId=courseId;
            CourseName=courseName;
        }
    }
}