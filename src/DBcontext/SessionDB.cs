namespace StudyMate;
public class SessionDB {
    public string SessionKey { get; set; }
    public string UserId { get; set; }
    public DateTime Expiration { get; set; }
    public SessionDB(string sessionKey, string userId, DateTime expiration) {
        SessionKey = sessionKey;
        UserId = userId;
        Expiration = expiration;
    }
}
 
