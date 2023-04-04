namespace StudyMateTest;
using StudyMate;
[TestClass]
public class ProfileTests
{
    [TestMethod]
    public void ClearProfileTest_MakesAllPropertiesNull_ReturnsVoid()
    {
        //Arrange
        Profile profile1=new Profile("Amir",Genders.Male,20,"Dawson College",new List<Courses>(){Courses.History});
        Profile profile2=new Profile("Samanta",Genders.Female,18,"Vanier",new List<Courses>(){Courses.Computer_Science});
        // //Act
        profile1.ClearProfile();
        profile2.ClearProfile();
        // Assert
        Assert.AreEqual(profile1,profile2);
    }
}