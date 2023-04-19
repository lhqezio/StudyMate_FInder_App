using System.Security.Cryptography;
using System.Text;

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
            var userToUpdate = dbContext.Users.FirstOrDefault(u => u.Id == __user_id);
            if (userToUpdate != null)
            {
                userToUpdate.Password = newPassword;
                dbContext.SaveChanges();
            }
        }

        public static void Register(string username, string password, StudyMateDbContext dbContext){
            // Register user
            var newUser = new UserDB(username, "", "", password);
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
        }

        public static User Login(string username, string password, StudyMateDbContext dbContext, bool rememberMe = false){
            // Check if user exists and password is correct
            var userFromDb = dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (userFromDb != null && PasswordHasher.VerifyPassword(password, $"{userFromDb.Salt}.{userFromDb.PasswordHash}"))
            {
                if(rememberMe){
                    byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] encryptedUsernameBytes = ProtectedData.Protect(usernameBytes, null, DataProtectionScope.CurrentUser);
                    byte[] encryptedPasswordBytes = ProtectedData.Protect(passwordBytes, null, DataProtectionScope.CurrentUser);
                    string encryptedUsername = Convert.ToBase64String(encryptedUsernameBytes);
                    string encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
                    UserConfig.Write("encryptedUsername", encryptedUsername);
                    UserConfig.Write("encryptedPassword", encryptedPassword);
                }
                //Session Key implementation to be done later
                return new User(userFromDb.Username, Guid.NewGuid().ToString(), userFromDb.Id);
            }
            else
            {
                return EMPTY_USER;
            }
        }

        public static User AutoLogin(StudyMateDbContext dbContext){
            // Check if user exists and password is correct
            string encryptedUsername = UserConfig.Read("encryptedUsername");
            string encryptedPassword = UserConfig.Read("encryptedPassword");
            if(encryptedUsername != null && encryptedPassword != null){
                byte[] encryptedUsernameBytes = Convert.FromBase64String(encryptedUsername);
                byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                byte[] usernameBytes = ProtectedData.Unprotect(encryptedUsernameBytes, null, DataProtectionScope.CurrentUser);
                byte[] passwordBytes = ProtectedData.Unprotect(encryptedPasswordBytes, null, DataProtectionScope.CurrentUser);
                string username = Encoding.UTF8.GetString(usernameBytes);
                string password = Encoding.UTF8.GetString(passwordBytes);
                return Login(username, password, dbContext);
            }
            else{
                return EMPTY_USER;
            }
        }
    }
}
