﻿// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Profile
    {
        //Generates a random primary key for the Profile class
        [Key]
        public string ProfileId { get; set; }
        
        //One-to-one relationship
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public User User{get;set;}=null!;

        //Profile specific properties
        public string Name { get; set; } = "";
        public String? Gender { get; set; }
        public int? Age { get; set; }
        public string Program { get; set; } = "";
        public string? PersonalDescription { get; set; } = "";
        public string? ProfilePicture { get; set; } = ""; //Subject to change because we still do not know exactly if we must use a string to store a picture

        //Many-to-many relationships
        public List<InterestsProfile> Hobbies { get; set;} = new();
        public List<EventCalendar> Events {get; set;}=new();
        public List<TakenCourses> TakenCourses { get; set;}= new();
        public List<NeedHelpCourses> NeedHelpCourses { get; set;} = new();
        public List<CanHelpCourses> CanHelpCourses { get; set;} = new();

        //One-to-many relationships
        [ForeignKey("School")]
        public string SchoolId{get;set;}
        public School? School{get;set;}=null!;
        public List<EventCalendar> EventsCreated {get;set;}=new();
        
        
        public Profile(){}

        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.
        public Profile(string name, int age, School school, string program, List<NeedHelpCourses> needHelpCourses, User user, Genders gender = Genders.Undisclosed)
        {
            ProfileId=Guid.NewGuid().ToString();
            Name = name;
            Age = age;
            Program = program;
            Gender = gender.ToString();
            SchoolId=school.SchoolId;
            School = school;
            NeedHelpCourses = needHelpCourses;
            UserId=user.UserId;
        }

        //This mehtod allows to clear all the fields of the profile class in one shot.
        public void ClearProfile()
        {
            Name = "";
            Gender = null;
            Age = null;
            School=new();
            SchoolId="";
            Program = "";
            TakenCourses.Clear();
            NeedHelpCourses.Clear();
            CanHelpCourses.Clear();
            Events.Clear();
            EventsCreated.Clear();
            PersonalDescription = "";
            ProfilePicture = "";
            Hobbies.Clear();

        }

        public void AddCreatedEvent(EventCalendar e){
            this.EventsCreated.Add(e);
        }

        //Override of Equals method. This is used to compare two profile objects.
        //It is very useful for testing the ClearProfile method.
        public override bool Equals(object? obj)
        {
            if (obj is not Profile other)
                return false;
            return Name == other.Name
                && Gender == other.Gender
                && Age == other.Age
                && School.Equals(other.School)
                && Program == other.Program
                && TakenCourses.SequenceEqual(other.TakenCourses)
                && NeedHelpCourses.SequenceEqual(other.NeedHelpCourses)
                && CanHelpCourses.SequenceEqual(other.CanHelpCourses)
                && Events.SequenceEqual(other.Events)
                && EventsCreated.SequenceEqual(other.EventsCreated)
                && PersonalDescription == other.PersonalDescription
                && ProfilePicture == other.ProfilePicture
                && Hobbies.SequenceEqual(other.Hobbies);
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                User.GetHashCode() ^
                Gender.GetHashCode() ^
                Age.GetHashCode() ^
                School.GetHashCode() ^
                Program.GetHashCode() ^
                TakenCourses.GetHashCode() ^
                NeedHelpCourses.GetHashCode() ^
                CanHelpCourses.GetHashCode() ^
                Events.GetHashCode() ^
                EventsCreated.GetHashCode() ^
                PersonalDescription.GetHashCode() ^
                ProfilePicture.GetHashCode() ^
                Hobbies.GetHashCode();
        }
    }
}
