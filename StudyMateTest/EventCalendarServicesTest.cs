namespace StudyMateTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyMate;
using Moq;
using Microsoft.EntityFrameworkCore;

    [TestClass]
    public class EventCalendarServicesTest
    {
        //Since this information will be reused,  I added it as global 
        public static School sch1 = new School("Dawson College");
        public static School sch2 = new School("Henri-Bourassa");
        public static School sch3 = new School("Saint-Ex");
                //Users
        public static User user1 = new User("Alain", "alain@hotmail.com", "password");
        public static User user2 = new User("Sam", "sam@hotmail.com", "password1");
        public static User user3 = new User("Jack", "jack@hotmail.com", "password2");
                //Profiles
        public static Profile profile1 = new Profile("Alain", 20,new School("Dawson College"),"Computer Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Computer_Science)},user1,Genders.Male);
        public static Profile profile2 = new Profile("Samantha", 18,new School("Henri-Bourassa"),"Social Science",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Political_Science)},user2,Genders.Female);
        public static Profile profile3 = new Profile("Jackie", 19,new School("Vanier COllege"),"Business",new List<NeedHelpCourses>(){new NeedHelpCourses(Courses.Business)},user3,Genders.Undisclosed);
                //profileList list
        public static List<Profile> profileList = new List<Profile>();
        public static DateTimeOffset dTime = DateTimeOffset.Now.AddMonths(1);
        public static bool sent = false;
        public static string description = "Study with the homies";
                //Courses
        public static List<CourseEvent> eventCourses = new List<CourseEvent>();
        public static CourseEvent ce1 = new CourseEvent(Courses.Math);
        public static CourseEvent ce2 = new CourseEvent(Courses.Sciences);
        public static CourseEvent ce3 = new CourseEvent(Courses.Business);
        public static School schoolList = sch1;
        public static string location = "Montreal";

        [TestMethod]
        public void Test_EventCalendarServices_AddEvent(){
            //Arrange
            profileList.Add(profile2);
            profileList.Add(profile3);
            eventCourses.Add(ce1);
            eventCourses.Add(ce2);
            eventCourses.Add(ce3);
            EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
            var mockSet = new Mock<DbSet<EventCalendar>>();
            var mockContext = new Mock<StudyMateDbContext>();
            mockContext.Setup(p => p.Events).Returns(mockSet.Object);
        
            // Act
            using(var service = EventServices.getInstance(mockContext.Object)){
                service.AddEvent(eC, user1);
                } 

            //Assert
                mockSet.Verify(p => p.Add(It.IsAny<EventCalendar>()), Times.Once());
                mockContext.Verify(p => p.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Test_EventCalendarServices_DeleteEvent(){
            //Arrange
            profileList.Add(profile2);
            profileList.Add(profile3);
            eventCourses.Add(ce1);
            eventCourses.Add(ce2);
            eventCourses.Add(ce3);
            EventCalendar eC = new EventCalendar("Title1", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
            var mockSet = new Mock<DbSet<EventCalendar>>();
            var mockContext = new Mock<StudyMateDbContext>();
            mockContext.Setup(p => p.Events).Returns(mockSet.Object);
        
            // Act
            using(var service = EventServices.getInstance(mockContext.Object)){
                service.DeleteEvent(eC, user1);
                } 

            //Assert
                mockSet.Verify(p => p.Remove(It.IsAny<EventCalendar>()), Times.Once());
                mockContext.Verify(p => p.SaveChanges(), Times.Once());
        }
   
        [TestMethod]
        public void Test_EventCalendarServices_EditEvent(){
            //Arrange
            profileList.Add(profile2);
            profileList.Add(profile3);
            eventCourses.Add(ce1);
            eventCourses.Add(ce2);
            eventCourses.Add(ce3);
            EventCalendar eC = new EventCalendar("New Title", profile1, profileList, dTime, description, schoolList, eventCourses, location, sent);
            var mockSet = new Mock<DbSet<EventCalendar>>();
            var mockContext = new Mock<StudyMateDbContext>();
            mockContext.Setup(p => p.Events).Returns(mockSet.Object);
        
            // Act
            using(var service = EventServices.getInstance(mockContext.Object)){
                service.UpdateEvent(eC, user1);
                } 

            //Assert
                mockSet.Verify(p => p.Update(It.IsAny<EventCalendar>()), Times.Once());
                mockContext.Verify(p => p.SaveChanges(), Times.Once());
        }        
    }

