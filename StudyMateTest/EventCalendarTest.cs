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
            //Users
        var user1 = new User("1","Alain", "alain@hotmail.com", "password");
        var user2 = new User("2","Sam", "sam@hotmail.com", "password1");
        var user3 = new User("3","Jack", "jack@hotmail.com", "password2");
            //Profiles
        Profile profile1 = new Profile("1", user1, "Alain", "Male", new School("1", "Dawson College"), 20, "Computer Science"); 
        Profile profile2 = new Profile("2", user2, "Samantha", "Female", new School("2", "Vanier College"), 18, "Social Science");
        Profile profile3 = new Profile("3", user3, "Jackie", "Male", new School("3", "Henri-Bourrassa"), 19, "Business"); 
            //profileList list
        List<Profile> profileList = new List<Profile>();
        profileList.Add(profile2);
        profileList.Add(profile3);
        DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        bool sent = false;
        string description = "Study with the homies";
        School sch = new School("1", "Dawson College");

        //Act
        EventCalendar eC = new EventCalendar("1", "Title1", profile1, dTime, description, "Montreal", "Maths", sch);
        //     //Courses
        // List<EventCourse> eventCourses = new List<EventCourse>();
        // EventCourse ce1 = new EventCourse(eC, new Course("1", "Math"));
        // EventCourse ce2 = new EventCourse(eC, new Course("2", "Sciences"));
        // EventCourse ce3 = new EventCourse(eC, new Course("3", "Business"));
        // eventCourses.Add(ce1);
        // eventCourses.Add(ce2);
        // eventCourses.Add(ce3);


        //Assert
        Assert.AreEqual("Title1", eC.Title);
        Assert.AreEqual(profile1, eC.Creator);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(sent, eC.IsSent);
        Assert.AreEqual("Montreal", eC.Location);
        Assert.AreEqual("Maths", eC.Subjects);
        Assert.AreEqual(sch, eC.School);
        Assert.IsInstanceOfType(eC, typeof(EventCalendar));
    }

    // [TestMethod]
    // public void TestEventCalendarAddParticipant(){//Test 2
    //     //Arrange
    //     School sch1 = new School("Dawson College");
    //     School sch2 = new School("Henri-Bourassa");
    //     School sch3 = new School("Saint-Ex");
    //         //Users
    //     var user1 = new User("1","Alain", "alain@hotmail.com", "password");
    //     var user2 = new User("2","Sam", "sam@hotmail.com", "password1");
    //     var user3 = new User("3","Jack", "jack@hotmail.com", "password2");
    //         //Profiles
    //     Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
    //     Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
    //     Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
    //         //profileList list
    //     List<Profile> profileList = new List<Profile>();
    //     profileList.Add(profile2);
    //     DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
    //     bool sent = false;
    //     string description = "Study with the homies";
    //         //Courses
    //     List<CourseEvent> eventCourses = new List<CourseEvent>();
    //     CourseEvent ce1 = new CourseEvent(Courses.Math);
    //     CourseEvent ce2 = new CourseEvent(Courses.Sciences);
    //     CourseEvent ce3 = new CourseEvent(Courses.Business);
    //     eventCourses.Add(ce1);
    //     eventCourses.Add(ce2);
    //     eventCourses.Add(ce3);
    //     School schoolList = sch1;
    //     string location = "Montreal";

    //     //Act
    //     EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
    //         //Add user3 to Event
    //     eC.AddParticipant(profile3); 
    //         //Add user3 to profileList
    //     profileList.Add(profile3);

    //     //Assert
    //     Assert.AreEqual(profileList, eC.Participants);
    // }

    // [TestMethod]
    // public void TestEventCalendarRemoveParticipant(){//Test 3
    //     //Arrange
    //     School sch1 = new School("Dawson College");
    //     School sch2 = new School("Henri-Bourassa");
    //     School sch3 = new School("Saint-Ex");
    //         //Users
    //     var user1 = new User("1","Alain", "alain@hotmail.com", "password");
    //     var user2 = new User("2","Sam", "sam@hotmail.com", "password1");
    //     var user3 = new User("3","Jack", "jack@hotmail.com", "password2");
    //         //Profiles
    //     Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
    //     Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
    //     Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
    //         //profileList list
    //     List<Profile> profileList = new List<Profile>();
    //     profileList.Add(profile2);
    //     profileList.Add(profile3);
    //     DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
    //     bool sent = false;
    //     string description = "Study with the homies";
    //         //Courses
    //     List<CourseEvent> eventCourses = new List<CourseEvent>();
    //     CourseEvent ce1 = new CourseEvent(Courses.Math);
    //     CourseEvent ce2 = new CourseEvent(Courses.Sciences);
    //     CourseEvent ce3 = new CourseEvent(Courses.Business);
    //     eventCourses.Add(ce1);
    //     eventCourses.Add(ce2);
    //     eventCourses.Add(ce3);
    //     School schoolList = sch1;
    //     string location = "Montreal";

    //     //Act
    //     EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
    //         //Removed profile3 to Event
    //     eC.RemoveParticipant(profile3); 
    //         //Removed user3 to userList
    //     profileList.Remove(profile3);

    //     //Assert
    //     Assert.AreEqual(profileList, eC.Participants);
    // }

    // [TestMethod]
    // public void TestEventCalendarAttends(){//Test 4
    //     //Arrange
    //     School sch1 = new School("Dawson College");
    //     School sch2 = new School("Henri-Bourassa");
    //     School sch3 = new School("Saint-Ex");
    //         //Users
    //     var user1 = new User("1","Alain", "alain@hotmail.com", "password");
    //     var user2 = new User("2","Sam", "sam@hotmail.com", "password1");
    //     var user3 = new User("3","Jack", "jack@hotmail.com", "password2");
    //         //Profiles
    //     Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
    //     Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
    //     Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
    //         //profileList list
    //     List<Profile> profileList = new List<Profile>();
    //     profileList.Add(profile2);
    //     profileList.Add(profile3);
    //     DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
    //     bool sent = false;
    //     string description = "Study with the homies";
    //         //Courses
    //     List<CourseEvent> eventCourses = new List<CourseEvent>();
    //     CourseEvent ce1 = new CourseEvent(Courses.Math);
    //     CourseEvent ce2 = new CourseEvent(Courses.Sciences);
    //     CourseEvent ce3 = new CourseEvent(Courses.Business);
    //     eventCourses.Add(ce1);
    //     eventCourses.Add(ce2);
    //     eventCourses.Add(ce3);
    //     School schoolList = sch1;
    //     string location = "Montreal";

    //     //Act
    //     EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
        
    //     //Assert
    //     Assert.IsTrue(eC.Attends(profile2));
    //     Assert.IsTrue(eC.Attends(profile3));
    // }
}

