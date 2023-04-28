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
        var service = new ProfileServices(mockContext.Object);
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
        var service = new ProfileServices(mockContext.Object);
        // Act
        service.DeleteProfile(profileToDelete, user1);
        // Assert
        mockSet.Verify(p => p.Remove(It.IsAny<Profile>()), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void UpdateProfileTest_UpdatesProfileInDB_ReturnsVoid(){
        // Arrange
        User user1 = new User("amirreza", "PK1", "1");
        var profile = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        //Act
        service.UpdateProfile(profile, user1);
        //Assert
        mockSet.Verify(p => p.Update(It.IsAny<Profile>()), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void GetAllProfilesTest_QueriesAllProfiles_ReturnsInt(){
        // Arrange
        var listdata = new List<Profile>();
        User user1 = new User("amirreza", "PK1", "1");
        var profile1 = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
        User user2 = new User("Leo", "PK2", "2");
        var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        //Act
        var profiles = service.GetAllProfiles();
        //Assert
        Assert.AreEqual(2,profiles.Count);
    }

    [TestMethod]
    public void GetSpecificProfileByIdTest_RetrievesAnSpecificProfile_ReturnsProfile()
    {
        // Arrange
        var listdata = new List<Profile>();
        User user1 = new User("amirreza", "PK1", "1");
        var profile1 = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
        User user2 = new User("Leo", "PK2", "2");
        var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        // Act
        var retrievedProfile = service.GetSpecificProfileById(profile1.ProfileId);
        // Assert
        Assert.AreEqual(profile1, retrievedProfile);
    }

    [TestMethod]
    public void GetSpecificProfileByIdTest_FailsToRetrieveAnSpecificProfile_ReturnsNull()
    {
        // Arrange
        var listdata = new List<Profile>();
        User user1 = new User("amirreza", "PK1", "1");
        var profile1 = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
        User user2 = new User("Leo", "PK2", "2");
        var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        // Act
        var retrievedProfile = service.GetSpecificProfileById("NullProfileId");
        // Assert
        Assert.IsNull(retrievedProfile);
    }

    [TestMethod]
    public void GetSpecificProfileTest_RetrievesAnSpecificProfile_ReturnsProfile()
    {
        // Arrange
        var listdata = new List<Profile>();
        User user = new User("amirreza", "PK1", "1");
        var profile = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user, Genders.Male);
        listdata.Add(profile);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        // Act
        var retrievedProfile = service.GetSpecificProfile(profile);
        // Assert
        Assert.AreEqual(profile, retrievedProfile);
    }

    [TestMethod]
    public void GetSpecificProfileTest_RetrievesAnSpecificProfile_ReturnsFalse()
    {
        // Arrange
        var listdata = new List<Profile>();
        User user = new User("amirreza", "PK1", "1");
        var profile = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user, Genders.Male);
        User user2 = new User("Leo", "PK2", "2");
        var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
        listdata.Add(profile);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        // Act
        var retrievedProfile = service.GetSpecificProfile(profile);
        // Assert
        Assert.AreNotEqual(profile2, retrievedProfile);
    }
}
