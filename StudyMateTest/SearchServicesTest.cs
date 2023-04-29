namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;

    [TestClass]
    public class SearchServicesTest
    {
        //Since this information will be reused,  I added it as global 
        public static School sch1 = new School("Dawson College");
        public static School sch2 = new School("Henri-Bourassa");
        public static School sch3 = new School("Saint-Ex");
                //Users
        public static User user1 = new User("1","Alain", "alain@hotmail.com", "password");
        public static User user2 = new User("2","Sam", "sam@hotmail.com", "password1");
        public static User user3 = new User("3","Jack", "jack@hotmail.com", "password2");
                //Profiles
        public static Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
        public static Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
        public static Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
                //profileList list
        public static List<Profile> profileList = new List<Profile>(){profile2, profile3};
        public static DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        public static bool sent = false;
        public static string description = "Study with the homies";
                //Courses
        public static CourseEvent ce1 = new CourseEvent(Courses.Math);
        public static CourseEvent ce2 = new CourseEvent(Courses.Sciences);
        public static CourseEvent ce3 = new CourseEvent(Courses.Business);
        public static List<CourseEvent> eventCourses = new List<CourseEvent>(){ce1, ce2, ce3};
        public static School schoolList = sch1;
        public static string location = "Montreal";

        [TestMethod]
        public void Test_SearchServices_SearchEventsCourseSchool(){
        }

}
    

