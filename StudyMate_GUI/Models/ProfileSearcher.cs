using System;
using System.Collections.Generic;

namespace StudyApp.Models
{
    public class ProfileSearcher
    {

        //Demo class for template search viewmodel
        public static List<Profile> SearchProfiles(string keyword){
            List<Profile> l = new List<Profile>();
            l.Add(new Profile(new User("a","a")));
            l.Add(new Profile(new User("b","b")));
            l.Add(new Profile(new User("c","c")));
            return l;
        }
    }
}