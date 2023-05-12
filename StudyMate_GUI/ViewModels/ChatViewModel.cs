using System.Collections.Generic;
using StudyMate.Models;
using StudyMate.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using Avalonia.Collections;
namespace StudyMate.ViewModels;

class ChatViewModel : ViewModelBase
{
    public AvaloniaList<Conversation> Conversations { get; private set; }
    private Conversation _selectedConversation = null!;
    public Conversation SelectedConversation {
        get => _selectedConversation;
        set => this.RaiseAndSetIfChanged(ref _selectedConversation, value);
    }

    public AvaloniaList<Message> Messages { get; private set; }
    private User u = null!;


    public ChatViewModel(User u)
    {
        this.u = u;

    }
    public void GetConversations()
    {
        using(var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            Conversations = new AvaloniaList<Conversation>(chatServices.GetConversations(u.UserId));
        }
    }

    public void GetMessages()
    {
        using(var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            Messages = new AvaloniaList<Message>(chatServices.GetMessages(SelectedConversation.ConversationId));
        }
    }

    public void NewConversation(List<string> userId, string name)
    {

        using(var db = new StudyMateDbContext())
        {
            ChatServices chatServices = new ChatServices(db);
            chatServices.CreateConversation(userId,name);
        }
    }
}