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
        var user1=new User("amirreza","PK1","1","password");
        var user2=new User("Samanta","PK2","2","password");
        Profile profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        Profile profile2 = new Profile("2",user2, "Samanta", "Female", new School("2", "Vanier College"), 18, "Social Science");
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
        var user1=new User("amirreza","PK1","1","password");
        var user2=new User("Samanta","PK2","2","password");
        Profile profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        Profile profile2 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        //Act
        bool AreEqual=profile1.Equals(profile2);
        //Assert
        Assert.AreEqual(true,AreEqual);
    }

    [TestMethod]
    public void EqualsTest_ComparesTwoProfileObjects_ReturnsFalse()
    {
        //Arrange
        var user1=new User("amirreza","PK1","1","password");
        var user2=new User("Samanta","PK2","2","password");
        Profile profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        Profile profile2 = new Profile("2",user2, "Samanta", "Female", new School("2", "Vanier College"), 18, "Social Science");
        //Act
        bool AreNotEqual=profile1.Equals(profile2);
        //Assert
        Assert.AreEqual(false,AreNotEqual);
    }

    [TestMethod]
    public void EqualsTest_ComparesProfileObjectWithSomethingElse_ReturnsFalse()
    {
        //Arrange
        var user1=new User("amirreza","PK1","1","password");
        Profile profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        String s=new String("Hi");
        //Act
        bool AreNotEqual=profile1.Equals(s);
        //Assert
        Assert.AreEqual(false,AreNotEqual);
    }
}