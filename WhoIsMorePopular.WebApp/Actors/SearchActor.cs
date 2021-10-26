using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class SearchActor : ReceiveActor
    {
        private readonly ISearchProvider _provider;
        
        public SearchActor(ISearchProvider provider){
            _provider = provider;
            ReceiveAsync<string>(async message =>
            {
                var response = await StartSearch(message);
                Sender.Tell(response);
            });
        }
        
        private async Task<string> StartSearch(string word)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return $"{word} -> {_provider.Name}";
        }
    }
}