// using StudyMate;

// namespace StudyMateTests;

[TestClass]
public class EventCalendarTest
{
    [TestMethod]
    public void TestEventCalendarConstructor(){//Test 1 
        //Arrange
            //Users
        User user1 = new User("Alain", "sessionKey", "password");
        User user2 = new User("Sam", "sessionKey", "password1");
        User user3 = new User("Jack", "sessionKey", "password2");
            //User list
        List<User> userList = new List<User>();
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
        School sch1 = new School("Dawson College");
        List<School> schoolList = new List<School>(){sch1};
        string location = "Montreal";

        //Act
        EventCalendar eC = new EventCalendar("Title1", user1, userList, dTime, description, schoolList, eventCourses, location, sent);
        
        //Assert
        Assert.AreEqual("Title1", eC.Title);
        Assert.AreEqual(userDB1, eC.Owner);
        Assert.AreEqual(userList, eC.Participants);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(sent, eC.IsSent);
        Assert.AreEqual(eventCourses, eC.CourseList);
        Assert.AreEqual(subjectSchoolProjectList, eC.SubjectSchoolProjectList);
        Assert.IsInstanceOfType(eC, typeof(EventCalendar));
    }
}

