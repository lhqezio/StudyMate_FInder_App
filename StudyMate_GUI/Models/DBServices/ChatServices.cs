using System;
using System.Collections.Generic;
using System.Linq;
using StudyMate.Models;
namespace StudyMate.Services;
public class ChatServices {
    private StudyMateDbContext _context = null!;
    private static ChatServices? _instance;
    public static ChatServices getInstance(StudyMateDbContext context)
    {
        if (_instance is null||_instance._context!=context)
        {
            _instance = new ChatServices(context);
        }
        return _instance;
    }
    public ChatServices(StudyMateDbContext context)
    {
        _context = context;
    }
    public Conversation CreateConversation(List<string> usernames,string name)
    {
        var conversation = new Conversation(Guid.NewGuid().ToString(), name);
        foreach (var username in usernames)
        {
            var user = _context.StudyMate_Users?.SingleOrDefault(u => u.Username == username);
            if(user!=null) {
                conversation.Users.Add(user);
                user.Conversations.Add(conversation);
            }
        }
        _context.StudyMate_Conversations?.Add(conversation);
        _context.SaveChanges();
        return conversation;
    }
    public void AddUserToConversation(string conversationID, string username)
    {
        var conversation = _context.StudyMate_Conversations?.Find(conversationID);
        var user = _context.StudyMate_Users!.FirstOrDefault(u => u.Username == username);
        conversation!.Users.Add(user!);
        user!.Conversations.Add(conversation);
        _context.SaveChanges();
    }
    public void RemoveUserFromConversation(string conversationID, string username)
    {
        var conversation = _context.StudyMate_Conversations!.Find(conversationID);
        var user = _context.StudyMate_Users!.FirstOrDefault(u => u.Username == username);
        conversation!.Users.Remove(user!);
        user!.Conversations.Remove(conversation);
        _context.SaveChanges();
    }
    public void DeleteConversation(string conversationID)
    {
        var conversation = _context.StudyMate_Conversations!.Find(conversationID);
        _context.StudyMate_Conversations.Remove(conversation!);
        _context.SaveChanges();
    }
    public void SendMessage(string body, string conversationID, string senderID)
    {
        var message = new Message(Guid.NewGuid().ToString(),body, conversationID, senderID, DateTime.Now, false);
        _context.StudyMate_Messages!.Add(message);
        _context.SaveChanges();
    }
    public List<Message> GetMessages(string conversationID)
    {
        List<Message> messages = _context.StudyMate_Messages!.Where(m => m.ConversationID == conversationID).ToList();
        foreach (var message in messages)
        {
            message.Sent = true;
        }
        _context.SaveChanges();
        return messages;
    }
    public List<Conversation> GetConversations(string Id)
    {
        List<Conversation> conversations = _context.StudyMate_Conversations!.Where(c => c.Users.Any(u => u.UserId == Id)).ToList();
        return conversations;
    }
}
