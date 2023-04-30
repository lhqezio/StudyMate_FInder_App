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
        var listdata = new List<Profile>();
        var userData=new User("alain","PK1","1","password");
        var profileData = new Profile("3", userData, "Alain", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        listdata.Add(profileData);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var schoolService = new SchoolServices(mockContext.Object);
        
        //Act
        var user1=new User("amirreza","PK1","1","password");
        School sch = new School("1", "Dawson College");
        schoolService.AddSchool(sch);
        Profile profile1 = new Profile("1", user1, "Amir", "Male", sch, 20, "Computer Science");
        List<CourseNeedHelpWith> coursesNeedHelpWith1=new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(profile1,new Course("1","Math")),new CourseNeedHelpWith(profile1,new Course("2","Cinema"))};
        profile1.CourseNeedHelpWith=coursesNeedHelpWith1;
        service.AddProfile(profile1);

        //Assert
        mockSet.Verify(p => p.Add(It.IsAny<Profile>()), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }

    // [TestMethod]
    // public void DeleteProfileTest_DeletesAProfileFromDB_ReturnsVoid()
    // {
    //     // Arrange
    //     var listdata = new List<Profile>();
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profileToDelete = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     listdata.Add(profileToDelete);
    //     var data = listdata.AsQueryable();
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     // Act
    //     service.DeleteProfile(profileToDelete);
    //     // Assert
    //     mockSet.Verify(p => p.Remove(It.IsAny<Profile>()), Times.Once());
    //     mockContext.Verify(p => p.SaveChanges(), Times.Once());
    // }

    // [TestMethod]
    // public void UpdateProfileTest_UpdatesProfileInDB_ReturnsVoid(){
    //     // Arrange
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profile = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     //Act
    //     service.UpdateProfile(profile);
    //     //Assert
    //     mockSet.Verify(p => p.Update(It.IsAny<Profile>()), Times.Once());
    //     mockContext.Verify(p => p.SaveChanges(), Times.Once());
    // }

    // [TestMethod]
    // public void GetAllProfilesTest_QueriesAllProfiles_ReturnsInt(){
    //     // Arrange
    //     var listdata = new List<Profile>();
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profile1 = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     var user2 = new User("Leo", "PK2", "2","password");
    //     var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
    //     listdata.Add(profile1);
    //     listdata.Add(profile2);
    //     var data = listdata.AsQueryable();
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     //Act
    //     var profiles = service.GetAllProfiles();
    //     //Assert
    //     Assert.AreEqual(2,profiles.Count);
    // }

    // [TestMethod]
    // public void GetSpecificProfileByIdTest_RetrievesAnSpecificProfile_ReturnsProfile()
    // {
    //     // Arrange
    //     var listdata = new List<Profile>();
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profile1 = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     var user2 = new User("Leo", "PK2", "2","password");
    //     var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
    //     listdata.Add(profile1);
    //     listdata.Add(profile2);
    //     var data = listdata.AsQueryable();
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     // Act
    //     var retrievedProfile = service.GetSpecificProfileById(profile1.ProfileId);
    //     // Assert
    //     Assert.AreEqual(profile1, retrievedProfile);
    // }

    // [TestMethod]
    // public void GetSpecificProfileByIdTest_FailsToRetrieveAnSpecificProfile_ReturnsNull()
    // {
    //     // Arrange
    //     var listdata = new List<Profile>();
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profile1 = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     var user2 = new User("Leo", "PK2", "2","password");
    //     var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
    //     listdata.Add(profile1);
    //     listdata.Add(profile2);
    //     var data = listdata.AsQueryable();
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     // Act
    //     var retrievedProfile = service.GetSpecificProfileById("NullProfileId");
    //     // Assert
    //     Assert.IsNull(retrievedProfile);
    // }

    // [TestMethod]
    // public void GetSpecificProfileTest_RetrievesAnSpecificProfile_ReturnsProfile()
    // {
    //     // Arrange
    //     var listdata = new List<Profile>();
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profile = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     listdata.Add(profile);
    //     var data = listdata.AsQueryable();
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     // Act
    //     var retrievedProfile = service.GetSpecificProfile(profile);
    //     // Assert
    //     Assert.AreEqual(profile, retrievedProfile);
    // }

    // [TestMethod]
    // public void GetSpecificProfileTest_RetrievesAnSpecificProfile_ReturnsFalse()
    // {
    //     // Arrange
    //     var listdata = new List<Profile>();
    //     var user1=new User("amirreza","PK1","1","password");
    //     var profile = new Profile("Amir", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Male);
    //     var user2 = new User("Leo", "PK2", "2","password");
    //     var profile2 = new Profile("Leonard", 34, new School("MIT"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user2, Genders.Male);
    //     listdata.Add(profile);
    //     var data = listdata.AsQueryable();
    //     var mockSet = new Mock<DbSet<Profile>>();
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
    //     mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    //     var mockContext = new Mock<StudyMateDbContext>();
    //     mockContext.Setup(c => c.Profiles).Returns(mockSet.Object);
    //     var service = new ProfileServices(mockContext.Object);
    //     // Act
    //     var retrievedProfile = service.GetSpecificProfile(profile);
    //     // Assert
    //     Assert.AreNotEqual(profile2, retrievedProfile);
    // }
}
