using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudyApp.Models
{
    public class EventSearcher
    {
      
        //Demo class for template search viewmodel
        public static List<Event> SearchEvents(string keyword){
            List<Event> l = new List<Event>();
            l.Add(new Event());
            l.Add(new Event());
            l.Add(new Event());
            l.Add(new Event());
            return l;
        }

    }
}