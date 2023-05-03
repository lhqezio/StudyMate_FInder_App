using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Hobby{
        [Key]
        public int HobbyId{get;set;}

        public string HobbyName{get;set;}

        //Many-to-Many (Profile - Hobby)
        [InverseProperty("Hobbies")]
        public List<Profile> Profiles {get; set;}
        public Hobby(){}
        public Hobby(string hobbyName){
            HobbyName=hobbyName;
        }
    }
}