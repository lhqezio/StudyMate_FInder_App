// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
namespace StudyMate
{
    public class Profile{
        public string? Name 
        { get; set; }
        public string? Pronouns 
        { get; set; }
        public int? Age
        {get;set;}
        public string? School
        {get;set;}
        public string? Program 
        { get; set; }
        public List<Courses>? TakenCourses
        {get;set;}
        public List<Courses>? NeedHelpCourses
        {get;set;}
        public string? PersonalDescription
        {get;set;}
        public string? ProfilePicture //Subjet to change since we don't know how to exaclty take a profile picture yet.
        {get;set;}
        public List<Interests>? Hobbies
        {get;set;}

        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.
        public Profile(string name, int age, string school,List<Courses> needHelpCourses)
        {
            Name = name;
            Age = age;
            School=school;
            NeedHelpCourses=needHelpCourses;
        }

        //This mehtod allows to clear all the fields of the profile class in one shot.
        public void ClearProfile(){
            Pronouns=null;
            Age=null;
            School=null;
            Program=null;
            TakenCourses=null;
            NeedHelpCourses=null;
            PersonalDescription=null;
            ProfilePicture=null;
            Hobbies=null;

        }

        //Override of Equals method. This is used to compare two profile objects.
        //It is very useful for testing the ClearProfile method.
        public override bool Equals(object? obj){
            if (obj == null || !(obj is Profile))
            {
                return false;
            }
            Profile profile = (Profile)obj;
            return (
                profile.Name==this.Name &&
                profile.Pronouns == this.Pronouns &&
                profile.Age == this.Age &&
                profile.School == this.School &&
                profile.Program == this.Program &&
                ListsAreEqual(profile.TakenCourses, this.TakenCourses) &&
                ListsAreEqual(profile.NeedHelpCourses, this.NeedHelpCourses) &&
                profile.PersonalDescription == this.PersonalDescription &&
                profile.ProfilePicture == this.ProfilePicture &&
                ListsAreEqual(profile.Hobbies, this.Hobbies));
        }

        //ListsAreEqual is used to check if two lists are actually equal. We need this method since a lot of the fields
        //in this object are lists. This method is used in the Equals method. This is a generic method since the type of lists
        //we are comparing can be different each time. For exmaple we may be comparing Hobbies once and Courses the other time.
        private static bool ListsAreEqual<T>(List<T>? list1, List<T>? list2){
            if (list1 == null && list2 == null)
            {
                return true;
            }
            else if (list1 == null || list2 == null || list1.Count != list2.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (!list1[i].Equals(list2[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        //Since we are overriding the Equals method, we must also override the GetHashCode method.
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^
                Pronouns.GetHashCode() ^
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
