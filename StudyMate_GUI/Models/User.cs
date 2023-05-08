using System;
using System.Collections.Generic;

namespace StudyApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string u, string p){
            Username = u;
            Password = p;
        }

    }
}