// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyMate
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        [ForeignKey("UserDB")]
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public Genders? Gender { get; set; }
        public int? Age { get; set; }
        public string School { get; set; } = "";
        public string Program { get; set; } = "";
        public List<Courses> TakenCourses { get; set; } = new List<Courses>();
        public List<Courses> NeedHelpCourses { get; set; } = new List<Courses>();
        public string PersonalDescription { get; set; } = "";
        public string ProfilePicture { get; set; } = ""; //Subject to change because we still do not know exactly if we must use a string to store a picture
        public List<Interests> Hobbies { get; set; } = new List<Interests>();

        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.
        public Profile(string name, int age, string school, List<Courses> needHelpCourses,Genders gender = Genders.Undisclosed)
        {
            Name = name;
            Gender = gender;
            Age = age;
            School = school;
            NeedHelpCourses = needHelpCourses;
        }

        //This mehtod allows to clear all the fields of the profile class in one shot.
        public void ClearProfile()
        {
            Name = "";
            Gender = null;
            Age = null;
            School = "";
            Program = "";
            TakenCourses.Clear();
            NeedHelpCourses.Clear();
            PersonalDescription = "";
            ProfilePicture = "";
            Hobbies.Clear();

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
                && School == other.School
                && Program == other.Program
                && TakenCourses.SequenceEqual(other.TakenCourses)
                && NeedHelpCourses.SequenceEqual(other.NeedHelpCourses)
                && PersonalDescription == other.PersonalDescription
                && ProfilePicture == other.ProfilePicture
                && Hobbies.SequenceEqual(other.Hobbies);
        }

        //ListsAreEqual is used to check if two lists are actually equal. We need this method since a lot of the fields
        //in this object are lists. This method is used in the Equals method. This is a generic method since the type of lists
        //we are comparing can be different each time. For exmaple we may be comparing Hobbies once and Courses the other time.
        private static bool ListsAreEqual<T>(IList<T>? list1, IList<T>? list2)
        {
            if (list1 is null || list2 is null)
                return list1 == list2;

            return list1.SequenceEqual(list2);
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                Gender.GetHashCode() ^
                Age.GetHashCode() ^
                School.GetHashCode() ^
                Program.GetHashCode() ^
                TakenCourses.GetHashCode() ^
                NeedHelpCourses.GetHashCode() ^
                PersonalDescription.GetHashCode() ^
                ProfilePicture.GetHashCode() ^
                Hobbies.GetHashCode();
        }
    }
}
