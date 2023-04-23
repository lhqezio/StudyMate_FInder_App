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
        public StudyMateDbContext Db{get;set;}
        public static User Register(string username,string email, string password, StudyMateDbContext dbContext){
            // Register user
            return dbContext.register(username,email, password);
        }

        public User Login(string username, string password, bool rememberMe = false){
           User user = Db.login(username, password);
              if(user != null){
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
              }
              else {
                user = EMPTY_USER;
              }
              return user;
        }

        public User AutoLogin(){
            if(UserConfig.Read("encryptedSessionKey") != null){
                string encryptedSessionKey = UserConfig.Read("encryptedSessionKey");
                byte[] encryptedSessionKeyBytes = Convert.FromBase64String(encryptedSessionKey);
                byte[] sessionKeyBytes = ProtectedData.Unprotect(encryptedSessionKeyBytes, null, DataProtectionScope.CurrentUser);
                string sessionKey = Encoding.UTF8.GetString(sessionKeyBytes);
                User user = Db.getUserFromSessionKey(sessionKey);
                if(user != null){
                    return user;
                }
            }
            else if(UserConfig.Read("encryptedUsername") != null && UserConfig.Read("encryptedPassword") != null){
                string encryptedUsername = UserConfig.Read("encryptedUsername");
                string encryptedPassword = UserConfig.Read("encryptedPassword");
                byte[] encryptedUsernameBytes = Convert.FromBase64String(encryptedUsername);
                byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                byte[] usernameBytes = ProtectedData.Unprotect(encryptedUsernameBytes, null, DataProtectionScope.CurrentUser);
                byte[] passwordBytes = ProtectedData.Unprotect(encryptedPasswordBytes, null, DataProtectionScope.CurrentUser);
                string username = Encoding.UTF8.GetString(usernameBytes);
                string password = Encoding.UTF8.GetString(passwordBytes);
                User user = Login(username, password);
                if(user != null){
                    return user;
                }
            }
            return EMPTY_USER;
        }
        public void Logout(StudyMateDbContext dbContext){
            dbContext.logout(__session_key);
            UserConfig.Write("encryptedSessionKey", null);
            UserConfig.Write("encryptedUsername", null);
            UserConfig.Write("encryptedPassword", null);
        }

        public void changePassword(String newPassword){
            Db.changePassword(__session_key, newPassword);
            Logout(Db);
        }
    }
}
