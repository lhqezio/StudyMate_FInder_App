

namespace StudyMate
{

    public class SchoolManager{
        public List<School> schools {get; set;}

        public SchoolManager(){
            schools = new List<School>();
        }

        public List<School> LoadSchoolFile(string file){
            var lines = File.ReadAllLines(file).Skip(1);
            foreach (var line in lines)
            {
                string[] fields = line.Split(',');
                School school = new School(fields[0]);
                schools.Add(school);
            }
            return schools;
        }
    }

}