// using System.Security.Cryptography;
// using System.Text;

using System.Security.Cryptography;
using System.Text;

namespace StudyMate;
class UserServices : IDisposable
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

    public User Login(string username, string password)
    {
        return _context.Login(username, password);
    }

    public User Register(string username, string email, string password)
    {
        return _context.Register(username, email, password);
    }
    public virtual void AddUser(User user)
    {
        _context.Users!.Add(user);
        _context.SaveChanges();
    }

    public virtual void RemoveUser(User user)
    {
        _context.Users!.Remove(user);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public virtual void ChangePassword(User user,string newPassword)
    {
        _context.ChangePassword(user, newPassword);
    }
}
