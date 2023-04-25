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
        public UserServices Db{get;set;}
        public static User Register(string username,string email, string password, UserServices dbContext){
            // Register user
            return dbContext.Register(username,email, password);
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
