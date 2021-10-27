using System.Collections.Generic;
using Akka.Actor;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class SearchActor: ReceiveActor
    {
        private readonly ISearchProvider _provider;
        private readonly List<SearchResult> _responses = new(); 
        
        public SearchActor(ISearchProvider provider, IReadOnlyCollection<string> words)
        {
            _provider = provider;
            var wordCounter = words.Count;
            StartSearch(words);
            
            // receive from himself
            Receive<SearchResult>(response =>
            {
                wordCounter -= 1;
                _responses.Add(response);
                if (wordCounter is not 0) return;
                Context.Parent.Tell(_responses);
                Self.Tell(PoisonPill.Instance);
            });
        }
        
        private void StartSearch(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                _provider.Search(word).ContinueWith(res => new SearchResult
                {
                    Word = word,
                    Total = res.Result,
                    ProviderName = _provider.Name
                }).PipeTo(Self);
            }
        }
    }
    
    public record SearchResult
    {
        public string Word { get; init; }
        public long Total { get; init; }
        public string ProviderName { get; init; }
    }
}