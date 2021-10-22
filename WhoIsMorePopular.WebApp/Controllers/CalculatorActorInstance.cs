using System.Threading.Tasks;
using Akka.Actor;
using WhoIsMorePopular.Common;

namespace WhoIsMorePopular.WebApp.Controllers
{
    public class CalculatorActorInstance : ICalculatorActorInstance
    {
        private readonly IActorRef _actor;

        public CalculatorActorInstance(ActorSystem actorSystem)
        {
            _actor = actorSystem.ActorOf(Props.Create<CalculatorActor>(), "calculator");
        }

        public async Task<AnswerMessage> Sum(AddMessage message)
        {
            return await _actor.Ask<AnswerMessage>(message);
        }
    }

    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }
}