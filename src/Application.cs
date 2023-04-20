namespace StudyMate
{
    public class Application{
        public static void Main(string[] args){
            UserDB userDB=new UserDB("amirreza","amir@example.com","ABCD","pwd");
            System.Console.WriteLine(userDB.Id);
        }
    }
}