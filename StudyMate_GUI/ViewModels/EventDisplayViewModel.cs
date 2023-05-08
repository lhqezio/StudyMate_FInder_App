using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudyMate.Models;

namespace Study.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {
        public EventDisplayViewModel(Event e)
        {
            Event = e;
        }

        public Event Event { get; }
    }
}