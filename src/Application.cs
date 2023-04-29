 namespace StudyMate
 {
    
     public class Application{
        public static User currentUser = null;
        public static StudyMateDbContext db = null;
        public static void Main(string[] args){
            // using (db = new StudyMateDbContext())
            // {
            //     System.Console.WriteLine("What's up Andrew?");
            //     System.Console.WriteLine("Here is our PROOF");

            //     var userService = new UserServices(db);
            //     var profileService = new ProfileServices(db);
            //     var eventService = new EventServices(db);
            //     var conversationService = new ChatServices(db);

            //     // 1.	Create a new user account (user1)

            //     //I just store the password here as plain text for simplicity. Otherwise the password should come as an input from the user.
            //     System.Console.WriteLine("Attempt to create user1");
            //     var user=new User("1","Amirreza","amir@gmail.com","123");
            //     currentUser = userService.Register("Amirreza","amir@gmail.com","123");
            //     System.Console.WriteLine(currentUser);
            //     if (currentUser != null)
            //     {
            //         Console.WriteLine("User created successfully");
            //     }
            //     else
            //     {
            //         Console.WriteLine("User creation failed try logging in");
            //         currentUser = userService.Login("Amirreza", "123");
            //         if(currentUser != null){
            //             Console.WriteLine("User logged in successfully");
            //         }
            //         else {
            //             Console.WriteLine("User login failed quit");
            //             return;                   
            //          }
            //     }
                
                
            //     //2.	Create a profile for user1 (You don’t need to fill in all details)

            //     System.Console.WriteLine("Attempt to Create Profile for user1");
            //     School sch = new School("Dawson College");
            //     Profile profile1 = new Profile("alain", 18, sch,"Computer science", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)}, currentUser);
            //     profileService.DeleteProfile(profile1);
            //     profileService.AddProfile(profile1);
                
            //     // 3.Create an event for user1

            //     System.Console.WriteLine("Attempt to set up Events");
            //     //Users
            //     User participant1 = new User(Guid.Empty.ToString(),"Sam", "sam@hotmail.com", "password1");
            //     User participant2 = new User(Guid.Empty.ToString(),"Jack", "jack@hotmail.com", "password2");
            //     //Profiles
            //     Profile participant1_profile = new Profile("Sam", 20, new School("Henri-Bourassa"),"Education", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, participant1);
            //     Profile participant2_profile = new Profile("Jack", 18, new School("Saint-Ex"),"Sports studies", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Calculus)}, participant2);
            //     //Profile list
            //     List<Profile> profileList = new List<Profile>();
            //     profileList.Add(profile1);
            //     profileList.Add(participant1_profile);
            //     profileList.Add(participant2_profile);
            //     DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
            //     bool sent = true;
            //     string description = "Study with the homies";
            //     //Courses
            //     List<CourseEvent> eventCourses = new List<CourseEvent>();
            //     CourseEvent ce1 = new CourseEvent(Courses.Math);
            //     CourseEvent ce2 = new CourseEvent(Courses.Sciences);
            //     CourseEvent ce3 = new CourseEvent(Courses.Business);
            //     eventCourses.Add(ce1);
            //     eventCourses.Add(ce2);
            //     eventCourses.Add(ce3);
            //     string location = "Montreal";

            //     //Act
            //     EventCalendar eC = new EventCalendar("Study event", profile1, profileList, dTime, description, sch, eventCourses, location, sent);
            //     profile1.Events.Add(eC);
            //     // profile1.AddCreatedEvent(eC);
            //     // profileService.UpdateProfile(profile1);
            //     // eventService.AddEvent(eC,currentUser);
                
                

            //     // 4.	Log out from user1

            //     currentUser = null;

            //     // 5.	Create a new user account (user2)

            //     // // 5.	Create a new user account (user2)
            //     // currentUser = userService.Register("samir", "samir@hema.com", "password");
            //     // // User User2 = db.Users.SingleOrDefault(u => u.Username == user2.Username);
            //     System.Console.WriteLine("Attempt to create user2");
            //     currentUser = userService.Register("samir", "samir@hema.com", "100");
            //     System.Console.WriteLine(currentUser);
            //     if (currentUser != null)
            //     {
            //         Console.WriteLine("User created successfully");
            //     }
            //     else
            //     {
            //         Console.WriteLine("User creation failed try logging in");
            //         currentUser = userService.Login("samir", "100");
            //         if(currentUser != null){
            //             Console.WriteLine("User logged in successfully");
            //         }
            //         else {
            //             Console.WriteLine("User login failed quit");
            //             return;                    
            //         }
            //     }

            //     // 6.	Create a profile for user2

            //     School sch2 = new School("Vanier");
            //     Profile profile2 = new Profile("Samir", 18, sch2,"Health science", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, currentUser);

            //     // // 7.	Perform a search to find the event created by user1
            //     // Search search = new Search(db);
            //     // EventCalendar ec = search.SearchEventsCreator(profile1)[0];

            //     // 8.	Mark user2 as attending user1’s event
            //     eC.AddParticipant(profile2);

            //     // 9.	Attempt to edit user1’s event as user2 (should fail)
                
            //     // 10.	Perform a search that finds user1’s profile

            //     // 11.	Send 3 messages from user2 to user1 
            //     List<string> usernames = new List<string>();
            //     usernames.Add(currentUser.Username);
            //     usernames.Add("alain");
            //     conversationService.CreateConversation(usernames,"Samir and Alain");
            //     List<Conversation> convos = conversationService.GetConversations(currentUser.UserId);
            //     Conversation convo = convos[0];
            //     conversationService.SendMessage("Salut", convo.ConversationId, currentUser.UserId);
            //     conversationService.SendMessage("Comment ca va?", convo.ConversationId, currentUser.UserId);
            //     conversationService.SendMessage("Ca va bien?", convo.ConversationId, currentUser.UserId);
            //     // 12.	Log out from user2
            //     currentUser = null;
            //     // 13.	Log in as user1
            //     currentUser = userService.Login("alain", "100");
            //     // 14.	Change user1’s password
            //     userService.ChangePassword("alain","100", "200");
            //     // 15.	Modify user1’s profile
            //     var profile=profileService.GetSpecificProfileById(currentUser.UserId);
            //     profile.Age=20;
            //     // 16.	Access messages, viewing text of the messages sent by user2.
            //     List<Conversation> convos2 = conversationService.GetConversations(currentUser.UserId);
            //     Conversation convo2 = convos2[0];
            //     List<Message> messages = conversationService.GetMessages(convo2.ConversationId);
            //     foreach(Message m in messages){
            //         System.Console.WriteLine(m.Body);
            //     }
            //     // 17.	Send a message to user2 from user1.
            //     System.Console.WriteLine("Sending message to Samir");
            //     conversationService.SendMessage("Salut Samir", convo2.ConversationId, currentUser.UserId);
            //     System.Console.WriteLine("Message sent, deleting conversation");
            //     conversationService.DeleteConversation(convo2.ConversationId);
            //     // 18.	Find and view the attendees of user1’s event
            //     foreach (var item in profile.Events)
            //     {
            //         var participants=item.ShowParticipants();
            //         System.Console.WriteLine(participants);
            //     }
            //     // 19.	Modify user1’s event.

            //     // 20.	Delete user1’s profile
            //     System.Console.WriteLine("Deleting profile");
            //     profileService.DeleteProfile(currentUser);

            //     // 21.	Delete user1’s account
            //     currentUser = null;
            //     System.Console.WriteLine("Deleting user1");
            //     userService.DeleteUser("alain","200");
            //     // 22.	Log in as user2
            //     System.Console.WriteLine("Logging in as Samir");
            //     currentUser = userService.Login("samir", "100");
            //     // 23.	Delete user2’s account
            //     System.Console.WriteLine("Deleting user2");
            //     userService.DeleteUser("samir","100");
            // }
        }
    }
 }
