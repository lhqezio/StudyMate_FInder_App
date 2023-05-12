using System.Collections.Generic;
using StudyMate.Models;
using StudyMate.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using Avalonia.Collections;
using System.Reactive;
using System.Linq;

namespace StudyMate.ViewModels;

class ChatViewModel : ViewModelBase
{
    private AvaloniaList<Conversation> _conversations;
    public AvaloniaList<Conversation> Conversations { get => _conversations; 
        set {
            this.RaiseAndSetIfChanged(ref _conversations, value);
        }
     }

    public string _conversationName;
    public string _participants;
    public string ConversationName
    {
        get => _conversationName;
        private set => this.RaiseAndSetIfChanged(ref _conversationName, value);
    }
    public string Participants
    {
        get => _participants;
        private set => this.RaiseAndSetIfChanged(ref _participants, value);
    }
    private string _message;
    public string Message
    {
        get => _message;
        private set => this.RaiseAndSetIfChanged(ref _message, value);
    }
    private Conversation _selectedConversation;
    public ReactiveCommand<Unit, Unit> NewConvo { get; }
    public ReactiveCommand<Unit, Unit> SendMessage { get; }
    public ReactiveCommand<Unit, Unit> DeleteConversation { get; }  
    public Conversation SelectedConversation
    {
        get => _selectedConversation;
        set {
            this.RaiseAndSetIfChanged(ref _selectedConversation, value);
            GetMessages();
        }
    }
    private AvaloniaList<Message> _messages;
    public AvaloniaList<Message> Messages { get => _messages; 
        set {
            this.RaiseAndSetIfChanged(ref _messages, value);
        }}
    private User u = null!;


    public ChatViewModel(User u)
    {
        this.u = u;
        GetConversations();
        NewConvo = ReactiveCommand.Create(() => { NewConversation(); });
        SendMessage = ReactiveCommand.Create(() => { MessageSend(); });
        DeleteConversation = ReactiveCommand.Create(() => { ConversationDelete(); });
    }
    public void GetConversations()
    {
        using (var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            Conversations = new AvaloniaList<Conversation>(chatServices.GetConversations(u.UserId));
        }
    }

    public void GetMessages()
    {
        using (var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            Messages = new AvaloniaList<Message>(chatServices.GetMessages(SelectedConversation.ConversationId));
        }
    }

    public void NewConversation()
    {
        if(ConversationName == null || Participants == null || Participants == this.u.Username)
        {
            return;
        }
            
        using (var db = new StudyMateDbContext())
        {  
            ChatServices chatServices = new ChatServices(db);
            List<string> participants = Participants.Split(',').ToList();
            participants.Add(u.Username);
            chatServices.CreateConversation(participants, ConversationName);
        }
        GetConversations();
    }
    public void MessageSend()
    {
        if(Message == null || SelectedConversation == null)
        {
            return;
        }
        System.Console.WriteLine("Sending message");
        using (var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            chatServices.SendMessage(Message, SelectedConversation.ConversationId, u.UserId);
        }
        GetMessages();
    }
    public void ConversationDelete()
    {
        if(SelectedConversation == null)
        {
            return;
        }
        using (var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            chatServices.DeleteConversation(SelectedConversation.ConversationId);
        }
        GetConversations();
    }
}