using Microsoft.EntityFrameworkCore;

namespace StudyMate
{
     public class Application
     {
        public static User? currentUser;
        public static StudyMateDbContext? db;
        // public static readonly string DemoCourses = "Math 101,Phys 202,Art 303";
         public static void Main(string[] args)
         {
            using (db = new StudyMateDbContext())
            {
                //Set-up
                System.Console.WriteLine("What's up Andrew?");
                System.Console.WriteLine("Here is our PROOF");
                var userService = new UserServices(db);
                var profileService = new ProfileServices(db);
                var schoolService = new SchoolServices(db);
                var courseService = new CourseServices(db);
                var conversationService = new ChatServices(db);
                // var eventService = new EventServices(db);
                
                // 1.	Create a new user account (user1)
                System.Console.WriteLine("Attempt to create user1");
                currentUser = userService.Register("alain", "alain@heaumo.co", "100");
                System.Console.WriteLine(currentUser);
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

                // 2.	Create a profile for user1 (You don’t need to fill in all details)
                System.Console.WriteLine("Attempt to set up Profile for user1");
                var profile1= new Profile("1",currentUser,"Alain","Male",new School("1","Dawson"),18,"Computer Science");
                List<CourseNeedHelpWith> coursesNeedHelpWith1=new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(profile1,new Course("1","Math")),new CourseNeedHelpWith(profile1,new Course("2","Cinema"))};
                profile1.CourseNeedHelpWith=coursesNeedHelpWith1;
                profileService.AddProfile(profile1);

                // 3.	Create an event for user1
//                 System.Console.WriteLine("Attempt to set up Event for user1");
//                 currentUser.Profile = profileService.GetMyProfile(currentUser);
//                 eventService.AddEvent(currentUser, new List<Profile>() { profile1 }, "Study for Math 101", "Math 101", DateTime.Now.AddHours(2), "Chez saza", DemoCourses);
                
                // 4.	Log out from user1
                currentUser = userService.Logout(currentUser.Username);

                // 5.	Create a new user account (user2)
                System.Console.WriteLine("Attempt to create user2");
                currentUser = userService.Register("samir", "samir@hema.com", "100");
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
                var profile2= new Profile("2",currentUser,"samir","Male",new School("1","Dawson"),20,"Computer Science");
                List<CourseNeedHelpWith> coursesNeedHelpWith2=new List<CourseNeedHelpWith>(){new CourseNeedHelpWith(profile2,new Course("2","Cinema")),new CourseNeedHelpWith(profile2,new Course("3","Geography"))};
                profile2.CourseNeedHelpWith=coursesNeedHelpWith2;
                profileService.AddProfile(profile2);

                // 7.	Perform a search to find the event created by user1
//                 var user1profile = profileService.GetProfileByName("Alain")[0];
//                 var user1event = eventService.GetAllMyEvents(user1profile)[0];
//                 System.Console.WriteLine("Event found");
//                 System.Console.WriteLine(user1event.Title);
//                 // // 8.	Mark user2 as attending user1’s event
//                 eventService.MarkAttending(profileService.GetMyProfile(currentUser), user1event);
//                 System.Console.WriteLine("User2 marked as attending user1's event:");
//                 foreach (Profile p in user1event.Participant)
//                 {
//                     System.Console.WriteLine(p.Name);
//                 }
//                 System.Console.WriteLine("End Attending List");

                // 9.	Attempt to edit user1’s event as user2 (should fail)
//                 System.Console.WriteLine("Attempt to edit user1's event as user2 new title is New Title");
//                 user1event.Title = "New Title";
//                 System.Console.WriteLine("Event title is still: " + user1event.Title);


                // 10.	Perform a search that finds user1’s profile
//                 var user1 = profileService.GetProfileByName("Alain")[0];

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
                if (currentUser is not null)
                {
                    var my_profile = profileService.GetMyProfile(currentUser);
                    if (my_profile is not null)
                    {
                        my_profile.Name = "Amirreza";
                        schoolService.AddSchool(new School("2","Tehran University"));
                        my_profile.SchoolId="2";
                        profileService.UpdateProfile(my_profile);
                    }
                    my_profile = profileService.GetMyProfile(currentUser);
                    if (my_profile is not null)
                    {
                        var school=schoolService.GetSchool(my_profile.SchoolId);
                        System.Console.WriteLine("Updated Profile (Name)" + my_profile.Name);
                        if (school is not null)
                        {
                            System.Console.WriteLine("Updated Profile (School)" + school.SchoolName);
                        }
                    }
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
                }
                
                // // 18.	Find and view the attendees of user1’s event
                // var user1event2 = eventService.GetAllMyEvents(profileService.GetMyProfile(currentUser))[0];
                // System.Console.WriteLine("Event found, Printing Attendees");
                // foreach (Profile p in user1event2.Participant)
                // {
                //     System.Console.WriteLine(p.Name);
                // }
                // System.Console.WriteLine("End Attendees List");

                // // 19.	Modify user1’s event.
                // user1event2.Title = "New Title";
                // eventService.UpdateEvent(currentUser, user1event2);
                // var user1event3 = eventService.GetAllMyEvents(profileService.GetMyProfile(currentUser))[0];

                // 20.	Delete user1’s profile
                System.Console.WriteLine("Deleting profile");
                if (currentUser is not null)
                {
                    profileService.DeleteProfile(currentUser);
                }
                
                // 21.	Delete user1’s account
                currentUser = null;
                System.Console.WriteLine("Deleting user1");
                userService.DeleteUser("alain", "200");

                // 22.	Log in as user2
                System.Console.WriteLine("Logging in as Samir");
                currentUser = userService.Login("samir", "100");

                // 23.	Delete user2’s account
                System.Console.WriteLine("Deleting user2");
                userService.DeleteUser("samir", "100");

                // Change the password back to its inital state.
                userService.ChangePassword("alain", "200", "100");
            }
        }
    }
}