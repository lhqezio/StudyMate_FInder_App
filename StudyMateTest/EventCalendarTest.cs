using StudyMate;

namespace StudyMateTests;

[TestClass]
public class EventCalendarTest
{
    [TestMethod]
    public void TestEventCalendarConstructor(){//Test 1 
        //Arrange
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

//         //Act
//         EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, subjectSchoolProjectList);
        
        //Assert
        Assert.AreEqual("Title1", eC.Title);
        //Assert.AreEqual(profil1, eC.Creator.);
        Assert.AreEqual(profileList, eC.Participants);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(sent, eC.IsSent);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(eventCourses, eC.CourseList);
        Assert.AreEqual(subjectSchoolProjectList, eC.SubjectSchoolProjectList);
        Assert.IsInstanceOfType(eC, typeof(EventCalendar));
    }
}

