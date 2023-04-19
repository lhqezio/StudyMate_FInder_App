using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;


namespace Study
{

    public class School{
        public string Name {get; set;}

        public School(string name){
            Name = name;
        }

        public List<School> LoadSchoolFile(string file){
            List<School> schools = new List<School>();
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