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
        User user1=new User("amirreza","PK1","1");
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = ProfileServices.getInstance(mockContext.Object);
        //Act
        service.AddProfile(new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)},user1,Genders.Male),user1);
        //Assert
        mockSet.Verify(p => p.Add(It.IsAny<Profile>()), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }
}