// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.ComponentModel.DataAnnotations;

// namespace StudyMate;

// public class EventCalendar
// {
//     // Generates a random primary key for the EventCalendar class 
//     [Key]
//     public string EventId { get; set; }
//     [ForeignKey("Users")]
//     public string CreatorId { get; set; }
//     public List<Profile> Participant { get; set; } = new();
//     public string Title { get; set; }
//     public string Description { get; set; }
//     public DateTime Date { get; set; }
//     public string Location { get; set; }
//     public string Courses {get;set;}

//     public EventCalendar(string eventId, string creatorId, string title, string description, DateTime date, string location,string courses)
//     {
//         EventId = eventId;
//         CreatorId = creatorId;
//         Title = title;
//         Description = description;
//         Date = date;
//         Location = location;
//         Courses = courses;
//     }
// }