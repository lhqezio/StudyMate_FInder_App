// namespace StudyMateTest;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using StudyMate;
// using Moq;
// using Microsoft.EntityFrameworkCore;
// [TestClass]
// public class MatchingTests
// {
//     [TestMethod]
//     public void BestMatchesTest_ShowsTheBestMatchesToTheUser_ReturnsListProfile()
//     {
//         //Arrange
//         var look_for_match_profile = new Profile("Amir",20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History),new NeedHelpCourses(Courses.Calculus),new NeedHelpCourses(Courses.Chemistry)},new User("amirreza","PK1","1","password"),Genders.Male);

//         var listdata = new List<Profile>();

//         var user1 = new User("Leila", "PK1", "1","password");
//         var bestProfile1 = new Profile("Leila", 20, new School("Dawson College"), "Computer Science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.History) }, user1, Genders.Female);
//         bestProfile1.CanHelpCourses=new List<CanHelpCourses>(){new CanHelpCourses(Courses.Calculus),new CanHelpCourses(Courses.Chemistry),new CanHelpCourses(Courses.History)};
        
//         var user2 = new User("Francine", "PK2", "2","password");
//         var bestProfile2 = new Profile("Francine", 18, new School("MIT"), "Enriched math", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Communication) }, user2, Genders.Female);
//         bestProfile2.CanHelpCourses=new List<CanHelpCourses>(){new CanHelpCourses(Courses.Calculus),new CanHelpCourses(Courses.Chemistry)};
        
//         var user3 = new User("Mia", "PK3", "3","password");
//         var bestProfile3 = new Profile("Mia", 19, new School("UBC"), "Political science", new List<NeedHelpCourses>() { new NeedHelpCourses(Courses.Political_Science) }, user3, Genders.Female);
//         bestProfile3.CanHelpCourses=new List<CanHelpCourses>(){new CanHelpCourses(Courses.Calculus)};

//         List<Profile> bestProfiles= new List<Profile>() {bestProfile1,bestProfile2,bestProfile3};

//         listdata.Add(bestProfile1);
//         listdata.Add(bestProfile2);
//         listdata.Add(bestProfile3);
//         var data = listdata.AsQueryable();
//         var mockSet = new Mock<DbSet<Profile>>();
//         mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
//         mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
//         mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
//         mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
//         var mockContext = new Mock<StudyMateDbContext>();
//         mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
//         var service = new ProfileServices(mockContext.Object);
//         var match = new Matching(look_for_match_profile,service);
//         //Act
//         List<Profile> bestMatches = match.BestMatches();
//         //Assert
//         Assert.IsTrue(bestMatches.SequenceEqual(bestProfiles));
//     }
// }