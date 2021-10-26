using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using WhoIsMorePopular.WebApp.Actors;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IActorRef _searchManagerActor;
        private readonly IEnumerable<ISearchProvider> _providers;

        public SearchController(SearchManagerActorProvider searchManagerActor, IEnumerable<ISearchProvider> providers)
        {
            _searchManagerActor = searchManagerActor();
            _providers = providers;
        }

        [HttpGet("{values}")]
        public IActionResult Search(string values)
        {
            var message = new RequestMessage(values, _providers);
            if(!message.Words.Any()) return BadRequest("You must write one word at least");
            
            _searchManagerActor.Tell(message);
            return Ok("The fight has been started.");
        }
    }
}