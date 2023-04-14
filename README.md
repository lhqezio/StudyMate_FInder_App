# Study Mate

## Description

A study mate matching app, based on favorite subjects and interest.

## Initial Design
    1. We will be using the Study Buddy app 
    2.  Main Classes:
            - User class contains 
                the following fiels:
                    - username
                    - user Id 
                    - session key
                    - password 
                the following functions :
                    - changePassword() 
                    - register()
                    - login()


            - Profile class contains 
                the following fields:
                    - Profile Id 
                    - User Id (foreign key)
                    - Name
                    - Gender
                    - Age 
                    - School
                    - Program
                    - Taken Courses
                    - Course needing help
                    - Personal Description
                    - Profile Picture 
                    - Hobbies 
                the following functions :
                    - ClearProfile() => clear all the fields of the profile class in one shot
                    - Equals() => Override of Equals method and used to compare two profile objects and useful for testing the ClearProfile method.
                    -ListsAreEqual() => check if two lists are actually equal. Needed because lot of the fields in this object are lists (used in Equals() )
                    - GetHashCode() => Since we are overriding the Equals method, we must also override the GetHashCode method
        
            - EventCalendar (Events) class contains 
                    the following fields:
                        - Title 
                        - Creator 
                        - Participants
                        - Date
                        - Description 
                        - Location
                        - Frequency
                        - EventId 
                        - CourseList
                        - Subject School Project List
                    the following functions :
                        - AddParticipants() => Add participant to event
                        - RemoveParticpant() => Remove particpant from event
                        - Attends() => check if a specific participant is part of the event
            - EventManager (Will manage events) class contains 
                    the following fields:
                        - list events (represent event from dtb)
                    the following functions :
                        - AddEvent() => Add event to the list of events
                        - DeleteEvent() => Delete event to the list of events
                        - StoreEvents() => Store Events to Dtb
            
            - Search class contains 
                    the following fields:
                        - DBContext
                    the following functions :
                        - SearchEventsByCourseProgramSchool() => Returns an event based on course, program, school
                        - SearchUsersByCourseProgramSchool() => Returns a user based on course, programm school
                        - SearchEventsByKeyword() => Returns an event based on keywod
                        - SearchUsersByKeyword() => Returns a user based on keyword

            - Message class contains 
                    the following fields:
                        - Sender
                        - Body
                        - Timestamp
                        - Edited
                        - MessageStatus
                    the following functions :
                        - EditMessage() => allows the user to edit a messgae that was already sent. It will also however show on the UI that message was edited. 
                        - MessageSeen()
                        - ToString() => Returns a string that represents the current message, use for debugging purposes only.
    
            - CoursesEnum will contain all the possible courses
            - gendersEnum will contain all the possible genders 
            - InterestsEnum will contain all the possible Interests
## Work Planning

1. Amir: Profile, dtb for profile, unit test for profile, message, partially conversation, matching, link primary key foreign key for user (1 to 1 relationship) 

2. Hoang: Users, dtb for users, unit test for users, conversation, Password Hashing, login, authentication 

3. Mohamed: Reminder Email, EventCalendar (dtb/unit test), EventManager(dtb/unit test), Search (dtb/ unit test)

## Agreements

1. Code must be appropriatelly indented and commented.

2. Each new commited methods must comes with its own unit test to ensure the code is functionnal.

3. Test with white box unit testing and to test it with various operating system (Windows 11, Ubuntu 22.04).

4. Every user input should go through rigorous data validation and sanitization.

5. Every merge request must be approved by a 3 members.
