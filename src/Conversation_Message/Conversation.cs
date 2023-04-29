using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudyMate;
public class Conversation
{
    [Key]
    public string ConversationId { get; set; }
    public string ConversationName { get; set; } = "";
    public List<User> Users { get; set; } = new();
    public Conversation(string conversationId, string conversationName)
    {
        ConversationId = conversationId;
        ConversationName = conversationName;
    }
}
