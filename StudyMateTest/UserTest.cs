// using Moq;
// using StudyMate;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// namespace StudyMateTest
// {
//     [TestClass]
//     public class UserTest
//     {
//         public static readonly string username = "lhqezio";
//         public static readonly string email = "123@abc.com";
//         public static readonly string password = "test123";
//         [TestMethod]
//         public void LoginTest()
//         {
//             //Arrange
//             var mockUser = new Mock<StudyMateDbContext>();
//             mockUser.Object.Register(username, email, password);
//             //Act
//             var result = mockUser.Object.Login(username, password);
//             User User = mockUser.Object.Users.FirstOrDefault(u => u.Username == username);
//             //Assert
//             Assert.AreEqual(result.Username, username);
//             Assert.AreEqual(User.Username, username);
//             Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{User.Salt}.{User.PasswordHash}"));
//         }
//         [TestMethod]
//         public void RegisterTest()
//         {
//             //Arrange
//             var mockUser = new Mock<StudyMateDbContext>();
//             //Act
//             mockUser.Object.Register(username, email, password);
//             User User = mockUser.Object.Users.FirstOrDefault(u => u.Username == username);
//             //Assert
//             Assert.AreEqual(User.Username, username);
//             Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{User.Salt}.{User.PasswordHash}"));
//         }
//         [TestMethod]
//         public void LoginFromSessionKeyTest()
//         {
//             //Arrange
//             var mockUser = new Mock<StudyMateDbContext>();
//             var result = mockUser.Object.Register(username, email, password);
//             //Act
//             var user = mockUser.Object.LoginFromSessionKey(result.__session_key);
//             User User = mockUser.Object.Users.FirstOrDefault(u => u.Username == username);
//             //Assert
//             Assert.AreEqual(user.Username, username);
//             Assert.AreEqual(User.Username, username);
//             Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{User.Salt}.{User.PasswordHash}"));
//         }
//         [TestMethod]
//         public void LogoutTest()
//         {
//             //Arrange
//             var mockUser = new Mock<StudyMateDbContext>();
//             var result = mockUser.Object.Register(username, email, password);
//             //Act
//             var user = mockUser.Object.LoginFromSessionKey(result.__session_key);
//             mockUser.Object.Logout(result.__session_key);
//             //Assert
//             Assert.IsNull(user);
//         }
//         [TestMethod]
//         public void ChangePasswordTest()
//         {
//             //Arrange
//             var mockUser = new Mock<StudyMateDbContext>();
//             var result = mockUser.Object.Register(username, email, password);
//             //Act
//             var user = mockUser.Object.LoginFromSessionKey(result.__session_key);
//             mockUser.Object.ChangePassword(result.__session_key, "test1234");
//             User User = mockUser.Object.Users.FirstOrDefault(u => u.Username == username);
//             //Assert
//             Assert.IsTrue(PasswordHasher.VerifyPassword("test1234", $"{User.Salt}.{User.PasswordHash}"));
//         }
//     }
// }


