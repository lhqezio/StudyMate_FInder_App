namespace StudyMate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SessionDB {
    [Key]
    public string SessionKey { get; set; }

    [ForeignKey("Users")]
    public string UserId { get; set; }
    public DateTime Expiration { get; set; }
    public SessionDB(string sessionKey, string userId, DateTime expiration) {
        SessionKey = sessionKey;
        UserId = userId;
        Expiration = expiration;
    }
}
 
