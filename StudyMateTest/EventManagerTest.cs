
using StudyMate;

namespace StudyMateTests;

[TestClass]
public class EventTest
{
    [TestMethod]
    public void TestEventManagerConstructor(){//Test 1 
        //Arrange
        EventManager eM = new EventManager();
        //Act
        List<EventCalendar> lEvents = new List<EventCalendar>();
        //Assert
        Assert.ReferenceEquals(lEvents, eM.listEvents);
        Assert.IsInstanceOfType(eM, typeof(EventManager));
    }

    [TestMethod]
    public void TestEventCalendarAddEvent(){//Test 2 - Check if event is added to List
        //Arrange
        EventManager eM = new EventManager();
        
        List<Courses> nCourses1 = new List<Courses>(){Courses.Art, Courses.Calculus, Courses.Math, Courses.History};
        List<Courses> nCourses2 = new List<Courses>(){Courses.Business, Courses.Communication, Courses.Journalism, Courses.Political_Science};
        List<Courses> nCourses3 = new List<Courses>(){Courses.Sciences, Courses.Statistics, Courses.Chemistry, Courses.Linear_Algebra};
        UserDB userDB1 = new UserDB("Alain", "alain@hotmail.com", "salt", "password");
        UserDB userDB2 = new UserDB("Sam", "sam@hotmail.com", "salt", "password1");
        UserDB userDB3 = new UserDB("Jack", "jack@hotmail.com", "salt", "password2");
        Profile profil1 = new Profile("Alain", 25, "Henri Bourassa", nCourses1, userDB1);
        Profile profil2 = new Profile("Sam", 20, "St-Ex", nCourses2, userDB2);
        Profile profil3 = new Profile("Jack", 15, "PST", nCourses3, userDB3);
        List<Profile> profileList = new List<Profile>(){profil2, profil3};
        DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        bool sent = false;
        string description = "Study with the homies";
        List<Courses> eventCourses = new List<Courses>(){Courses.Sciences, Courses.Art, Courses.Business, Courses.Math};
        List<string> subjectSchoolProjectList = new List<string>(){"Informatique, Vaudreuil, StudyMate"};


        //Act
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, subjectSchoolProjectList);
        eM.AddEvent(eC);

        //Assert
        Assert.AreEqual(eC, eM.listEvents[0]);
    }

    [TestMethod]
    public void TestEventCalendarDeleteEvent(){//Test 3 - Check if event is deleted to List
        //Arrange
        EventManager eM = new EventManager();
        
        List<Courses> nCourses1 = new List<Courses>(){Courses.Art, Courses.Calculus, Courses.Math, Courses.History};
        List<Courses> nCourses2 = new List<Courses>(){Courses.Business, Courses.Communication, Courses.Journalism, Courses.Political_Science};
        List<Courses> nCourses3 = new List<Courses>(){Courses.Sciences, Courses.Statistics, Courses.Chemistry, Courses.Linear_Algebra};
        UserDB userDB1 = new UserDB("Alain", "alain@hotmail.com", "salt", "password");
        UserDB userDB2 = new UserDB("Sam", "sam@hotmail.com", "salt", "password1");
        UserDB userDB3 = new UserDB("Jack", "jack@hotmail.com", "salt", "password2");
        Profile profil1 = new Profile("Alain", 25, "Henri Bourassa", nCourses1, userDB1);
        Profile profil2 = new Profile("Sam", 20, "St-Ex", nCourses2, userDB2);
        Profile profil3 = new Profile("Jack", 15, "PST", nCourses3, userDB3);
        List<Profile> profileList = new List<Profile>(){profil2, profil3};
        DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        bool sent = false;
        string description = "Study with the homies";
        List<Courses> eventCourses = new List<Courses>(){Courses.Sciences, Courses.Art, Courses.Business, Courses.Math};
        List<string> subjectSchoolProjectList = new List<string>(){"Informatique, Vaudreuil, StudyMate"};


        //Act
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, subjectSchoolProjectList);
        eM.AddEvent(eC);
        eM.DeleteEvent(eC);

        //Assert
        Assert.IsFalse(eM.listEvents.Any());
    }
}
