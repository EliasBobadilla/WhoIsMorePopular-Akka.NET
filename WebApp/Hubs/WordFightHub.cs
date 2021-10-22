using Microsoft.AspNetCore.SignalR;
using WebApp.Services;

namespace WebApp.Hubs
{
    public class WordFightHub : Hub
    {
        private readonly ISignalRProcessor _processor;

        public WordFightHub(ISignalRProcessor processor)
        {
            _processor = processor;
        }

        public void StartWordFight(string message)
        {
            _processor.Deliver(message);
        }
    }
}