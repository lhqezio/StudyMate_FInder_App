using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudyMate.Models;
public class Conversation
{
    [Key]
    public string ConversationId { get; set; }
    public string ConversationName { get; set; } = "";
    [InverseProperty("Conversations")]
    public List<User> Users { get; set; } = new();
    public Conversation(string conversationId, string conversationName)
    {
        ConversationId = conversationId;
        ConversationName = conversationName;
    }
}
