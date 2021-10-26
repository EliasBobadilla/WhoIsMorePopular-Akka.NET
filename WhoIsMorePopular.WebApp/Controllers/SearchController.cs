using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using WhoIsMorePopular.WebApp.Messages;
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
        public async Task<IActionResult> Search(string values)
        {
            var message = new RequestMessage(values, _providers);
            if(!message.Words.Any()) return BadRequest("You must write one word at least");

            var response = await _searchManagerActor.Ask<SearchResponseDto>(message);
            return Ok(response);
        }
    }
}