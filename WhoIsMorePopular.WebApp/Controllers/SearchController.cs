using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using WhoIsMorePopular.Common;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IActorRef _searchManagerActor;

        public SearchController(SearchManagerActorProvider searchManagerActor)
        {
            _searchManagerActor = searchManagerActor();
        }

        [HttpGet("{list}")]
        public string Search(string list)
        {
            var response = $"Response => {list}";
            _searchManagerActor.Tell(list);
            return response;
        }
    }
}