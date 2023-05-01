using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Course{
        [Key]
        public string CourseId{get;set;}
        
        public string CourseName{get;set;}

        //Many-to-Many (Events - Courses)
        public List<Event> Events {get; set;}

        public Course(){}
        public Course(string courseId, string courseName){
            CourseId=courseId;
            CourseName=courseName;
        }
    }
}