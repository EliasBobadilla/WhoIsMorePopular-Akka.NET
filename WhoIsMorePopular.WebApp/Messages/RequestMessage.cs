using System.Collections.Generic;
using System.Linq;
using WhoIsMorePopular.Common;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class RequestMessage
    {
        public string[] Words { get; }
        public IEnumerable<ISearchProvider> Providers { get; }

        public RequestMessage(string message, IEnumerable<ISearchProvider> providers)
        {
            if (message.IsNullOrEmptyOrWhiteSpace() || !providers.Any()) return;

            Words = message.Split(",").Select(item => item.Trim()).ToArray();
            Providers = providers;
        }
    }
}