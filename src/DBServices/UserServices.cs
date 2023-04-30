using System.Security.Cryptography;
using System.Text;

namespace StudyMate;
class UserServices
{
    private StudyMateDbContext _context = null!;
    private static UserServices? _instance;
    public static UserServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new UserServices(context);
        }
        return _instance;
    }
    public UserServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual User? Login(string username, string password)
    {
        // Get the user from the database
        User? user = _context.Users?.SingleOrDefault(u => u.Username == username);

        // If the user doesn't exist, return null
        if (user == null)
        {
            return null;
        }

        // If the password is incorrect, return null
        if (!PasswordHasher.VerifyPassword(password, user.PasswordHash))
        {
            System.Console.WriteLine("wrong");
            return null;
        }
        // If the user is valid, return a User object
        return new User(user.UserId, user.Username, user.PasswordHash, user.UserId);
    }

    public virtual User? Logout(string username)
    {
        // Get the user from the database
        User? user = _context.Users?.SingleOrDefault(u => u.Username == username);
        user=null;
        return user;
    }

    public virtual User? Register(string username, string email, string password)
    {
        // Get the user from the database
        User? user = _context.Users?.SingleOrDefault(u => u.Username == username);

        // If the user already exists, return null
        if (user != null)
        {
            return null;
        }

        // Create a new user
        user = new User(Guid.NewGuid().ToString(), username, email, PasswordHasher.HashPassword(password));

        // Add the user to the database
        _context.Users?.Add(user);
        _context.SaveChanges();
        return Login(username, password);
    }

    public virtual void ChangePassword(string username,string oldpasswod, string newPassword)
    {
        if (Login(username, oldpasswod) != null)
        {
            var user = _context.Users?.SingleOrDefault(u => u.Username == username);
            if (user is not null)
            {
                user.PasswordHash = PasswordHasher.HashPassword(newPassword);
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The user you want to change password for does not exist");
            }
        }
    }
    public virtual void DeleteUser(string username,string password)
    {
        if (Login(username, password) != null)
        {
            var user=_context.Users?.SingleOrDefault(u => u.Username == username);
            if (user is not null)
            {
                _context.Users?.Remove(user);
                System.Console.WriteLine(_context.Users?.Count());
                _context.SaveChanges();
            }else{
                System.Console.WriteLine("The user you want to delete does not exist");
            }
        }
    }
}
