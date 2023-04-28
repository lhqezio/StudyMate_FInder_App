# Study Mate

## Description

A study mate matching app, based on favorite subjects and interest.

## Initial Design
1. We are going to use the original flavour of the Study Buddy app with an improved matching system 
2. Main Classes:


            - User class contains 
                the following fiels:
                    - username
                    - user Id 
                    - session key
                    - password 
                the following functions :
                    - changePassword() 
                    - Register()
                    - Login()


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

3. Every single class will be tested thus each of these class will have its corresponding unit test

## Work Planning

1. Amir: Profile, dtb for profile, unit test for profile, message, partially conversation, matching, link primary key foreign key for user (1 to 1 relationship) 

2. Hoang: Users, dtb for users, unit test for users, conversation, Password Hashing, Login, authentication 

3. Mohamed: Reminder Email, EventCalendar (dtb/unit test), EventManager(dtb/unit test), Search (dtb/ unit test)

## Coding Standards and Team Collaboration
### Overview
This document outlines the coding standards and collaboration practices that we will follow as a team to ensure that our code is readable, maintainable, and adheres to best practices.

### Coding Standards
To ensure that our code conforms to team standards, each member should take the following steps:

1. Refactor any methods that exceed a certain number of lines, such as 30. This promotes readability and helps to break down complex logic into more manageable pieces.
2. Use meaningful variable and method names that accurately describe their purpose. Avoid abbreviations or unclear names.
3. Keep methods focused on a single task and minimize dependencies. Avoid long chains of method calls or complex control flow.
4. Write comments to explain the general idea behind each method and any complex algorithms or logic. Additional comments can be added as necessary.
5. Use consistent formatting and indentation. This promotes readability and helps with understanding code.
6. Test code thoroughly before merging to ensure that there are no conflicts or bugs.

### Team Collaboration
To ensure effective collaboration, we will:

1. Review each other's code to ensure readability and adherence to coding standards. Provide constructive feedback and suggestions for improvement.
2. Continuously communicate progress and challenges with the team. If one aspect of the project ends up taking longer than anticipated, re-evaluate the division of labor and adjust as necessary to ensure fair distribution of work.
3. Attend regular team meetings to discuss progress and any issues that may arise. This promotes collaboration and helps to ensure that everyone is on the same page.
4. Document any important decisions or changes made during the project. This helps to avoid confusion and ensures that everyone is aware of what is happening.
