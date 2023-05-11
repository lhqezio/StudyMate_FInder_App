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

    public ChatViewModel(StudyMateDbContext context)
    {
        _context = context;
    }
    public void GetConversations(User u)
    {
        ChatServices chatServices = new ChatServices(_context);
        Conversations = chatServices.GetConversations(u.UserId); 
    }

    public void GetMessages()
    {
        ChatServices chatServices = new ChatServices(_context);
        List<Message> messages = chatServices.GetMessages(SelectedConversation.ConversationId);
    }
}