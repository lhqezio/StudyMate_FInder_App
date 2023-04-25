 namespace StudyMate
 {
    
     public class Application{
        public static User currentUser = null;
        public static StudyMateDbContext db = null;
        public static StudyMateService service = StudyMateService.getInstance();

        public static void Main(string[] args){
<<<<<<< HEAD
            // db = new StudyMateDbContext();
=======
            db = new StudyMateDbContext();
            service.setStudyMateDbContext(db);
>>>>>>> 4c9f2cabbd58f44f01a16db1ff0dc247035f6e88

            // // 1.	Create a new user account (user1)
            // var user1 = User.Register("user1", "user1@hotmail.com", "testpassword", db);
            // currentUser = user1;
            // UserDB userDb1 = db.Users.FirstOrDefault(u => u.Username == user1.Username);

            // // 2.	Create a profile for user1 (You don’t need to fill in all details)
            // School sch = new School("Dawson College");
            // Profile profile1 = new Profile("alain", 18, sch, new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.History)}, userDb1);
            
            // // 3.	Create an event for user1
            //  School sch1 = new School("Dawson College");
            // School sch2 = new School("Henri-Bourassa");
            // School sch3 = new School("Saint-Ex");
    
<<<<<<< HEAD
            // //Users
            // UserDB user2 = new UserDB("Sam", "sam@hotmail.com", "password1");
            // UserDB user3 = new UserDB("Jack", "jack@hotmail.com", "password2");
            // //Profile
            // Profile profile2 = new Profile("Sam", 20, sch2, new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, user2);
            // Profile profile3 = new Profile("Jack", 18, sch3, new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Calculus)}, user3);
            // //Profile list
            // List<Profile> profileList = new List<Profile>();
            // profileList.Add(profile2);
            // profileList.Add(profile3);
            // DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
            // bool sent = false;
            // string description = "Study with the homies";
            // //Courses
            // List<CourseEvent> eventCourses = new List<CourseEvent>();
            // CourseEvent ce1 = new CourseEvent(Courses.Math);
            // CourseEvent ce2 = new CourseEvent(Courses.Sciences);
            // CourseEvent ce3 = new CourseEvent(Courses.Business);
            // eventCourses.Add(ce1);
            // eventCourses.Add(ce2);
            // eventCourses.Add(ce3);
            // School schoolList = sch1;
            // string location = "Montreal";

            // //Act
            // EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
            // db.AddEvent(eC, user1);

            // // 4.	Log out from user1
            // currentUser.Logout(db);
=======
            //Users
            UserDB user2 = new UserDB("Sam", "sam@hotmail.com", "password1");
            UserDB user3 = new UserDB("Jack", "jack@hotmail.com", "password2");
            //Profile
            Profile profile2 = new Profile("Sam", 20, sch2, new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, user2);
            Profile profile3 = new Profile("Jack", 18, sch3, new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Calculus)}, user3);
            //Profile list
            List<Profile> profileList = new List<Profile>();
            profileList.Add(profile2);
            profileList.Add(profile3);
            DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
            string description = "Study with the homies";
            //Courses
            List<CourseEvent> eventCourses = new List<CourseEvent>();
            CourseEvent ce1 = new CourseEvent(Courses.Math);
            CourseEvent ce2 = new CourseEvent(Courses.Sciences);
            CourseEvent ce3 = new CourseEvent(Courses.Business);
            eventCourses.Add(ce1);
            eventCourses.Add(ce2);
            eventCourses.Add(ce3);
            School schoolList = sch1;
            string location = "Montreal";

            service.CreateEvent(user1,"Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location);
            
            // 4.	Log out from user1
            currentUser.Logout(db);
>>>>>>> 4c9f2cabbd58f44f01a16db1ff0dc247035f6e88


            // // 5.	Create a new user account (user4)
            // User user4 = User.Register("Samir", "Samir@hotmail.com", "testPassword2", db);
            // currentUser = user4;
            // UserDB userDb4 = db.Users.FirstOrDefault(u => u.Username == user4.Username);

            // // 6.	Create a profile for user4
            // School sch4 = new School("Vanier");
            // Profile profile4 = new Profile("Samir", 18, sch4, new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Art)}, userDb4);

            // // 7.	Perform a search to find the event created by user1
            // Search search = new Search(db);
            // EventCalendar ec = search.SearchEventsCreator(profile1)[0];

            // // 8.	Mark user4 as attending user1’s event
            // ec.AddParticipant(profile4);

<<<<<<< HEAD
            // // 9.	Attempt to edit user1’s event as user2 (should fail)
            

            // // 10.	Perform a search that finds user1’s profile
=======
            // 9.	Attempt to edit user1’s event as user4 (should fail)
            service.EditEvent(user4, ec, "New Title as user4");

            // 10.	Perform a search that finds user1’s profile
            var profileUser1 = search.SearchProfileByUser(user1);
>>>>>>> 4c9f2cabbd58f44f01a16db1ff0dc247035f6e88

            // // 11.	Send 3 messages from user2 to user1

            // // 12.	Log out from user2

            // // 13.	Log in as user1

            // // 14.	Change user1’s password

            // // 15.	Modify user1’s profile

            // // 16.	Access messages, viewing text of the messages sent by user2.

            // // 17.	Send a message to user2 from user1.

<<<<<<< HEAD
            // // 18.	Find and view the attendees of user1’s event

            // // 19.	Modify user1’s event.

            // // 20.	Delete user1’s profile
=======
            // 18.	Find and view the attendees of profile1’s event
            EventCalendar profile1Event = search.SearchEventsCreator(profile1)[0];
            service.ShowParticipants(user1, profile1Event);

            // 19.	Modify user1’s event.
            service.EditEvent(user1, profile1Event, "New Title as user1");
            service.ShowParticipants(user1, profile1Event);
            
            // 20.	Delete user1’s profile
>>>>>>> 4c9f2cabbd58f44f01a16db1ff0dc247035f6e88

            // // 21.	Delete user1’s account

            // // 22.	Log in as user2

            // // 23.	Delete user2’s account

        }
    }
 }