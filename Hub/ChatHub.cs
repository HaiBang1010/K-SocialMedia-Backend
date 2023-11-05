using ChatChit.Data;
using Microsoft.AspNetCore.SignalR;

namespace ChatChit.Hub
{
    public class ChatHub
    {
        private readonly ChatChitContex _context;
        public ChatHub(ChatChitContex context)
        {
            _context = context;
        }
    }
}
