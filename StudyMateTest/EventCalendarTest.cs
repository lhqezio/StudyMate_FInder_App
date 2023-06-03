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
        Profile profile1 = new Profile(user1, "Alain", "Male", new School("Dawson College"), new List<Course>(){new Course("Programming IV")}, new List<Course>(){ new Course("Humanities")}, new List<Course>(){ new Course("Web Dev")}, new List<Hobby>(){ new Hobby("Anime")}, 20, "Computer Science", "Hi I'm new here"); 
        Profile profile2 = new Profile(user2, "Samantha", "Female", new School("Vanier College"), new List<Course>(){new Course("English")}, new List<Course>(){new Course("History")}, new List<Course>(){ new Course("Political Science")}, new List<Hobby>(){ new Hobby("Basket")}, 18, "Social Science", "I hope to meet new people");
        Profile profile3 = new Profile(user3, "Jackie", "Male", new School("Henri-Bourrassa"), new List<Course>(){new Course("Communication")}, new List<Course>(){new Course("French")}, new List<Course>(){ new Course("Business Creation")}, new List<Hobby>(){ new Hobby("Swimming")}, 21, "Business", "My name is Jackie. What's yours?"); 
            //profileList list
        List<Profile> profileList = new List<Profile>();
        profileList.Add(profile2);
        profileList.Add(profile3);
        DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        bool sent = false;
        string description = "We are going to study for humanities exam";
        School sch = new School("Dawson College");

        //Act
        Event eC = new Event(profile1, "Studying Humanities", dTime, "We are going to study for humanities exam", "Chez Saza", "Humanities Exam", new List<Course>(){ new Course("Humanities")}, sch);
        


        //Assert
        Assert.AreEqual("Studying Humanities", eC.Title);
        Assert.AreEqual(profile1, eC.Creator);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(sent, eC.IsSent);
        Assert.AreEqual("Chez Saza", eC.Location);
        Assert.AreEqual("Humanities Exam", eC.Subjects);
        Assert.AreEqual(sch, eC.School);
        Assert.IsInstanceOfType(eC, typeof(Event));
    }

    [TestMethod]
    public void TestEventCalendarAddParticipant(){//Test 2
        //Arrange
            //Users
        var user1 = new User("1","Alain", "alain@hotmail.com", "password");
        var user2 = new User("2","Sam", "sam@hotmail.com", "password1");
        var user3 = new User("3","Jack", "jack@hotmail.com", "password2");
            //Profiles
        Profile profile1 = new Profile(user1, "Alain", "Male", new School("Dawson College"), new List<Course>(){new Course("Programming IV")}, new List<Course>(){ new Course("Humanities")}, new List<Course>(){ new Course("Web Dev")}, new List<Hobby>(){ new Hobby("Anime")}, 20, "Computer Science", "Hi I'm new here"); 
        Profile profile2 = new Profile(user2, "Samantha", "Female", new School("Vanier College"), new List<Course>(){new Course("English")}, new List<Course>(){new Course("History")}, new List<Course>(){ new Course("Political Science")}, new List<Hobby>(){ new Hobby("Basket")}, 18, "Social Science", "I hope to meet new people");
        Profile profile3 = new Profile(user3, "Jackie", "Male", new School("Henri-Bourrassa"), new List<Course>(){new Course("Communication")}, new List<Course>(){new Course("French")}, new List<Course>(){ new Course("Business Creation")}, new List<Hobby>(){ new Hobby("Swimming")}, 21, "Business", "My name is Jackie. What's yours?"); 
            //profileList list
        List<Profile> profileList = new List<Profile>();
        DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        School sch = new School("Dawson College");

        //Act
        Event eC = new Event(profile1, "Studying Humanities", dTime, "We are going to study for humanities exam", "Chez Saza", "Humanities Exam", new List<Course>(){ new Course("Humanities")}, sch);
            //Add user3 to Event
        eC.AddParticipant(profile3); 
            //Add user3 to profileList
        profileList.Add(profile3);

        //Assert
        CollectionAssert.AreEquivalent(profileList, eC.Participants);
    }

    [TestMethod]
    public void TestEventCalendarRemoveParticipant(){//Test 3
        //Arrange
            //Users
        var user1 = new User("1","Alain", "alain@hotmail.com", "password");
        var user2 = new User("2","Sam", "sam@hotmail.com", "password1");
        var user3 = new User("3","Jack", "jack@hotmail.com", "password2");
            //Profiles
        Profile profile1 = new Profile(user1, "Alain", "Male", new School("Dawson College"), new List<Course>(){new Course("Programming IV")}, new List<Course>(){ new Course("Humanities")}, new List<Course>(){ new Course("Web Dev")}, new List<Hobby>(){ new Hobby("Anime")}, 20, "Computer Science", "Hi I'm new here"); 
        Profile profile2 = new Profile(user2, "Samantha", "Female", new School("Vanier College"), new List<Course>(){new Course("English")}, new List<Course>(){new Course("History")}, new List<Course>(){ new Course("Political Science")}, new List<Hobby>(){ new Hobby("Basket")}, 18, "Social Science", "I hope to meet new people");
        Profile profile3 = new Profile(user3, "Jackie", "Male", new School("Henri-Bourrassa"), new List<Course>(){new Course("Communication")}, new List<Course>(){new Course("French")}, new List<Course>(){ new Course("Business Creation")}, new List<Hobby>(){ new Hobby("Swimming")}, 21, "Business", "My name is Jackie. What's yours?"); 
            //profileList list
        List<Profile> profileList = new List<Profile>();
        DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        School sch = new School("Dawson College");

        //Act
        Event eC = new Event(profile1, "Studying Humanities", dTime, "We are going to study for humanities exam", "Chez Saza", "Humanities Exam", new List<Course>(){ new Course("Humanities")}, sch);
        eC.AddParticipant(profile2);
        eC.AddParticipant(profile3);
        profileList.Add(profile2);
        profileList.Add(profile3);
            //Removed profile3 to Event
        eC.RemoveParticipant(profile3); 
            //Removed user3 to userList
        profileList.Remove(profile3);

        //Assert
        Assert.AreEqual(profileList, eC.Participants);
    }

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

