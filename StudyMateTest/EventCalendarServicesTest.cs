// namespace StudyMateTest;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using StudyMate;
// using Moq;
// using Microsoft.EntityFrameworkCore;

//     [TestClass]
//     public class EventCalendarServicesTest
//     {
//         //Since this information will be reused,  I added it as global 
//                 //Users
//         public static User user1 = new User("1","Alain", "alain@hotmail.com", "password");
//         public static User user2 = new User("2","Sam", "sam@hotmail.com", "password1");
//         public static User user3 = new User("3","Jack", "jack@hotmail.com", "password2");
//                 //Profiles
//         public static Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
//         public static Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
//         public static Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
//                 //profileList list
//         public static List<Profile> profileList = new List<Profile>(){profile2, profile3};
//         public static DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
//         public static bool sent = false;
//         public static string description = "Study with the homies";
//                 //Courses
//         public static CourseEvent ce1 = new CourseEvent(Courses.Math);
//         public static CourseEvent ce2 = new CourseEvent(Courses.Sciences);
//         public static CourseEvent ce3 = new CourseEvent(Courses.Business);
//         public static List<CourseEvent> eventCourses = new List<CourseEvent>(){ce1, ce2, ce3};
//         public static School schoolList = sch1;
//         public static string location = "Montreal";

//         [TestMethod]
//         public void Test_EventCalendarServices_AddEvent(){
//             //Arrange
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
//             // Act
//             service.AddEvent(eC, user1);
//             //Assert
//             mockSet.Verify(p => p.Add(It.IsAny<EventCalendar>()), Times.Once());
//             mockContext.Verify(p => p.SaveChanges(), Times.Once());
//         }

//         [TestMethod]
//         public void Test_EventCalendarServices_CreateEvent(){
//             //Arrange
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
//             // Act
//             service.CreateEvent(user1, "Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location);
//             //Assert
//             mockSet.Verify(p => p.Add(It.IsAny<EventCalendar>()), Times.Once());
//             mockContext.Verify(p => p.SaveChanges(), Times.Once());
//         }

//         [TestMethod]
//         public void Test_EventCalendarServices_DeleteEvent(){
//             //Arrange
//             var listdata = new List<EventCalendar>();
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//                 //To test delete
//             listdata.Add(eC);
//             var data = listdata.AsQueryable();
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.Provider).Returns(data.Provider);
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.Expression).Returns(data.Expression);
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.ElementType).Returns(data.ElementType);
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
//             // Act
//             service.DeleteEvent(eC, user1);
//             // Assert
//             mockSet.Verify(p => p.Remove(It.IsAny<EventCalendar>()), Times.Once());
//             mockContext.Verify(p => p.SaveChanges(), Times.Once());
//         }
   
//         [TestMethod]
//         public void Test_EventCalendarServices_UpdateEvent(){
//             //Arrange
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
//             // Act
//             service.EditEvent(eC, user1);    
//             //Assert
//             mockSet.Verify(p => p.Update(It.IsAny<EventCalendar>()), Times.Once());
//             mockContext.Verify(p => p.SaveChanges(), Times.Once());
//         }        

//         [TestMethod]
//         public void Test_EventCalendarServices_AddParticipants(){
//             // Arrange
//             profileList.Remove(profile3);
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
//             // Act
//             service.AddParticipant(user1, eC, profile3);

//             // Assert
//             mockSet.Verify(p => p.Update(It.IsAny<EventCalendar>()), Times.Once()); //Checks for the update
//             mockContext.Verify(p => p.SaveChanges(), Times.Once()); // Check for the save changes
//             Assert.IsTrue(eC.Participants.Contains(profile3)); // Check if profile3 is part of the participants now
//         }        

//         [TestMethod]
//         public void Test_EventCalendarServices_RemoveParticipants(){
//             // Arrange
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
            
//             // Act
//             service.RemoveParticipant(user1, eC, profile3);
                 
//             // Assert
//             mockSet.Verify(p => p.Update(It.IsAny<EventCalendar>()), Times.Once()); //Checks for the update
//             mockContext.Verify(p => p.SaveChanges(), Times.Once()); // Check for the save changes
//             Assert.IsFalse(eC.Participants.Contains(profile3)); // Check if profile3 is not part of the participants now
//         }

//         [TestMethod]
//         public void Test_EventCalendarServices_ShowParticipants(){
//             // Arrange
//             var listdata = new List<EventCalendar>();
//             EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
//                 //To test Show Participants
//             listdata.Add(eC);
//             var data = listdata.AsQueryable();
//             var mockSet = new Mock<DbSet<EventCalendar>>();
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.Provider).Returns(data.Provider);
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.Expression).Returns(data.Expression);
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.ElementType).Returns(data.ElementType);
//             mockSet.As<IQueryable<EventCalendar>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
//             var mockContext = new Mock<StudyMateDbContext>();
//             mockContext.Setup(p => p.Events).Returns(mockSet.Object);
//             var service = new EventServices(mockContext.Object);
            
//                 //Expected output
//             string expectedParticipantsString = "";
//             foreach (Profile participant in eC.Participants){
//                         expectedParticipantsString = expectedParticipantsString + participant.Name + "; ";
//                     }                 
//             // Act
//             var ActualParticipants = service.ShowParticipants(user1, eC); //Returns a string 


//             // Assert
//             Assert.AreEqual(expectedParticipantsString, ActualParticipants);
//         }
//     }

