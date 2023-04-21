using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{

    public class School{
        [Key]
        public string SchoolId{get;set;}
        public string Name {get; set;}

        public List<EventCalendar> Event{get;set;}=new();
        public List<Profile> Profile{get;set;}=new();

        public School(){}
        public School(string name){
            SchoolId=Guid.NewGuid().ToString();
            Name = name;
        }
    }

}