using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace StudyMate
{
    public class EventCalendar
    {
        // Fields
        private string _title;
        private Profile _creator;
        private List<Profile> _participants;
        private DateTimeOffset _date;
        private string _description;


        // Properties - Validation done here since it will also work when edited 
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title can't be empty, null, or whitespace.");
                }
                _title = value;
            }
        }
        
        public Profile Creator
        {
            get { return _creator; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Creator can't be null.");
                }
                _creator = value;
            }
        }
        
        public List<Profile> Participants
        {
            get { return _participants; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("There should be at least one participant.");
                }
                _participants = value;
            }
        }
        
        public DateTimeOffset Date
        {
            get { return _date; }
            set
            {
                if (value < DateTimeOffset.Now)
                {
                    throw new ArgumentException("The event can't be in the past.");
                }
                _date = value;
            }
        }
        
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Your description can't be empty.");
                }
                _description = value; 
            }
        }
        
        [Key]
        public string EventId { get; } //Will be dealt with in dtb part
        
        public bool IsSent { get; set; }
        
        public List<Courses> CourseList { get; set; }
        
        public List<string> SubjectSchoolProjectList { get; set; }

        // Constructors
        public EventCalendar(string title, Profile creator, List<Profile> participants, DateTimeOffset date, string description, List<Courses> courses, List<string> subjectSchoolProjectList)
        {
            EventId = Guid.NewGuid().ToString();
            _title = title; //Make sure if it take _title or Title
            _creator = creator;
            _participants = participants; 
            _date = date;
            IsSent = false;
            _description = description;
            CourseList = courses;
            SubjectSchoolProjectList = subjectSchoolProjectList;
        }

        //Method to add Participants
        public void AddParticipant(Profile newParticipant){
            if(_participants.Contains(newParticipant)){
                throw new ArgumentException("This participant is already part of the event");
            }
            _participants.Add(newParticipant);
        }

        //Method to remove Participants
        public void RemoveParticipant(Profile participant){
            if(!_participants.Contains(participant)){
                throw new ArgumentException("This participant isn't part of the event in the first place");
            }
            _participants.Remove(participant);
        }

        //Method to Check if participant is attending the event
        public bool Attends(Profile user)
        {
            return _participants.Contains(user);
        }

        //Reminder => Send a reminder to the email of the participants
        public void RemindParticipants(){
            TimeSpan timeBeforeEvent = TimeSpan.FromDays(1); //Will remind 1 day before
            var gapNowEvent = _date - DateTimeOffset.Now; //Calculate time gap between now and event
            if(IsSent){ 
                Console.WriteLine("Participant already received a reminder");
                return;
            }
            if (gapNowEvent <= timeBeforeEvent && !IsSent){
                SmtpClient sC = new SmtpClient();
                sC.Credentials = new NetworkCredential("StudyMate1@hotmail.com", "dawson1234"); 
                sC.EnableSsl = true;

                foreach (var participant in _participants)
                {
                    MailMessage mail = new MailMessage(); //Using MailMessage obj to send email
                    mail.From = new MailAddress("StudyMate1@hotmail.com"); 
                    mail.Subject = "Reminder StudyMate Event: " + Title;
                    mail.Body = "Hello "+participant.Name+" \n Don't forget the event: "+ Title + " on " + Date.ToString("f");                           
                    mail.To.Add(FindParticipantMail(participant));
                    sC.Send(mail); //Send email 
                }
            }
            IsSent = true;
        }

        //Find participant mail
        public MailAddress FindParticipantMail(Profile participant){
            StudyMateDbContext db = new StudyMateDbContext();
            var user = db.Users //Add email in Users
                        .Where(u => u.__user_id.Contains(participant.UserId))
                        .ToList();
            MailAddress participantMail = new MailAddress(user[0].email); 
            return participantMail;
        }
    }
}
