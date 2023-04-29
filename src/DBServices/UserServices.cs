// using System.Security.Cryptography;
// using System.Text;

using System.Security.Cryptography;
using System.Text;

namespace StudyMate;
class UserServices
{
    private StudyMateDbContext _context = null!;
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
    public virtual User AddUser(User user)
    {
        user.PasswordHash=PasswordHasher.HashPassword(user.PasswordHash);
        _context.Users!.Add(user);
        _context.SaveChanges();
        return _context.Login(user.Username, user.PasswordHash);
    }

    public virtual void RemoveUser(User user)
    {
        var toDeleteUser = _context.Users!.FirstOrDefault(u => u.Email == user.Email);
        if (toDeleteUser is not null)
        {
            _context.Users!.Remove(toDeleteUser);
            _context.SaveChanges();
        }
    }

    public virtual void UpdateUserPassword(User user, string password){
        var toUpdateUser = _context.Users!.FirstOrDefault(u => u.Email == user.Email);
        if (toUpdateUser is not null)
        {
            toUpdateUser.PasswordHash=PasswordHasher.HashPassword(password);
            _context.Users!.Update(toUpdateUser);
            _context.SaveChanges();
        }
    }
}
