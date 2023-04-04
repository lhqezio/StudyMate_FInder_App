// This class hold all the information about a user profile such as
//its interests, courses they are taking, their age, gender and name
//and so on.
namespace StudyMate
{
    public class Profile{
        public string Name { get; set; }="";
        public Genders? Gender { get; set; }
        public int? Age { get; set; }
        public string School { get; set; }="";
        public string Program { get; set; }="";
        public List<Courses> TakenCourses { get; set; } = new List<Courses>();
        public List<Courses> NeedHelpCourses { get; set; } = new List<Courses>();
        public string PersonalDescription { get; set; } = "";
        public string ProfilePicture { get; set; } = ""; //Subject to change because we still do not know exactly if we must use a string to store a picture
        public List<Interests> Hobbies { get; set; } = new List<Interests>();

        //Constructor that builds a profile object with the mandatory fields. The user can set the optional fileds later using the 
        //setters.
        public Profile(string name,Genders gender,int age, string school,List<Courses> needHelpCourses)
        {
            Name = name;
            Gender=gender;
            Age = age;
            School=school;
            NeedHelpCourses=needHelpCourses;
        }

        //This mehtod allows to clear all the fields of the profile class in one shot.
        public void ClearProfile(){
            Name="";
            Gender=null;
            Age=null;
            School="";
            Program="";
            TakenCourses.Clear();
            NeedHelpCourses.Clear();
            PersonalDescription="";
            ProfilePicture="";
            Hobbies.Clear();

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
                profile.Gender == this.Gender &&
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
