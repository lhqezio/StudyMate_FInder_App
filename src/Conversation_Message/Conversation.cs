namespace StudyMate;
public class Conversation
{
    public string Name { 
        get;set;
    }
    private int __id;
    private List<int> __messages_id;
    private List<Message>? __messages;
    private DateTime LatestDate{get;set;}
    public List<Message>? Messages { get {
        //__messages = ChatServices.GetMessages(__messages_id);
        //return __messages;
        return new List<Message>();
    }}

    /// <summary>
    /// Initializes a new instance of the Conversation class with the specified name.
    /// </summary>
    /// <param name="name">The name of the conversation.</param>
    public Conversation(string name, int id,List<int>__messages_id)
    {
        Name = name;
        __id = id;
        this.__messages_id=__messages_id;
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
