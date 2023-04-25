using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string __session_key{get;set;}
        [Key]
        public string __user_id{get;set;}
        public Profile? Profile{get;set;}

        public User(){}

        public User(string username,string session_key,string user_id){
            __username = username;
            __session_key = session_key;
            __user_id = user_id;
        }
        public StudyMateService Db{get;set;}
        public static User Register(string username,string email, string password, StudyMateService dbContext){
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
        public void Logout(StudyMateService dbContext){
            dbContext.logout(__session_key);
            UserConfig.Write("encryptedSessionKey", null);
            UserConfig.Write("encryptedUsername", null);
            UserConfig.Write("encryptedPassword", null);
        }

        public void changePassword(String newPassword){
            Db.changePassword(__session_key, newPassword);
            Logout(Db);
        }

        //Override of Equals method. This is used to compare two course objects.
        public override bool Equals(object? obj)
        {
            if (obj is not User other){
                return false;
            }   
            return __username == other.__username
            && __session_key == other.__session_key
            && __user_id == other.__user_id;
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return __username.GetHashCode() ^ 
            __session_key.GetHashCode() ^
            __user_id.GetHashCode();
        }
    }
}
