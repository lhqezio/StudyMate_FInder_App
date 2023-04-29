namespace StudyMate;
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
    public Conversation CreateConversation(List<User> users)
    {
        var conversation = new Conversation(Guid.NewGuid().ToString(), users);
        _context.Conversations.Add(conversation);
        _context.SaveChanges();
        return conversation;
    }
    public void AddUserToConversation(string conversationID, string userID)
    {
        var conversation = _context.Conversations.Find(conversationID);
        var user = _context.Users.Find(userID);
        conversation.Users.Add(user);
        _context.SaveChanges();
    }
    public void RemoveUserFromConversation(string conversationID, string userID)
    {
        var conversation = _context.Conversations.Find(conversationID);
        var user = _context.Users.Find(userID);
        conversation.Users.Remove(user);
        _context.SaveChanges();
    }
    public void DeleteConversation(string conversationID)
    {
        var conversation = _context.Conversations.Find(conversationID);
        _context.Conversations.Remove(conversation);
        _context.SaveChanges();
    }
    public void SendMessage(string body, string conversationID, string senderID)
    {
        var message = new Message(body, conversationID, senderID, DateTime.Now, false);
        _context.Messages.Add(message);
        _context.SaveChanges();
    }
    public List<Message> GetMessages(string conversationID)
    {
        List<Message> messages = _context.Messages.Where(m => m.ConversationID == conversationID).ToList();
        foreach (var message in messages)
        {
            message.Sent = true;
        }
        _context.SaveChanges();
        return messages;
    }
    public List<Conversation> GetConversations(string userID)
    {
        List<Conversation> conversations = _context.Conversations.Where(c => c.Users.Any(u => u.UserId == userID)).ToList();
        return conversations;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}