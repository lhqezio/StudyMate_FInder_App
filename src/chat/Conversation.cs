public class Conversation
{
    public string Name { get; }
    public int Id{get;}
    private List<Message>? messages;
    public List<Message>? Messages { get {
       if (messages.Count == 0)
       {
            // messages = ChatServices.GetMessages(Id);
            return messages;
       }
         else
        {
                return messages;
        }
    } }

    /// <summary>
    /// Initializes a new instance of the Conversation class with the specified name.
    /// </summary>
    /// <param name="name">The name of the conversation.</param>
    public Conversation(string name, int id)
    {
        Name = name;
        Id = id;
    }

    /// <summary>
    /// Returns a string that represents the current conversation, use for debugging purposes only.
    /// </summary>
    /// <returns>A string that represents the current conversation.</returns>
    public override string ToString()
    {
        return $"Conversation: {Name}";
        
    }
}