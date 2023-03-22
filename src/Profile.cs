// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
namespace StudyMate
{
    public class Profile{
        public string Name 
        { get; set; }
        public string? Pronouns 
        { get; set; }
        public int Age
        {get;set;}
        public string School
        {get;set;}
        public string? Program 
        { get; set; }
        public Courses? TakenCourses
        {get;set;}
        public Courses NeedHelpCourse
        {get;set;}
        public string? PersonalDescription
        {get;set;}
        public string? ProfilePicture //Subjet to change
        {get;set;}
        public Interests? Hobbies
        {get;set;}

        public Profile(string name, int age, string school,Courses needHelpCourse)
        {
            Name = name;
            Age = age;
            School=school;
            NeedHelpCourse=needHelpCourse;
        }

        // public static void Main(string[] args){
        //     List<string> myList=new List<string>{"a","b","c"};
        //     List<string> myList2=myList;
        //     myList[0]="hi";
        //     System.Console.WriteLine(myList2[0]);
        // }
    }
}
