using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudyMate
{

    public class SchoolManager{
        public List<string> schools {get; set;}

        public SchoolManager(){
            schools = new List<string>();
        }

        public List<string> LoadSchoolFile(string file){
            var lines = File.ReadAllLines(file).Skip(1);
            foreach (var line in lines)
            {
                string[] fields = line.Split(',');
                schools.Add(fields[0]);
            }
            return schools;
        }
    }

}