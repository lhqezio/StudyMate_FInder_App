using System.Collections.Generic;
using StudyMate.Models;
using StudyMate.Services;
using ReactiveUI;

namespace StudyMate.ViewModels;

class ChatViewModel : ViewModelBase
{
    private StudyMateDbContext _context;
    public List<Conversation> Conversations { get; private set; }
    private Conversation _selectedConversation = null!;
    public Conversation SelectedConversation {
        get => _selectedConversation;
        set => this.RaiseAndSetIfChanged(ref _selectedConversation, value);
    }

    public List<Message> Messages { get; private set; }
    private User u = null!;

    
    public ChatViewModel(StudyMateDbContext context,User u)
    {
        _context = context;
        this.u = u;

    }
    public void GetConversations()
    {
        ChatServices chatServices = new ChatServices(_context);
        Conversations = chatServices.GetConversations(u.UserId); 
    }

    public void GetMessages()
    {
        ChatServices chatServices = new ChatServices(_context);
        List<Message> messages = chatServices.GetMessages(SelectedConversation.ConversationId);
    }

    public void NewConversation(List<string> userId)
    {

        ChatServices chatServices = new ChatServices(_context);
        chatServices.CreateConversation(userId, "New Conversation");
    }
}