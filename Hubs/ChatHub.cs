using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using UserApp.Models;

namespace UserApp.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(Message message) => await Clients.All.SendAsync("receive message", message);
    }
}