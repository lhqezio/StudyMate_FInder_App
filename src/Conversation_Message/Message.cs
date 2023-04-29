using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudyMate;
public class Message{
    [ForeignKey("User")]
    public string SenderID { get;}
    [ForeignKey("Conversation")]
    public string ConversationID { get;set;}
    [Key]
    public string MessageID { get; set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; set}
    public bool Sent{get;set;}

    public Message(string body, string conversationID, string senderID,DateTime timestamp,bool sent)
    {
        SenderID = senderID;
        ConversationID = conversationID;
        Body = body;
        Timestamp = timestamp;
        Sent = sent;
    }
}