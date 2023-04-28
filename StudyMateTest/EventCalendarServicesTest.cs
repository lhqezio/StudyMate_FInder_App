namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace StudyMateTests;

[TestClass]
public class EventCalendarServicesTest
{
    //Since this information will be reused,  I added it as global 
    School sch1 = new School("Dawson College");
    School sch2 = new School("Henri-Bourassa");
    School sch3 = new School("Saint-Ex");
        //Users
    User user1 = new User("Alain", "alain@hotmail.com", "password");
    User user2 = new User("Sam", "sam@hotmail.com", "password1");
    User user3 = new User("Jack", "jack@hotmail.com", "password2");
        //Profiles
    Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
    Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
    Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
        //profileList list
    List<Profile> profileList = new List<Profile>();
    profileList.Add(profile2);
    profileList.Add(profile3);
    DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
    bool sent = false;
    string description = "Study with the homies";
        //Courses
    List<CourseEvent> eventCourses = new List<CourseEvent>();
    CourseEvent ce1 = new CourseEvent(Courses.Math);
    CourseEvent ce2 = new CourseEvent(Courses.Sciences);
    CourseEvent ce3 = new CourseEvent(Courses.Business);
    eventCourses.Add(ce1);
    eventCourses.Add(ce2);
    eventCourses.Add(ce3);
    School schoolList = sch1;
    string location = "Montreal";

    [TestMethod]
    public void Test_EventCalendarServices_AddEvent(){
        //Arrange
        EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
        var mockSet = new Mock<DbSet<EventCalendar>>();
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Events).Returns(mockSet.Object);
        
        //Act
        service.
        //Assert

    }
}
