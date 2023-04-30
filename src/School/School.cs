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
        public EventCalendar? Event {get; set;}
        
        public School(){}
        public School(string schoolId,string schoolName){
            this.SchoolId=schoolId;
            this.SchoolName=schoolName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not School other)
                return false;
            return SchoolName == other.SchoolName;
        }

        public override int GetHashCode()
        {
            return SchoolName.GetHashCode();
        }
    }
}