using System.Collections.Generic;
using Akka.Actor;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class TempActor: ReceiveActor
    {
        private readonly ISearchProvider _provider;
        private readonly string[] _words;
        private int _wordCounter;
        private List<SearchResponse> _responses = new List<SearchResponse>(); 
        
        public TempActor(ISearchProvider provider, string[] words)
        {
            _provider = provider;
            _words = words;
            _wordCounter = words.Length;
            StartSearch(words);
            Receive<SearchResponse>(response =>
            { 
                _wordCounter -= 1;
                _responses.Add(response);
                if (_wordCounter is 0)
                {
                    Context.Parent.Tell(_responses);
                    Self.Tell(PoisonPill.Instance);
                }
            });
        }
        
        private void StartSearch(string[] words)
        {
            foreach (var word in words)
            {
                _provider.Search(word).ContinueWith(res => new SearchResponse(word, res.Result, _provider.Name)).PipeTo(Self);
            }
        }
        
    }
    
    public class SearchResponse
    {
        public string Word { get;  }
        public long Total { get; }
        
        public string ProviderName { get; }

        public SearchResponse(string word, long total, string providerName)
        {
            Word = word;
            Total = total;
            ProviderName = providerName;
        }
    }
}