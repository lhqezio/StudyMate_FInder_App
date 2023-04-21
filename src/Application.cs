namespace StudyMate
{
    public class Application{
        public static void Main(string[] args){
            StudyMateDbContext db = new StudyMateDbContext();

            // 1.	Create a new user account (user1)
            User.Register("user1", "user1@hotmail.com", "testpassword", db);

            // 2.	Create a profile for user1 (You don’t need to fill in all details)
            
            // 3.	Create an event for user1

            // 4.	Log out from user1

            // 5.	Create a new user account (user2)

            // 6.	Create a profile for user2

            // 7.	Perform a search to find the event created by user1

            // 8.	Mark user2 as attending user1’s event

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