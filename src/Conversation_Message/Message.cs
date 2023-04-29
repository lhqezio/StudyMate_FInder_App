using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudyMate;
public class Message{
    [ForeignKey("Users")]
    public string SenderID { get;set;}
    [ForeignKey("Conversations")]
    public string ConversationID { get;set;}
    [Key]
    public string MessageID { get; set; }
    public string Body { get; set; }
    public DateTime Timestamp { get; set;}
    public bool Sent{get;set;}

    public Message(string messageID,string body, string conversationID, string senderID,DateTime timestamp,bool sent)
    {
        SenderID = senderID;
        ConversationID = conversationID;
        Body = body;
        Timestamp = timestamp;
        Sent = sent;
        MessageID = messageID;
    }
}