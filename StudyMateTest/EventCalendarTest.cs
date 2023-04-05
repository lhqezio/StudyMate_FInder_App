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
        Profile profil1 = new Profile("Alain", 25, "Hb", nCourses1);
        Profile profil2 = new Profile("Sam", 20, "St-Ex", nCourses2);
        Profile profil3 = new Profile("Jack", 15, "PST", nCourses3);
        List<Profile> profileList = new List<Profile>(){profil2, profil3};
        DateTimeOffset dTime = new DateTimeOffset();
        bool sent = false;
        string description = "SDASDASDK DAS DDASKD DSAD ASASDDAS DA";
        List<Courses> eventCourses = new List<Courses>(){Courses.Sciences, Courses.Art, Courses.Business, Courses.Math};
        List<string> subjectSchoolProjectList = new List<string>(){"Informatique, Vaudreuil, StudyMate"};

        //Act
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, subjectSchoolProjectList);
        
        //Assert
        Assert.AreEqual("Title1", eC.Title);
        Assert.AreEqual(profil1, eC.__creatorId);
        Assert.AreEqual(profileList, eC.Participants);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(sent, eC.IsSent);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(eventCourses, eC.CourseList);
        Assert.AreEqual(subjectSchoolProjectList, eC.SubjectSchoolProjectList);
        Assert.IsInstanceOfType(eC, typeof(EventCalendar));
    }
    
    [TestMethod]
    public void TestEventCalendarToString(){
        //Arrange
        List<Courses> nCourses1 = new List<Courses>(){Courses.Art, Courses.Calculus, Courses.Math, Courses.History};
        List<Courses> nCourses2 = new List<Courses>(){Courses.Business, Courses.Communication, Courses.Journalism, Courses.Political_Science};
        List<Courses> nCourses3 = new List<Courses>(){Courses.Sciences, Courses.Statistics, Courses.Chemistry, Courses.Linear_Algebra};
        Profile profil1 = new Profile("Alain", 25, "Hb", nCourses1);
        Profile profil2 = new Profile("Sam", 20, "St-Ex", nCourses2);
        Profile profil3 = new Profile("Jack", 15, "PST", nCourses3);
        List<Profile> profileList = new List<Profile>(){profil2, profil3};
        DateTimeOffset dTime = new DateTimeOffset();
        bool sent = false;
        string description = "SDASDASDK DAS DDASKD DSAD ASASDDAS DA";
        List<Courses> eventCourses = new List<Courses>(){Courses.Sciences, Courses.Art, Courses.Business, Courses.Math};
        List<string> subjectSchoolProjectList = new List<string>(){"Informatique, Vaudreuil, StudyMate"};
        

        //Act
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, subjectSchoolProjectList);
        string eCprint =    "Title: Title1"+
                            " \nCreator: Alain"+
                            " \nParticipants: Sam, Jack, "+
                            " \nDate: "+eC.Date+
                            " \nDescription: SDASDASDK DAS DDASKD DSAD ASASDDAS DA"+
                            " \nCourse(s), nSubject(s), School(s) associated: Informatique, Vaudreuil, StudyMate";

        //Assert
        Assert.AreEqual(eCprint, eC.ToString());


    }

}
