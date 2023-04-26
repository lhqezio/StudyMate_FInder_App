using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{

    public class School{
        [Key]
        public string SchoolId {get;set;}
        public string Name {get; set;}

        public List<EventCalendar> Events {get;}=new();
        public List<Profile> Profiles {get;}=new();

        public School(){}
        public School(string name){
            SchoolId=Guid.NewGuid().ToString();
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not School other)
                return false;
            return Name == other.Name;
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

}