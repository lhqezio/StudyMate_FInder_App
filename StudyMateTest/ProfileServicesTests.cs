namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;

[TestClass]
public class ProfileServicesTests
{
    [TestMethod]
    public void AddProfileTest_AddsAProfileToDB_ReturnsVoid(){
        //Arrange
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = ProfileServices.getInstance(mockContext.Object);
        Profile profile1=new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male);
        Profile profile2=new Profile("Samanta",18,new School("Vanier College"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Math)},user2,Genders.Female);
        //Act
        profile1.ClearProfile();
        profile2.ClearProfile();
        //Assert
        Assert.AreEqual(profile1,profile2);
    }
}