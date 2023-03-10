// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
namespace StudyMate
{
    public class Profile{
        private string? _name;
        public string Name{
            get{
                if(_name!=null){
                    return _name;
                    }
                return "";
                }
            set{_name=value;}
        }
        private int _age;
        public int Age{
            get{return _age;}
            set{_age=value;}
        }

        public Profile(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // public static void Main(string[] args){
        //     List<string> myList=new List<string>{"a","b","c"};
        //     List<string> myList2=myList;
        //     myList[0]="hi";
        //     System.Console.WriteLine(myList2[0]);
        // }
    }
}
