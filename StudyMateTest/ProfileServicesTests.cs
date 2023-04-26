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

    [TestMethod]
    public void DeleteProfileTest_DeletesAProfileFromDB_ReturnsVoid()
    {
        // Arrange
        User user1 = new User("amirreza", "PK1", "1");
        var profileToDelete = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = ProfileServices.getInstance(mockContext.Object);
        // Act
        service.DeleteProfile(profileToDelete, user1);
        // Assert
        mockSet.Verify(p => p.Remove(It.IsAny<Profile>()), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void UpdateProfileTest_UpdatesProfileInDB_ReturnsVoid(){
        //Arrange
        User user1 = new User("amirreza", "PK1", "1");
        Profile profileToUpdate = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
        Profile updateProfile = new Profile("Amirreza", 27, new School("Concordia University"), "Art", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Journalism), new NeedHelpCourses(Courses.Art) }, user1, Genders.Male);
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = ProfileServices.getInstance(mockContext.Object);
        //Act
        service.UpdateProfile(profileToUpdate, updateProfile, user1);
        //Assert
        mockSet.Verify(p => p.Attach(profileToUpdate), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }

}