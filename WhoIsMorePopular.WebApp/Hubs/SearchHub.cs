using Microsoft.AspNet.SignalR;

namespace WhoIsMorePopular.WebApp.Hubs
{
    public class SearchHub: Hub
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