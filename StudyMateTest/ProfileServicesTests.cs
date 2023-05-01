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
            //Profile
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
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        
        
        //Act
        var user1=new User("amirreza","PK1","1","password");
        School sch = new School("1", "Dawson College");
        Profile profile1 = new Profile("1", user1, "Amir", "Male", sch, 20, "Computer Science");
        List<CourseNeedHelpWith> coursesNeedHelpWith1=new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(profile1,new Course("1","Math")),new CourseNeedHelpWith(profile1,new Course("2","Cinema"))};
        profile1.CourseNeedHelpWith=coursesNeedHelpWith1;
        service.AddProfile(profile1);

        //Assert
        mockSet.Verify(p => p.Add(It.IsAny<Profile>()), Times.AtLeastOnce());
        mockContext.Verify(p => p.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    public void DeleteProfileTest_DeletesAProfileFromDB_ReturnsVoid()
    {
        //Arrange
            //Profile
        var listdata = new List<Profile>();
        var userData=new User("amirreza","PK1","1","password");
        var profileData = new Profile("3", userData, "Alain", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        listdata.Add(profileData);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        
        // Act
        service.DeleteProfile(userData);

        // Assert
        mockSet.Verify(p => p.Remove(It.IsAny<Profile>()), Times.Once());
        mockContext.Verify(p => p.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void UpdateProfileTest_UpdatesProfileInDB_ReturnsVoid(){
        //Arrange
            //Profile
        var listdata = new List<Profile>();
        var userData=new User("amirreza","PK1","1","password");
        var profile = new Profile("3", userData, "Alain", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        listdata.Add(profile);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        
        //Act
        service.UpdateProfile(profile);
        //Assert
        mockSet.Verify(p => p.Update(It.IsAny<Profile>()), Times.AtLeastOnce());
        mockContext.Verify(p => p.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    public void GetAllProfilesTest_QueriesAllProfiles_ReturnsInt(){
        // Arrange
            //Profile
        var listdata = new List<Profile>();
        var user1 = new User("amirreza","PK1","1","password");
        var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        var user2 = new User("Leo", "PK2", "2","password");
        var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science");
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var searchService = new SearchServices(mockContext.Object); 
        
        //Act
        var profiles = searchService.SearchAllProfile();
        //Assert
        Assert.AreEqual(2,profiles.Count);
    }

    [TestMethod]
    public void GetSpecificProfileByIdTest_RetrievesAnSpecificProfile_ReturnsProfile()
    {
        // Arrange
            //Profile
        var listdata = new List<Profile>();
        var user1 = new User("amirreza","PK1","1","password");
        var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        var user2 = new User("Leo", "PK2", "2","password");
        var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science");
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var searchService = new SearchServices(mockContext.Object);

        // Act
        var retrievedProfile = searchService.SearchProfileByProfileId(profile1.ProfileId);
        
        // Assert
        Assert.AreEqual(profile1, retrievedProfile);
    }

    [TestMethod]
    public void GetSpecificProfileByIdTest_FailsToRetrieveAnSpecificProfile_ReturnsNull()
    {
        // Arrange
            //Profile
        var listdata = new List<Profile>();
        var user1 = new User("amirreza","PK1","1","password");
        var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        var user2 = new User("Leo", "PK2", "2","password");
        var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science");
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var searchService = new SearchServices(mockContext.Object);

        
        // Act
        var retrievedProfile = searchService.SearchProfileByProfileId("NullProfileId");
        // Assert
        Assert.IsNull(retrievedProfile);
    }

    [TestMethod]
    public void GetSpecificProfileTest_RetrievesAnSpecificProfile_ReturnsProfile()
    {
        // Arrange
            //Profile
        var listdata = new List<Profile>();
        var user1 = new User("amirreza","PK1","1","password");
        var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        var user2 = new User("Leo", "PK2", "2","password");
        var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science");
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var searchService = new SearchServices(mockContext.Object);

        // Act
        var retrievedProfile = searchService.SearchProfileByProfileId(profile2.ProfileId);
        // Assert
        Assert.AreEqual(profile2, retrievedProfile);
    }

    [TestMethod]
    public void GetSpecificProfileTest_RetrievesAnSpecificProfile_ReturnsFalse()
    {
        // Arrange
            //Profile
        var listdata = new List<Profile>();
        var user1 = new User("amirreza","PK1","1","password");
        var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        var user2 = new User("Leo", "PK2", "2","password");
        var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science");
        listdata.Add(profile1);
        listdata.Add(profile2);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            //School
        var listdataSchool = new List<School>();
        var schoolData = new School("56", "Henri-Bourrassa");
        listdataSchool.Add(schoolData);
        var sData = listdataSchool.AsQueryable();
        var sMockSet = new Mock<DbSet<School>>();
        sMockSet.As<IQueryable<School>>().Setup(m => m.Provider).Returns(sData.Provider);
        sMockSet.As<IQueryable<School>>().Setup(m => m.Expression).Returns(sData.Expression);
        sMockSet.As<IQueryable<School>>().Setup(m => m.ElementType).Returns(sData.ElementType);
        sMockSet.As<IQueryable<School>>().Setup(m => m.GetEnumerator()).Returns(sData.GetEnumerator());
            //Course
        var listdataCourse = new List<Course>();
        var courseData = new Course("45", "Calculus");
        listdataCourse.Add(courseData);
        var cData = listdataCourse.AsQueryable();
        var cMockSet = new Mock<DbSet<Course>>();
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(cData.Provider);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(cData.Expression);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(cData.ElementType);
        cMockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(cData.GetEnumerator());


        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        mockContext.Setup(s => s.Schools).Returns(sMockSet.Object);
        mockContext.Setup(c => c.StudyCourses).Returns(cMockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var searchService = new SearchServices(mockContext.Object);

        // Act
        var retrievedProfile = searchService.SearchProfileByProfileId(profile2.ProfileId);
        // Assert
        Assert.AreNotEqual(profile1, retrievedProfile);
    }
}
