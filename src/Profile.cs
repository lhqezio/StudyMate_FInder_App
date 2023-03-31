﻿// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
namespace StudyMate
{
    public class Profile{
        public string? Name 
        { get; set; }
        public string? Pronouns 
        { get; set; }
        public int? Age
        {get;set;}
        public string? School
        {get;set;}
        public string? Program 
        { get; set; }
        public List<Courses>? TakenCourses
        {get;set;}
        public List<Courses>? NeedHelpCourses
        {get;set;}
        public string? PersonalDescription
        {get;set;}
        public string? ProfilePicture //Subjet to change
        {get;set;}
        public List<Interests>? Hobbies
        {get;set;}

        public Profile(string name, int age, string school,List<Courses> needHelpCourses)
        {
            Name = name;
            Age = age;
            School=school;
            NeedHelpCourses=needHelpCourses;
        }

        public void ClearProfile(){
            Pronouns=null;
            Age=null;
            School=null;
            Program=null;
            TakenCourses=null;
            NeedHelpCourses=null;
            PersonalDescription=null;
            ProfilePicture=null;
            Hobbies=null;

        }
        public static void Main(string[] args){
            Profile profile=new Profile("Amir",12,"Akabar gholi",new List<Courses>(){Courses.Art});
            profile.NeedHelpCourses.Add(Courses.History);
            System.Console.WriteLine(profile.NeedHelpCourses[1]);
        }
    }
}
