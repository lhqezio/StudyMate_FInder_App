/// <summary>
/// Represents a message with a sender, recipient, body, and timestamp.
/// </summary>
public class Message{
    public string Sender { get; set;}
    public string Body { get; private set; }
    public DateTime Timestamp { get; }
    public bool Edited { get; private set; }
    public bool MessageStatus{get;}

    /// <summary>
    /// Initializes a new instance of the Message class with the specified sender, recipient, and body.
    /// </summary>
    /// <param name="sender">The name of the sender of the message.</param>
    /// <param name="recipient">The name of the recipient of the message.</param>
    /// <param name="body">The body of the message.</param>
    /// <param name="timestamp">Timestamp of the message or the last edited.</param>
    public Message(string sender,string body,DateTime timestamp, bool edited,bool messageStatus)
    {
        Sender = sender;
        Body = body;
        Timestamp = timestamp;
        Edited = edited;
        MessageStatus=messageStatus;
    }

    //This methods allows the user to edit a messgae that was already sent. It wll
    // however show on the UI that message was edited. 
    public void EditMessage(string newMessage){
        this.Body=newMessage;
        this.Edited=true;
    }
    /// <summary>
    /// Returns a string that represents the current message, use for debugging purposes only.
    /// </summary>
    /// <returns>A string that represents the current message.</returns>
    public override string ToString()
    {
        return $"From: {Sender}\nTo: {Recipient}\nSent: {Timestamp}\n\n{Body}";
    }
}