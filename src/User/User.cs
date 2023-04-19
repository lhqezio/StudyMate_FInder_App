namespace StudyMate
{
    public class User {
        public static readonly User EMPTY_USER = new User("",Guid.Empty.ToString(),Guid.Empty.ToString());
        private string __username;
        public string Username {
            get{
                return __username;
            }
        }
        public string __session_key;
        public string __user_id;

        public User(string username,string session_key,string user_id){
            __username = username;
            __session_key = session_key;
            __user_id = user_id;
        }

        public void changePassword(string newPassword, StudyMateDbContext dbContext){
            // Take and verify session key then change password
            var userToUpdate = dbContext.Users.FirstOrDefault(u => u.UserId == __user_id);
            if (userToUpdate != null)
            {
                userToUpdate.Password = newPassword;
                dbContext.SaveChanges();
            }
        }

        public static void register(string username, string password, StudyMateDbContext dbContext){
            // Register user
            var newUser = new UserDB(username, "", "", password);
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
        }

        public static User login(string username, string password, StudyMateDbContext dbContext){
            // Check if user exists and password is correct
            var userFromDb = dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (userFromDb != null && PasswordHasher.VerifyPassword(password, $"{userFromDb.Salt}.{userFromDb.PasswordHash}"))
            {
                //Session Key implementation to be done later
                return new User(userFromDb.Username, Guid.NewGuid().ToString(), userFromDb.UserId);
            }
            else
            {
                return EMPTY_USER;
            }
        }
    }
}
