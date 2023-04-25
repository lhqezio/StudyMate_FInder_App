namespace StudyMateTest;
using StudyMate;
[TestClass]
public class ProfileTests
{
    [TestMethod]
    public void ClearProfileTest_MakesAllPropertiesNull_ReturnsVoid()
    {
        //Arrange
        User user1=new User("amirreza","PK1","1");
        User user2=new User("Samanta","PK2","2");
        Profile profile1=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        Profile profile2=new Profile("Samanta",18,new School("Vanier College"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Math)},user2,Genders.Female);
        //Act
        profile1.ClearProfile();
        profile2.ClearProfile();
        //Assert
        Assert.AreEqual(profile1,profile2);
    }

    // [TestMethod]
    // public void EqualsTest_ComparesTwoProfileObjects_ReturnsTrue()
    // {
    //     //Arrange
    //     UserDB userDB=new UserDB("amirreza","amir@example.com","ABCD","pwd");
    //     Profile profile1=new Profile("Amir",20,"Dawson College",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},userDB);
    //     Profile profile2=new Profile("Amir",20,"Dawson College",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},userDB);
    //     //Act
    //     bool AreEqual=profile1.Equals(profile2);
    //     //Assert
    //     Assert.AreEqual(true,AreEqual);
    // }

    // [TestMethod]
    // public void EqualsTest_ComparesTwoProfileObjects_ReturnsFalse()
    // {
    //     //Arrange
    //     UserDB userDB=new UserDB("amirreza","amir@example.com","ABCD","pwd");
    //     Profile profile1=new Profile("Amir",20,"Dawson College",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},userDB);
    //     Profile profile2=new Profile("Samanta",18,"Vanier",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},userDB);
    //     //Act
    //     bool AreNotEqual=profile1.Equals(profile2);
    //     //Assert
    //     Assert.AreEqual(false,AreNotEqual);
    // }

    // [TestMethod]
    // public void EqualsTest_ComparesProfileObjectWithSomethingElse_ReturnsFalse()
    // {
    //     //Arrange
    //     UserDB userDB=new UserDB("amirreza","amir@example.com","ABCD","pwd");
    //     Profile profile1=new Profile("Amir",20,"Dawson College",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},userDB);
    //     String s=new String("Hi");
    //     //Act
    //     bool AreNotEqual=profile1.Equals(s);
    //     //Assert
    //     Assert.AreEqual(false,AreNotEqual);
    // }
}