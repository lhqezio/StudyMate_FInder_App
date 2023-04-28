namespace StudyMate;
public class Message{
    public string Sender { get;}
    public string Body { get; private set; }
    public string Timestamp { get; }
    public bool Edited { get; private set; }
    public bool MessageStatus{get; private set;}

    /// <summary>
    /// Initializes a new instance of the Message class with the specified sender, recipient, and body.
    /// </summary>
    /// <param name="sender">The name of the sender of the message.</param>
    /// <param name="body">The body of the message.</param>
    /// <param name="timestamp">Timestamp of the message or the last edited.</param>
    /// <param name="Edited">To check if the message is edited</param>
    /// <param name="MessageStatus">To check if the message has been seen</param>
    public Message(string sender,string body)
    {
        Sender = sender;
        Body = body;
        Timestamp = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        Edited = false;
        MessageStatus=false;
    }

    //This methods allows the user to edit a messgae that was already sent. It wll
    // however show on the UI that message was edited. 
    public void EditMessage(string newMessage){
        this.Body=newMessage;
        this.Edited=true;
    }

    public void MessageSeen(){
        this.MessageStatus=true;
    }
    /// <summary>
    /// Returns a string that represents the current message, use for debugging purposes only.
    /// </summary>
    /// <returns>A string that represents the current message.</returns>
    public override string ToString()
    {
        return $"From: {Sender}\n\nSent: {Timestamp}\n\n{Body}";
    }
}
