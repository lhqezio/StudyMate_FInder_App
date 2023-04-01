using System;
using src;

namespace StudyMateTests;

[TestClass]
public class EventCalendarTest
{
    [TestMethod]
    public void TestEventCalendarConstructor(){//Test 1 
        //Arrange
        EventManager eM = new EventManager();
        
        //Act
        List<EventCalendar> lEvents = new List<EventCalendar>();

        //Assert
        Assert.AreEqual(lEvents, eM);
        Assert.IsInstanceOfType(eM, typeof(EventManager));
    }

    [TestMethod]
    public void TestEventCalendarAddEvent(){//Test 2 - Check if event is added to List
        //Arrange
        EventManager eM = new EventManager();
        
        List<Courses> nCourses1 = new List<Courses>(Art, Calculus, Math, History);
        List<Courses> nCourses2 = new List<Courses>(Business, Communication, Journalism, Political_Science);
        List<Courses> nCourses3 = new List<Courses>(Sciences, Statistics, Chemistry, Linear_Algebra);
        Profile profil1 = new Profile{"Alain", 25, "Hb", nCourses1};
        Profile profil2 = new Profile{"Sam", 20, "St-Ex", nCourses2};
        Profile profil3 = new Profile{"Jack", 15, "PST", nCourses3};
        List<Profile> profileList = new List<Profile>(profil2, profil3);
        DateTimeOffset dTime = new DateTimeOffset();
        bool sent = false;
        string description = "SDASDASDK DAS DDASKD DSAD ASASDDAS DA";
        List<Courses> eventCourses = new List<Courses>(Sciences, Art, Business, Math);
        List<string> subjectSchoolProjectList = new List<string>("Informatique, Vaudreuil, StudyMate");

        //Act
        eM.AddEvent(eC);
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, SubjectSchoolProjectList);

        //Assert
        Assert.AreEqual(eC, eM.listEvents[0]);
    }

    [TestMethod]
    public void TestEventCalendarAddEvent2(){//Test 3 - Check if event is good one in the List
        //Arrange
        EventManager eM = new EventManager();
        
        List<Courses> nCourses1 = new List<Courses>(Art, Calculus, Math, History);
        List<Courses> nCourses2 = new List<Courses>(Business, Communication, Journalism, Political_Science);
        List<Courses> nCourses3 = new List<Courses>(Sciences, Statistics, Chemistry, Linear_Algebra);
        Profile profil1 = new Profile{"Alain", 25, "Hb", nCourses1};
        Profile profil2 = new Profile{"Sam", 20, "St-Ex", nCourses2};
        Profile profil3 = new Profile{"Jack", 15, "PST", nCourses3};
        List<Profile> profileList = new List<Profile>(profil2, profil3);
        DateTimeOffset dTime = new DateTimeOffset();
        bool sent = false;
        string description = "SDASDASDK DAS DDASKD DSAD ASASDDAS DA";
        List<Courses> eventCourses = new List<Courses>(Sciences, Art, Business, Math);
        List<string> subjectSchoolProjectList = new List<string>("Informatique, Vaudreuil, StudyMate");

        //Act
        eM.AddEvent(eC);
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, SubjectSchoolProjectList);

        //Assert
        Assert.AreEqual(eC, eM.listEvents[0]);
    }

}