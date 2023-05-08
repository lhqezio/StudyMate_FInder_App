using Microsoft.EntityFrameworkCore;

namespace StudyMate
{
     public class Application
     {
        public static User? currentUser;
        public static StudyMateDbContext? db;
        public static readonly string DemoCourses = "Math 101,Phys 202,Art 303";
        public static void Main(string[] args)
        {
    
            using (db = new StudyMateDbContext())
            {
            
           
            //Set-up
                System.Console.WriteLine("What's up Andrew?");
                System.Console.WriteLine("Here is our PROOF");
                var userService = new UserServices(db);
                var profileService = new ProfileServices(db);
                // var schoolService = new SchoolServices(db);
                // var courseService = new CourseServices(db);
                var conversationService = new ChatServices(db);
                var eventService = new EventServices(db);
                var searchService = new SearchServices(db);
                
                // 1.	Create a new user account (user1)
                System.Console.WriteLine("Attempt to create user1");
                currentUser = userService.Register("alain", "alain@heaumo.co", "100");
                if (currentUser != null)
                {
                    Console.WriteLine("User created successfully");
                }
                else
                {
                    Console.WriteLine("User creation failed try logging in");
                    currentUser = userService.Login("alain", "100");
                    if (currentUser != null)
                    {
                        Console.WriteLine("User logged in successfully");
                    }
                    else
                    {
                        Console.WriteLine("User login failed quit");
                        return;
                    }
                }
                User user1 = currentUser;

                // 2.	Create a profile for user1 (You don’t need to fill in all details)
                System.Console.WriteLine("Attempt to set up Profile for user1");
                List<Course> TakenCourse = new List<Course>(){new Course("Algebra")};
                List<Course> NeedHelpCourse = new List<Course>(){new Course("Humanities")};
                List<Course> CanHelpCourse = new List<Course>(){new Course("Communication")};
                List<Hobby> hobbies = new List<Hobby>(){new Hobby("Anime")};
                Profile profile1 = new Profile(currentUser, "Alain", "Male", new School("Dawson College"), TakenCourse, CanHelpCourse, NeedHelpCourse, hobbies,  20, "Computer Science", "Hi I'm new here.");
                profile1 = profileService.AddProfile(profile1);
                int user1_profileId = profile1.ProfileId;

                // 3.	Create an event for user1
                System.Console.WriteLine("Attempt to set up Event for user1");
                // var user1_profile = searchService.SearchProfileByUser(currentUser.UserId);
                List<Course> eventCourses = new List<Course>(){ new Course("Humanities")};
                Event event1_user1 = new Event(profile1, "Studying Humanities", DateTime.Now.AddHours(2), "We will study for the next Humanities exam", "Chez Saza", "Humanities 101", eventCourses, new School("Dawson College"));
                eventService.CreateEvent(event1_user1);
              
                // 4.	Log out from user1
                Logout();

                // 5.	Create a new user account (user2)
                System.Console.WriteLine("Attempt to create user2");
                currentUser = userService.Register("samir", "samir@hema.com", "100");
                User user2 = currentUser;
                System.Console.WriteLine(currentUser);
                if (currentUser != null)
                {
                    Console.WriteLine("User created successfully");
                }
                else
                {
                    Console.WriteLine("User creation failed try logging in");
                    currentUser = userService.Login("samir", "100");
                    if (currentUser != null)
                    {
                        Console.WriteLine("User logged in successfully");
                    }
                    else
                    {
                        Console.WriteLine("User login failed quit");
                        return;
                    }
                }

                // 6.	Create a profile for user2
                System.Console.WriteLine("Attempt to set up Profile for user1");
                List<Course> takenCourseP2 = new List<Course>(){ new Course("Math")};
                List<Course> canHelpCourseP2 = new List<Course>(){ new Course("Linear Algebra")};
                List<Course> needHelpCourseP2 = new List<Course>(){ new Course("Calculus")};
                List<Hobby> hobbiesP2 = new List<Hobby>(){ new Hobby("Gym")};
                Profile profile2 = new Profile(currentUser, "samir", "Male", new School("Dawson College"), takenCourseP2, canHelpCourseP2, needHelpCourseP2, hobbiesP2,  20, "Computer Science", "Hope to meet new people");
                profileService.AddProfile(profile2);

                // 7.	Perform a search to find the event created by user1 
                System.Console.WriteLine("Attempt to find all the events created by user 1");
                var user1profile = searchService.GetProfileById(user1_profileId);
                if (user1profile is not null) //Refactor
                {
                    var user1events = searchService.GetAllProfileEvent(user1profile);
                    foreach (var item in user1events)
                    {
                        System.Console.WriteLine("Event found");
                        System.Console.WriteLine(item.Title);
                    }
                }
                
                // 8.	Mark user2 as attending user1’s event
                System.Console.WriteLine("Attempt to make user2 participate in user1's event");
                event1_user1.AddParticipant(profile2);

                // 9.	Attempt to edit user1’s event as user2 (should fail)
                System.Console.WriteLine("Attempt to edit user1's event as user2 new title is New Title");
                event1_user1 = searchService.SearchEventsCreator(user1profile.ProfileId)[0];
                Event event1New_user1 = new Event(event1_user1.Creator, "New Title", (DateTimeOffset)event1_user1.Date, event1_user1.Description, event1_user1.Location, event1_user1.Subjects, event1_user1.Courses, event1_user1.School);
                event1New_user1.Title = "New Title";
                eventService.EditEvent(event1_user1, event1New_user1, currentUser);
                System.Console.WriteLine("Event title is still: " + event1_user1.Title);

                // 10.	Perform a search that finds user1’s profile
                System.Console.WriteLine("Search to find user one's profile");
                Profile profile_user1_10  = searchService.SearchProfileByUser(user1.UserId);
                if (profile_user1_10 is not null)
                {
                    System.Console.WriteLine("The retrieved profile is for: "+ profile_user1_10.Name);
                }

                // 11.	Send 3 messages from user2 to user1 
                List<string> usernames = new List<string>();
                usernames.Add(currentUser.Username);
                usernames.Add("alain");
                conversationService.CreateConversation(usernames, "Samir and Alain");
                List<Conversation> convos = conversationService.GetConversations(currentUser.UserId);
                Conversation convo = convos[0];
                conversationService.SendMessage("Salut", convo.ConversationId, currentUser.UserId);
                conversationService.SendMessage("Comment ca va?", convo.ConversationId, currentUser.UserId);
                conversationService.SendMessage("Ca va bien?", convo.ConversationId, currentUser.UserId);

                // 12.	Log out from user2
                currentUser = null;

                // 13.	Log in as user1
                currentUser = userService.Login("alain", "100");

                // 14.	Change user1’s password
                userService.ChangePassword("alain", "100", "200");

                // 15.	Modify user1’s profile
                profile1 = searchService.SearchProfileByUser(user1.UserId);
                Profile newProfile1 = new Profile( profile1.User, "Hoang", profile1.Gender, profile1.School, profile1.CourseTaken, profile1.CourseCanHelpWith, profile1.CourseNeedHelpWith, profile1.Hobbies, (int)profile1.Age, profile1.Program, "I like tacos");
                profileService.UpdateProfile(profile1, newProfile1);
                profile1 = searchService.SearchProfileByUser(user1.UserId);
                System.Console.WriteLine("Updated Profile (Name): " + profile1.Name);
                System.Console.WriteLine("Updated Profile (Description): " + profile1.PersonalDescription);
                
                // 16.	Access messages, viewing text of the messages sent by user2.
                List<Conversation> convos2 = conversationService.GetConversations(currentUser.UserId);
                Conversation convo2 = convos2[0];
                List<Message> messages = conversationService.GetMessages(convo2.ConversationId);
                foreach (Message m in messages)
                {
                    System.Console.WriteLine(m.Body);
                }
                
                // 17.	Send a message to user2 from user1.
                System.Console.WriteLine("Sending message to Samir");
                conversationService.SendMessage("Salut Samir", convo2.ConversationId, currentUser.UserId);
                System.Console.WriteLine("Message sent, deleting conversation");
                conversationService.DeleteConversation(convo2.ConversationId);
            
                
                // 18.	Find and view the attendees of user1’s event
                System.Console.WriteLine("View user1's event's participants");
                foreach(var name in  event1_user1.ShowParticipants()){
                    System.Console.WriteLine("Attendee: "+name);
                }
                
                // 19.	Modify user1’s event.
                //Age shool az ghabl vojood dashte bashe kar nemikone be khatere track.
                System.Console.WriteLine("Attempt to edit user1's event");
                event1_user1 = searchService.GetEventById(event1_user1.EventId);
                Event event1_user1_19 = new Event(event1_user1.Creator, "Yaayy New title", (DateTimeOffset)event1_user1.Date, event1_user1.Description, "Toronto Campus", event1_user1.Subjects, event1_user1.Courses, event1_user1.School);
                eventService.EditEvent(event1_user1, event1_user1_19, user1);
                System.Console.WriteLine("Event title is now: " + event1_user1.Title);

            //     // 20.	Delete user1’s profile
            //     System.Console.WriteLine("Deleting profile");
            //     if (currentUser is not null)
            //     {
            //         profileService.DeleteProfile(currentUser);
            //     }
                
            //     // 21.	Delete user1’s account
            //     currentUser = null;
            //     System.Console.WriteLine("Deleting user1");
            //     userService.DeleteUser("alain", "200");

            //     // 22.	Log in as user2
            //     System.Console.WriteLine("Logging in as Samir");
            //     currentUser = userService.Login("samir", "100");

            //     // 23.	Delete user2’s account
            //     System.Console.WriteLine("Deleting user2");
            //     userService.DeleteUser("samir", "100");

            //     // Change the password back to its inital state.
            //     userService.ChangePassword("alain", "200", "100");
            }
        }
        public static void Logout(){
            db.Entry(currentUser).State = EntityState.Detached;
            currentUser = null;
        }
    }
}