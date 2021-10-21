namespace WebApp.Notifications
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class Hubs : Hub
    {
        public async Task SendMessage(NotifyMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}