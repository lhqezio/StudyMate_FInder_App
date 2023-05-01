namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;
[TestClass]
public class MatchingTests
{
    [TestMethod]
    public void BestMatchesTest_ShowsTheBestMatchesToTheUser_ReturnsListProfile()
    {
        //Arrange
        var look_for_match_user = new User("amirreza","PK1","1","password");
        var look_for_match_profile = new Profile("1", look_for_match_user, "Amir", "Male", new School("1", "Dawson College"), 20, "Computer Science");
        look_for_match_profile.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(look_for_match_profile, new Course("1", "History")), new CourseNeedHelpWith(look_for_match_profile, new Course("2", "Calculus")),new CourseNeedHelpWith(look_for_match_profile, new Course("3", "Chemistry"))};

        var listdata = new List<Profile>();

        var user1 = new User("Leila", "PK1", "1","password");
        var bestProfile1 = new Profile("2", user1, "Leila", "Female", new School("1", "Dawson College"), 21, "Computer Science");
        bestProfile1.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(bestProfile1, new Course("1", "History"))};
        bestProfile1.CourseCanHelpWith = new List<CourseCanHelpWith>(){new CourseCanHelpWith(bestProfile1, new Course("2","Calculus")),new CourseCanHelpWith(bestProfile1, new Course("3","Chemistry")),new CourseCanHelpWith(bestProfile1, new Course("1","History"))};
        
        var user2 = new User("Francine", "PK2", "2","password");
        var bestProfile2 = new Profile("3", user2, "Francine", "Female", new School("2", "MIT"), 19, "Enriched math");
        bestProfile2.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(bestProfile2, new Course("4", "Communication"))};
        bestProfile2.CourseCanHelpWith = new List<CourseCanHelpWith>(){new CourseCanHelpWith(bestProfile2, new Course("2", "Calculus")), new CourseCanHelpWith(bestProfile2, new Course("3", "Chemistry"))};
        
        var user3 = new User("Mia", "PK3", "3","password");
        var bestProfile3 = new Profile("4", user3, "Mia", "Female", new School("3", "UBC"),  19, "Political science");
        bestProfile3.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){ new CourseNeedHelpWith(bestProfile3, new Course("5", "Political Science"))};
        bestProfile3.CourseNeedHelpWith = new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(bestProfile3, new Course("2", "Calculus"))};

        List<Profile> bestProfiles= new List<Profile>() {bestProfile1,bestProfile2,bestProfile3};

        listdata.Add(bestProfile1);
        listdata.Add(bestProfile2);
        listdata.Add(bestProfile3);
        var data = listdata.AsQueryable();
        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockContext = new Mock<StudyMateDbContext>();
        mockContext.Setup(p => p.Profiles).Returns(mockSet.Object);
        var service = new ProfileServices(mockContext.Object);
        var searchService = new SearchServices(mockContext.Object);

        var match = new Matching(look_for_match_profile,service, searchService);
        //Act
        List<Profile> bestMatches = match.BestMatches();
        //Assert
        Assert.IsTrue(bestMatches.SequenceEqual(bestProfiles));
    }
}