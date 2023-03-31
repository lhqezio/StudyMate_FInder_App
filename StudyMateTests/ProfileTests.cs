namespace StudyMateTest;
using StudyMate;
[TestClass]
public class ProfileTests
{
    [TestMethod]
    public void ClearProfileTest_MakesAllPropertiesNull_ReturnsVoid()
    {
        //Arrange
        Profile profile = new Profile("Amir",20,"Dawson",Courses.Calculus);
        //Act
        profile.ClearProfile();
        //Assert
//        Assert
    }
}