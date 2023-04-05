namespace StudyMate;
class StudyMate {
    public static void Main(string[] args) {
        string val = PasswordHasher.HashPassword("jayz");
        System.Console.WriteLine(val);
        System.Console.WriteLine(PasswordHasher.VerifyPassword("jayz",val));
    }
}