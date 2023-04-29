using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Hobby{
        public string HobbyId{get;set;}
        public string HobbyName{get;set;}
        public List<Profile> Profiles {get;} = new();
        public Hobby(){}
        public Hobby(string hobbyId,string hobbyName){
            this.HobbyId=hobbyId;
            this.HobbyName=hobbyName;
        }
    }
}