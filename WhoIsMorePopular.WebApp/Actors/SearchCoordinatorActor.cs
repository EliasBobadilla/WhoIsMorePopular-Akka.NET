using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using WhoIsMorePopular.WebApp.Messages;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class SearchCoordinatorActor : ReceiveActor
    {
        /** Number of providers in this request **/
        private int _providerCounter;
        
        /** Manager actor context **/
        private IActorRef _parentActor;
        
        /** Responses from children */
        private readonly List<List<SearchResponse>> _responses = new();
        
        public SearchCoordinatorActor()
        {
            // receive from parent
            Receive<RequestMessage>(message =>
            {
                _parentActor = Sender;
                _providerCounter = message.Providers.Count();
                _ = message.Providers.Select(provider => Context.ActorOf(Props.Create(()=> new TempActor(provider, message.Words))));
            });

            // receive from child
            Receive<List<SearchResponse>>(message =>
            {
                _providerCounter -= 1;
                _responses.Add(message);
                if (_providerCounter is 0) _parentActor.Tell(BuildResponse(_responses));
            });
        }

        private static SearchResponseDto BuildResponse(IEnumerable<IEnumerable<SearchResponse>> responses)
        {
            var flattened = responses.SelectMany(item => item);
            var grouped = flattened.GroupBy(x => x.ProviderName);
            return new SearchResponseDto();
        }
        
    }
}