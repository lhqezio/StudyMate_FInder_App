namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
[TestClass]
public class ProfileTests
{
    [TestMethod]
    public void ClearProfileTest_MakesAllPropertiesNull_ReturnsVoid()
    {
        //Arrange
        var user1=new User("amirreza","PK1","1");
        var user2=new User("Samanta","PK2","2");
        Profile profile1=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        Profile profile2=new Profile("Samanta",18,new School("Vanier College"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Math)},user2,Genders.Female);
        //Act
        profile1.ClearProfile();
        profile2.ClearProfile();
        //Assert
        Assert.AreEqual(profile1,profile2);
    }

    [TestMethod]
    public void EqualsTest_ComparesTwoProfileObjects_ReturnsTrue()
    {
        //Arrange
        var user1=new User("amirreza","PK1","1");
        var user2=new User("Samanta","PK2","2");
        Profile profile1=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        Profile profile2=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        //Act
        bool AreEqual=profile1.Equals(profile2);
        //Assert
        Assert.AreEqual(true,AreEqual);
    }

    [TestMethod]
    public void EqualsTest_ComparesTwoProfileObjects_ReturnsFalse()
    {
        //Arrange
        var user1=new User("amirreza","PK1","1");
        var user2=new User("Samanta","PK2","2");
        Profile profile1=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        Profile profile2=new Profile("Samanta",18,new School("Vanier College"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Math)},user2,Genders.Female);
        //Act
        bool AreNotEqual=profile1.Equals(profile2);
        //Assert
        Assert.AreEqual(false,AreNotEqual);
    }

    [TestMethod]
    public void EqualsTest_ComparesProfileObjectWithSomethingElse_ReturnsFalse()
    {
        //Arrange
        var user1=new User("amirreza","PK1","1");
        Profile profile1=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        String s=new String("Hi");
        //Act
        bool AreNotEqual=profile1.Equals(s);
        //Assert
        Assert.AreEqual(false,AreNotEqual);
    }
}