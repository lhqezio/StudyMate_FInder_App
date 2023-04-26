namespace StudyMate;
class ProfileServices
{
    private StudyMateDbContext _context = null!;
    private static ProfileServices? _instance;
    public static ProfileServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new ProfileServices(context);
        }
        return _instance;
    }
    private ProfileServices(StudyMateDbContext context)
    {
        _context = context;
    }

    public virtual void AddEvent(Profile profile, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            _context.Profiles!.Add(profile);
            _context.SaveChanges();
        }
    }
}
