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
    public AvaloniaList<Conversation> Conversations { get; private set; }

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
    private Conversation _selectedConversation;
    public ReactiveCommand<Unit, Unit> NewConvo { get; }
    public Conversation SelectedConversation
    {
        get => _selectedConversation;
        set => this.RaiseAndSetIfChanged(ref _selectedConversation, value);
    }

    public AvaloniaList<Message> Messages { get; private set; }
    private User u = null!;


    public ChatViewModel(User u)
    {
        this.u = u;
        NewConvo = ReactiveCommand.Create(() => { NewConversation(); });
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
        using (var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            List<string> participants = Participants.Split(',').ToList();
            participants.Add(u.UserId);
            chatServices.CreateConversation(participants, ConversationName);
        }
    }
}