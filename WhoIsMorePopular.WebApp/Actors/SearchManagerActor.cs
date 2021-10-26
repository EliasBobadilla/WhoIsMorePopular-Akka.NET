using Akka.Actor;
using WhoIsMorePopular.WebApp.Messages;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class SearchManagerActor : ReceiveActor
    {
        /** Actor handler for each request **/
        public SearchManagerActor()
        {
            Receive<RequestMessage>(request =>
            {
                Context.ActorOf(Props.Create(() => new SearchCoordinatorActor())).Forward(request);
            });
        }
    }
}