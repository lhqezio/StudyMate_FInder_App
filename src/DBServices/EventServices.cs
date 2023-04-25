namespace StudyMate;
class EventServices
{
    private StudyMateDbContext _context = null!;
    private static EventServices? _instance;
    public static EventServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null)
        {
            _instance = new EventServices(context);
        }
        return _instance;
    }
    private EventServices(StudyMateDbContext context)
    {
        _context = context;
    }
    public virtual void AddEvent(EventCalendar e, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            _context.Events!.Add(e);
            _context.SaveChanges();
        }
    }

    //DeleteEvent Method => Delete event to the list of events
    public virtual void DeleteEvent(EventCalendar e, User u)
    {
        if (_context.ValidateSessionKey(u.__session_key))
        {
            _context.Events!.Remove(e);
            _context.SaveChanges();
        }
    }
}
