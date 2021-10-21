using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Notifications;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IHubContext<Hubs> _hubContext;

        public FightController(IHubContext<Hubs> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("{values}")]
        public string[] Get(string values)
        {
            string[] words = {"Hello", "and", "welcome", "to", "my", "world!"};
            Task.Run(() => SendToSocket());
            return words;
        }

        public void SendToSocket()
        {
            System.Threading.Thread.Sleep(6000);
            var message = new NotifyMessage
            {
                Message = "Burroooooooo"
            };
            _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}