using System;
using src;

namespace StudyMateTests;

[TestClass]
public class EventCalendarTest
{
    [TestMethod]
    public void TestEventCalendarConstructor(){//Test 1 
        //Arrange
        EventManager eM = new EventManager();
        
        //Act
        List<EventCalendar> lEvents = new List<EventCalendar>();

        //Assert
        Assert.AreEqual(lEvents, eM);
        Assert.IsInstanceOfType(eM, typeof(EventManager));
    }
}