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

    }
}
