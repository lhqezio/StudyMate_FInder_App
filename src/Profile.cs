// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
namespace StudyMate
{
    public class Profile{
        private string _name;
        public string Name{
            get{return _name;}
            set{_name=value;}
        }
        private int _age;
        public int Age{
            get{return _age;}
            set{_age=value;}
        }
        private List<string> _coursesTaken;
        private List<string> _needHelpCourses;
        private List<string> _canHelpCourses;
        private List<string> _interests;
        public Profile(string name, int age, List<string> coursesTaken, List<string> needHelpCourses, List<string> canHelpCourses, List<string> interests){
            _name = name;
            _age = age;
            _coursesTaken = coursesTaken;
            _needHelpCourses = needHelpCourses;
            _canHelpCourses = canHelpCourses;
            _interests = interests;
        }
        // public List<string> ListCopier(List<string> oldList>){
        //     List<string> newList
        // }
        public static void Main(string[] args){
            List<string> myList=new List<string>{"a","b","c"};
            List<string> myList2=myList;
            myList[0]="hi";
            System.Console.WriteLine(myList2[0]);
        }
    }
}
