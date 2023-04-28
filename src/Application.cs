 namespace StudyMate
 {
    
     public class Application{
        public static UserDB currentUser = null;
        public static StudyMateDbContext db = null;
        public static void Main(string[] args){
            db = new StudyMateDbContext();
            var userService=new UserServices(db);
            var profileService = new ProfileServices(db);
            // 1.	Create a new user account (user1)
            //I just store the password here as plain text for simplicity. Otherwise the password should come as an input from the user.
            var user1 = new UserDB("amirXoXo","example@gmail.com","Random password");
            userService.AddUser(user1);
            User currentUser = new User(user1,"100");
            // UserDB userDb1 = db.Users.FirstOrDefault(u => u.Username == user1.Username);

            // 2.	Create a profile for user1 (You don’t need to fill in all details)
            School sch = new School("Dawson College");
            Profile profile1 = new Profile("alain", 18, sch,"Computer science", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)}, user1);
            profileService.AddProfile(profile1,currentUser);
            
            // 3.	Create an event for user1
            
            //Users
            UserDB participant1 = new UserDB("Sam", "sam@hotmail.com", "password1");
            UserDB participant2 = new UserDB("Jack", "jack@hotmail.com", "password2");
            //Profiles
            Profile participant1_profile = new Profile("Sam", 20, new School("Henri-Bourassa"),"Education", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, participant1);
            Profile participant2_profile = new Profile("Jack", 18, new School("Saint-Ex"),"Sports studies", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Calculus)}, participant2);
            //Profile list
            List<Profile> profileList = new List<Profile>();
            profileList.Add(profile1);
            profileList.Add(participant1_profile);
            profileList.Add(participant2_profile);
            DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
            bool sent = true;
            string description = "Study with the homies";
            //Courses
            List<CourseEvent> eventCourses = new List<CourseEvent>();
            CourseEvent ce1 = new CourseEvent(Courses.Math);
            CourseEvent ce2 = new CourseEvent(Courses.Sciences);
            CourseEvent ce3 = new CourseEvent(Courses.Business);
            eventCourses.Add(ce1);
            eventCourses.Add(ce2);
            eventCourses.Add(ce3);
            School school = new School("Dawson College");
            string location = "Montreal";

            //Act
            EventCalendar eC = new EventCalendar("Study event", profile1, profileList, dTime, description, school, eventCourses, location, sent);
            profile1.Events.Add(eC);

            // 4.	Log out from user1
            db.Logout(currentUser.__session_key);


            // 5.	Create a new user account (user2)
            var user2 = new UserDB("user2", "user2@hotmail.com", "testpassword");
            userService.AddUser(user2);
            currentUser = new User(user2,"200");
            // UserDB userDb2 = db.Users.FirstOrDefault(u => u.Username == user2.Username);

            // 6.	Create a profile for user2
            School sch2 = new School("Vanier");
            Profile profile2 = new Profile("Samir", 18, sch2,"Health science", new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, user2);

            // 7.	Perform a search to find the event created by user1
            Search search = new Search(db);
            EventCalendar ec = search.SearchEventsCreator(profile1)[0];

            // 8.	Mark user2 as attending user1’s event
            ec.AddParticipant(profile2);

            // 9.	Attempt to edit user1’s event as user2 (should fail)
            
            
            // 10.	Perform a search that finds user1’s profile

            // 11.	Send 3 messages from user2 to user1

            // 12.	Log out from user2

            // 13.	Log in as user1

            // 14.	Change user1’s password

            // 15.	Modify user1’s profile

            // 16.	Access messages, viewing text of the messages sent by user2.

            // 17.	Send a message to user2 from user1.

            // 18.	Find and view the attendees of user1’s event

            // 19.	Modify user1’s event.

            // 20.	Delete user1’s profile

            // 21.	Delete user1’s account

            // 22.	Log in as user2

            // 23.	Delete user2’s account

        }
    }
 }
