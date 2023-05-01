namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;

    [TestClass]
    public class SearchServicesTest
    {

        [TestMethod]
        public void Test_SearchServices_GetAllProfileEvent(){
            //Need to be able to add event
        }

        [TestMethod]
        public void Test_SearchServices_GetEventById(){
            //Need to be able to add event
        }

        [TestMethod]
        public void Test_SearchServices_GetProfileByName(){
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
            var searchService = new SearchServices(mockContext.Object);

            // Act
            var retrievedProfiles = searchService.GetProfileByName("Amir"); //Profile1 name
            
            // Assert
            CollectionAssert.Contains(retrievedProfiles, profile1);   
        }

        [TestMethod]
        public void Test_SearchServices_SearchEventsCourseSchool(){
            //Need to be able to add event
        }

        [TestMethod]
        public void Test_SearchServices_SearchEventsCreator(){
            //Need to be able to add event
        }

        [TestMethod]
        public void Test_SearchServices_SearchEventTitleDescription(){
            //Need to be able to add event
        }

        [TestMethod]
        public void Test_SearchServices_SearchProfileCourseSchool(){
            // Arrange
                //Profile
            var listdata = new List<Profile>();
            var user1 = new User("amirreza","PK1","1","password");
            var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
            profile1.CourseTaken = new List<CourseTaken>(){new CourseTaken(profile1, new Course("3", "Algebra"))};
            profile1.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(profile1, new Course("1", "History"))};
            profile1.CourseCanHelpWith = new List<CourseCanHelpWith>(){new CourseCanHelpWith(profile1, new Course("2","Calculus")),};
            
            var user2 = new User("Leo", "PK2", "2","password");
            var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science");
            profile2.CourseTaken = new List<CourseTaken>(){new CourseTaken(profile2, new Course("4", "French"))};
            profile2.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(profile2, new Course("5", "Communication"))};
            profile2.CourseCanHelpWith = new List<CourseCanHelpWith>(){new CourseCanHelpWith(profile2, new Course("6","Calculus")),};

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
            var searchService = new SearchServices(mockContext.Object);

            // Act
            var retrievedProfilesSchool = searchService.SearchProfileCourseSchool("MIT"); //Profile2 School
            var retrievedProfileCourse1 = searchService.SearchProfileCourseSchool("History"); //Profile1 Course
            var retrievedProfileCourse2 = searchService.SearchProfileCourseSchool("Calculus"); //Profile1 Profile 2 Course

            // Assert 
            CollectionAssert.Contains(retrievedProfilesSchool, profile2); 
            CollectionAssert.Contains(retrievedProfileCourse1, profile1);
            CollectionAssert.AreEquivalent(retrievedProfileCourse2, listdata);
        }


        [TestMethod]
        public void Test_SearchServices_SearchProfileBlurbInterest(){
            // Arrange
                //Profile
            var listdata = new List<Profile>();
            var user1 = new User("amirreza","PK1","1","password");
            var profile1 = new Profile("1", user1, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science", "Amir Description");
            profile1.Hobbies = new List<Hobby>(){ new Hobby("1", "Anime")};
            
            var user2 = new User("Leo", "PK2", "2","password");
            var profile2 = new Profile("2", user1, "Leo", "Male", new School("2", "MIT"), 20, "Political Science", "Leo Description");
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
            var searchService = new SearchServices(mockContext.Object);

            // Act
            var retrievedProfilesDescriptionBoth = searchService.SearchProfileBlurbInterest("Description"); //Profile1 name
            var retrievedProfilesDescription1 = searchService.SearchProfileBlurbInterest("Leo"); //Profile1 name
            var retrievedProfilesHobby = searchService.SearchProfileBlurbInterest("Anime"); //Profile1 name

            // Assert
            CollectionAssert.AreEquivalent(retrievedProfilesDescriptionBoth, listdata); //Based on description
            CollectionAssert.Contains(retrievedProfilesDescription1, profile2);
            CollectionAssert.Contains(retrievedProfilesHobby, profile1);
        }

        [TestMethod]
        public void Test_SearchServices_SearchAllProfile(){
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
            var searchService = new SearchServices(mockContext.Object);

            // Act
            var retrievedProfiles = searchService.SearchAllProfile();
            
            // Assert
            CollectionAssert.AreEquivalent(listdata, retrievedProfiles);
        }

        [TestMethod]
        public void Test_SearchServices_SearchProfileByUser(){
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
            var searchService = new SearchServices(mockContext.Object);

            // Act
            var retrievedProfile = searchService.SearchProfileByUser(profile1.UserId);
            
            // Assert
            Assert.AreEqual(retrievedProfile, profile1);
            Assert.AreNotEqual(retrievedProfile, profile2);
        }
}
