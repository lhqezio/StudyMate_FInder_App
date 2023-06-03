using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate.Models
{
    public class Hobby{
        [Key]
        public int HobbyId{get;set;}

        public string HobbyName{get;set;} = null!;

        //Many-to-Many (Profile - Hobby)
        [InverseProperty("Hobbies")]
        public List<Profile> Profiles {get; set;} = new List<Profile>();
        public Hobby(){}
        public Hobby(string hobbyName){
            HobbyName=hobbyName;
        }
    }
}