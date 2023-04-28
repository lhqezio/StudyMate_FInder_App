using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
public class User {
        public string __session_key{get;set;}
        public string __user_id{get;set;}
        public UserDB userDB{get;set;}
        public User(UserDB user, string session_key){
            __session_key = session_key;
            __user_id=user.UserId;
            userDB=user;
        }
    }
}
