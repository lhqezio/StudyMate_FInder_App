using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class School{
        [Key]
        public string SchoolId{get;set;}
        public string SchoolName{get;set;}
        public List<Profile> Profiles {get;} = new List<Profile>();
        public EventCalendar Event {get; set;} = null!;
        
        public School(){}
        public School(string schoolId,string schoolName){
            this.SchoolId=schoolId;
            this.SchoolName=schoolName;
        }
    }
}