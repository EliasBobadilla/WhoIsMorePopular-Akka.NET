using System.Net;
using System.Threading.Tasks;
using WhoIsMorePopular.Common;
using WhoIsMorePopular.Common.Settings;

namespace WhoIsMorePopular.WebApp.Providers
{
    public class BingSearchProvider: ISearchProvider
    {
        private readonly BingSettings _settings;
        public string Name => "Microsoft Bing";

        public BingSearchProvider(BingSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        ///     Method to get the total result in Bing search
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <returns>Total search result</returns>
        public async Task<long> Search(string searchValue)
        {
            var url = BuildUri(searchValue, _settings.Url);
            var client = new WebClient();
            var response = await client.DownloadStringTaskAsync(url);
            return GetTotal(response);
        }

        #region private methods

        /// <summary>
        ///     Method to build the url for Web scraping
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <param name="url">Bing url</param>
        /// <returns>Formatted url</returns>
        private static string BuildUri(string searchValue, string url)
        {
            var value = searchValue.TextToQuery();
            return $"{url}?q={value}&isRef=1&showTw=1&form=GEODTAS&cc=US&setlang=en-US";
        }

        /// <summary>
        ///     Method to extract the total search result
        /// </summary>
        /// <param name="html">html text</param>
        /// <returns>Total search result</returns>
        private static long GetTotal(string html)
        {
            const string left = "<span class=\"sb_count\">";
            const string right = "</span>";
            var total = html.GetTextBetween(left, right).OnlyNumbers();
            return long.Parse(total);
        }
        
        #endregion
    }
}