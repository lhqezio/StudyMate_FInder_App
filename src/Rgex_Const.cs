namespace StudyMate
{
    public static class Rgex_Const
    {
        public const string Calendar = "12"; 
        public const string Month = "12";
        
        public const string EventCalendarTitleValidator = "";

           
    }

    public static class Profile_Config
    {
        public static List<Courses> needHelp = new List<Courses>((int)Courses.Default_Subject);
        public static Profile clearProfile = new Profile(null, 0, null, needHelp);
    }

    public static class User_Config
    {
        public static List<Courses> needHelp = new List<Courses>((int)Courses.Default_Subject);
        public static Profile clearProfile = new Profile(null, 0, null, needHelp);
    }
}
         