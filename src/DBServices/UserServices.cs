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
    private UserServices(StudyMateDbContext context)
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

    public User LoginFromSessionKey(string sessionKey)
    {
        return _context.LoginFromSessionKey(sessionKey);
    }
    public User AutoLogin()
    {
        if (UserConfig.Read("encryptedSessionKey") != null)
        {
            string encryptedSessionKey = UserConfig.Read("encryptedSessionKey");
            byte[] encryptedSessionKeyBytes = Convert.FromBase64String(encryptedSessionKey);
            byte[] sessionKeyBytes = ProtectedData.Unprotect(encryptedSessionKeyBytes, null, DataProtectionScope.CurrentUser);
            string sessionKey = Encoding.UTF8.GetString(sessionKeyBytes);
            User user = _context.LoginFromSessionKey(sessionKey);
            if (user != null)
            {
                return user;
            }
        }
        else if(UserConfig.Read("encryptedPassword") != null && UserConfig.Read("encryptedUsername") != null){
            string encryptedUsername = UserConfig.Read("encryptedUsername");
            string encryptedPassword = UserConfig.Read("encryptedPassword");
            byte[] encryptedUsernameBytes = Convert.FromBase64String(encryptedUsername);
            byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
            byte[] usernameBytes = ProtectedData.Unprotect(encryptedUsernameBytes, null, DataProtectionScope.CurrentUser);
            byte[] passwordBytes = ProtectedData.Unprotect(encryptedPasswordBytes, null, DataProtectionScope.CurrentUser);
            string username = Encoding.UTF8.GetString(usernameBytes);
            string password = Encoding.UTF8.GetString(passwordBytes);
            User user = Login(username, password);
            if(user != null){
                return user;
            }
        }
        return null;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
