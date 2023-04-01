using System.Reflection.Metadata;
using System;
using src;
namespace StudyMateTests;

[TestClass]
public class EventCalendarTest
{
    [TestMethod]
    public void TestEventCalendarConstructor(){//Test 1 
        //Arrange
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
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, SubjectSchoolProjectList);
        
        //Assert
        Assert.AreEqual("Title1", eC.Title);
        Assert.AreEqual(profil1, eC.__creatorId);
        Assert.AreEqual(profileList, eC.Participants);
        Assert.AreEqual(dTime, eC.Date);
        Assert.AreEqual(sent, eC.isSent);
        Assert.AreEqual(description, eC.Description);
        Assert.AreEqual(eventCourses, eC.CourseList);
        Assert.AreEqual(subjectSchoolProjectList, eC.SubjectSchoolProjectList);
        Assert.IsInstanceOfType(eC, typeof(EventCalendar));
    }

    public void TestEventCalendarToString(){
        //Arrange
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
        EventCalendar eC = new EventCalendar("Title1", profil1, profileList, dTime, sent, description, eventCourses, SubjectSchoolProjectList);
        string eCprint =    "Title: Title1"+
                            " \nCreator: Alain"+
                            " \nParticipants: Sam, Jack, "+
                            " \nDate: "+this.Date+
                            " \nDescription: SDASDASDK DAS DDASKD DSAD ASASDDAS DA"+
                            " \nCourse(s), nSubject(s), School(s) associated: Informatique, Vaudreuil, StudyMate";

        //Assert
        Assert.AreEqual(eCprint, eC.ToString());


    }

}
