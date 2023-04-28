using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudyMateTests;

[TestClass]
public class EventCalendarTest
{
    [TestMethod]
    public void TestEventCalendarConstructor(){//Test 1 
        //Arrange
        School sch1 = new School("Dawson College");
        School sch2 = new School("Henri-Bourassa");
        School sch3 = new School("Saint-Ex");
            //Users
        Profile user1 = new Profile("Alain", "alain@hotmail.com", "password");
        Profile user2 = new Profile("Sam", "sam@hotmail.com", "password1");
        Profile user3 = new Profile("Jack", "jack@hotmail.com", "password2");
            //userLis list
        List<Profile> userList = new List<Profile>();
        userList.Add(user2);
        userList.Add(user3);
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

        //Act
        EventCalendar eC = new EventCalendar("Title1", user1, userList, dTime, description, schoolList, eventCourses, location, sent);
        
        //Assert
        Assert.AreEqual("Title1", eC.Title);
        Assert.AreEqual(user1, eC.EventCreator);
        Assert.AreEqual(userList, eC.Participants);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(sent, eC.IsSent);
        Assert.AreEqual(eventCourses, eC.CourseEvents);
        Assert.AreEqual(schoolList, eC.School);
        Assert.IsInstanceOfType(eC, typeof(EventCalendar));
    }

    [TestMethod]
    public void TestEventCalendarAddParticipant(){//Test 2
        //Arrange
        School sch1 = new School("Dawson College");
        School sch2 = new School("Henri-Bourassa");
        School sch3 = new School("Saint-Ex");
            //Users
        Profile user1 = new Profile("Alain", "alain@hotmail.com", "password");
        Profile user2 = new Profile("Sam", "sam@hotmail.com", "password1");
        Profile user3 = new Profile("Jack", "jack@hotmail.com", "password2");
            //userLis list
        List<Profile> userList = new List<Profile>();
        userList.Add(user2);
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

        //Act
        EventCalendar eC = new EventCalendar("Title1", user1, userList, dTime, description, schoolList, eventCourses, location, sent);
            //Add user3 to Event
        eC.AddParticipant(user3); 
            //Add user3 to profileList
        userList.Add(user3);

        //Assert
        Assert.AreEqual(userList, eC.Participants);
    }

    [TestMethod]
    public void TestEventCalendarRemoveParticipant(){//Test 3
        //Arrange
        School sch1 = new School("Dawson College");
        School sch2 = new School("Henri-Bourassa");
        School sch3 = new School("Saint-Ex");
            //Users
        Profile user1 = new Profile("Alain", "alain@hotmail.com", "password");
        Profile user2 = new Profile("Sam", "sam@hotmail.com", "password1");
        Profile user3 = new Profile("Jack", "jack@hotmail.com", "password2");
            //userLis list
        List<Profile> userList = new List<Profile>();
        userList.Add(user2);
        userList.Add(user3);
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

        //Act
            //Contains user3
        EventCalendar eC = new EventCalendar("Title1", user1, userList, dTime, description, schoolList, eventCourses, location, sent);
            //Removed user3 to Event
        eC.RemoveParticipant(user3); 
            //Removed user3 to userList
        userList.Remove(user3);

        //Assert
        Assert.AreEqual(userList, eC.Participants);
    }

    [TestMethod]
    public void TestEventCalendarAttends(){//Test 4
        //Arrange
        School sch1 = new School("Dawson College");
        School sch2 = new School("Henri-Bourassa");
        School sch3 = new School("Saint-Ex");
            //Users
        Profile user1 = new Profile("Alain", "alain@hotmail.com", "password");
        Profile user2 = new Profile("Sam", "sam@hotmail.com", "password1");
        Profile user3 = new Profile("Jack", "jack@hotmail.com", "password2");
            //userLis list
        List<Profile> userList = new List<Profile>();
        userList.Add(user2);
        userList.Add(user3);
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

        //Act
            //Contains user3
        EventCalendar eC = new EventCalendar("Title1", user1, userList, dTime, description, schoolList, eventCourses, location, sent);
        
        //Assert
        Assert.IsTrue(eC.Attends(user2));
        Assert.IsTrue(eC.Attends(user3));
    }
}

