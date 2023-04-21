using Moq;
using StudyMate;
namespace StudyMateTest
{
    [TestClass]
    public class UserTest
    {
        public static readonly string username = "lhqezio";
        public static readonly string email = "123@abc.com";
        public static readonly string password = "test123";
        [TestMethod]
        public void LoginTest()
        {
            //Arrange
            var mockUserDB = new Mock<StudyMateDbContext>();
            mockUserDB.Object.register(username, email, password);
            //Act
            var result = mockUserDB.Object.login(username, password);
            UserDB userDB = mockUserDB.Object.Users.FirstOrDefault(u => u.Username == username);
            //Assert
            Assert.AreEqual(result.Username, username);
            Assert.AreEqual(userDB.Username, username);
            Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{userDB.Salt}.{userDB.PasswordHash}"));
        }
        [TestMethod]
        public void RegisterTest()
        {
            //Arrange
            var mockUserDB = new Mock<StudyMateDbContext>();
            //Act
            mockUserDB.Object.register(username, email, password);
            UserDB userDB = mockUserDB.Object.Users.FirstOrDefault(u => u.Username == username);
            //Assert
            Assert.AreEqual(userDB.Username, username);
            Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{userDB.Salt}.{userDB.PasswordHash}"));
        }
        [TestMethod]
        public void GetUserFromSessionKeyTest()
        {
            //Arrange
            var mockUserDB = new Mock<StudyMateDbContext>();
            var result = mockUserDB.Object.register(username, email, password);
            //Act
            var user = mockUserDB.Object.getUserFromSessionKey(result.__session_key);
            UserDB userDB = mockUserDB.Object.Users.FirstOrDefault(u => u.Username == username);
            //Assert
            Assert.AreEqual(user.Username, username);
            Assert.AreEqual(userDB.Username, username);
            Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{userDB.Salt}.{userDB.PasswordHash}"));
        }
        [TestMethod]
        public void LogoutTest()
        {
            //Arrange
            var mockUserDB = new Mock<StudyMateDbContext>();
            var result = mockUserDB.Object.register(username, email, password);
            //Act
            var user = mockUserDB.Object.getUserFromSessionKey(result.__session_key);
            mockUserDB.Object.logout(result.__session_key);
            //Assert
            Assert.IsNull(user);
        }
        [TestMethod]
        public void ChangePasswordTest()
        {
            //Arrange
            var mockUserDB = new Mock<StudyMateDbContext>();
            var result = mockUserDB.Object.register(username, email, password);
            //Act
            var user = mockUserDB.Object.getUserFromSessionKey(result.__session_key);
            mockUserDB.Object.changePassword(result.__session_key, "test1234");
            UserDB userDB = mockUserDB.Object.Users.FirstOrDefault(u => u.Username == username);
            //Assert
            Assert.IsTrue(PasswordHasher.VerifyPassword("test1234", $"{userDB.Salt}.{userDB.PasswordHash}"));
        }
    }
}


