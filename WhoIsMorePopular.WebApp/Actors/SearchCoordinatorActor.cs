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
        private readonly List<List<SearchResult>> _responses = new();

        public SearchCoordinatorActor()
        {
            // receive from parent
            Receive<RequestMessage>(message =>
            {
                _parentActor = Sender;
                _providerCounter = message.Providers.Count();

                foreach (var provider in message.Providers)
                    Context.ActorOf(Props.Create(() => new SearchActor(provider, message.Words)));
            });

            // receive from child
            Receive<List<SearchResult>>(message =>
            {
                _providerCounter -= 1;
                _responses.Add(message);
                if (_providerCounter is 0) _parentActor.Tell(BuildResponse(_responses));
            });
        }

        private static SearchResponseDto BuildResponse(IEnumerable<IReadOnlyCollection<SearchResult>> responses)
        {
            var detail = GetDetail(responses);
            var providerDetail = GetProviderDetails(detail);

            return new SearchResponseDto
            {
                ResultDetail = detail,
                ProviderDetailDto = providerDetail,
                Winner = GetWinner(detail)
            };
        }

        private static List<ResultDetailDto> GetDetail(IEnumerable<IReadOnlyCollection<SearchResult>> responses)
        {
            return responses.SelectMany(item => item)
                .Select(x => new ResultDetailDto
                {
                    Word = x.Word,
                    Provider = x.ProviderName,
                    Total = x.Total
                }).ToList();
        }

        private static List<ProviderDetailDto> GetProviderDetails(IReadOnlyCollection<ResultDetailDto> details)
        {
            var providers = details.Select(x => x.Provider).Distinct().ToList();

            return (from provider in providers
                let maxTotal = details.Where(x => x.Provider.Equals(provider)).Max(x => x.Total)
                let item = details.FirstOrDefault(x => x.Total.Equals(maxTotal))
                select new ProviderDetailDto {Provider = provider, Winner = item.Word}).ToList();
        }

        private static string GetWinner(IReadOnlyCollection<ResultDetailDto> details)
        {
            var maxTotal = details.Max(x => x.Total);
            var winner = details.FirstOrDefault(x => x.Total.Equals(maxTotal));
            return winner?.Word;
        }
    }
}