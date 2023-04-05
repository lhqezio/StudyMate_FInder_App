using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;

namespace StudyMate.Test
{
    [TestClass]
    public class UserTest
    {
        private static DbContextOptions<UserDbContext> _options;
        private static UserDbContext _dbContext;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Initialize database context and options
            _options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new UserDbContext(_options);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Cleanup database context and options
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [TestMethod]
        public void TestRegister()
        {
            // Arrange
            var username = "testuser";
            var password = "testpassword";

            // Act
            User.register(username, password, _dbContext);

            // Assert
            var userFromDb = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            Assert.IsNotNull(userFromDb);
            Assert.AreEqual(username, userFromDb.Username);
            Assert.IsTrue(PasswordHasher.VerifyPassword(password, $"{userFromDb.Salt}.{userFromDb.PasswordHash}"));
        }

        [TestMethod]
        public void TestLogin()
        {
            // Arrange
            var username = "testuser";
            var password = "testpassword";
            User.register(username, password, _dbContext);

            // Act
            var user = User.login(username, password, _dbContext);

            // Assert
            Assert.AreEqual(username, user.Username);
            Assert.IsFalse(string.IsNullOrEmpty(user.__session_key));
            Assert.IsFalse(string.IsNullOrEmpty(user.__user_id));
        }

        [TestMethod]
        public void TestChangePassword()
        {
            // Arrange
            var username = "testuser";
            var oldPassword = "testpassword";
            var newPassword = "newpassword";
            User.register(username, oldPassword, _dbContext);
            var user = User.login(username, oldPassword, _dbContext);

            // Act
            user.changePassword(newPassword, _dbContext);

            // Assert
            var userFromDb = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            Assert.IsNotNull(userFromDb);
            Assert.IsTrue(PasswordHasher.VerifyPassword(newPassword, $"{userFromDb.Salt}.{userFromDb.PasswordHash}"));
        }
    }

    [TestClass]
    public class UserDbContextTests
    {
        private DbContextOptions<UserDbContext> _options;
        private UserDbContext _context;

        [TestInitialize]
        public void Initialize()
        {
            _options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;

            _context = new UserDbContext(_options);
        }

        [TestMethod]
        public void TestAddUser()
        {
            // Arrange
            var user = new UserDB("testuser", "testuser@example.com", "salt", "password");

            // Act
            _context.Users.Add(user);
            _context.SaveChanges();

            // Assert
            Assert.AreEqual(1, _context.Users.Count());
            Assert.AreEqual(user.Id, _context.Users.Find(user.Id).Id);
        }

        [TestMethod]
    public void TestSavePasswordHash()
    {
        // Arrange
        UserDB user = new UserDB("testuser", "testuser@example.com", "salt", "password");
        _context.Users.Add(user);
        _context.SaveChanges();

        // Act
        user.Password = "newpassword";
        _context.SaveChanges();

        // Assert
        Assert.IsNull(user.Password);
        Assert.IsNotNull(user.PasswordHash);
        Assert.IsNotNull(user.Salt);
        Assert.AreNotEqual("newpassword", user.PasswordHash);
    }
}
}
