/// <summary>
/// Represents a message with a sender, recipient, body, and timestamp.
/// </summary>
public class Message
{
    public string Sender { get; }
    public string Recipient { get; }
    public string Body { get; }
    public DateTime Timestamp { get; }
    public bool Edited { get; }

    /// <summary>
    /// Initializes a new instance of the Message class with the specified sender, recipient, and body.
    /// </summary>
    /// <param name="sender">The name of the sender of the message.</param>
    /// <param name="recipient">The name of the recipient of the message.</param>
    /// <param name="body">The body of the message.</param>
    /// <param name="timestamp">Timestamp of the message or the last edited.</param>
    public Message(string sender, string recipient, string body,DateTime timestamp, bool edited)
    {
        Sender = sender;
        Recipient = recipient;
        Body = body;
        Timestamp = timestamp;
        Edited = edited;
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