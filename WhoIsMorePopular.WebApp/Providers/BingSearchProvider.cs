using System.Net;
using System.Threading.Tasks;
using WhoIsMorePopular.Common;
using WhoIsMorePopular.Common.Settings;

namespace WhoIsMorePopular.WebApp.Providers
{
    public class BingSearchProvider: ISearchProvider
    {
        private readonly BingSettings _settings;
        public string Name { get; } = "Microsoft Bing";

        public BingSearchProvider(BingSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        ///     Method to get the total result in Bing search
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <returns>Total search result</returns>
        public async Task<string> Search(string searchValue)
        {
            var url = BuildUri(searchValue);
            var client = new WebClient();
            return await client.DownloadStringTaskAsync(url);
        }

        /// <summary>
        ///     Method to extract the total search result
        /// </summary>
        /// <param name="html">html text</param>
        /// <returns>Total search result</returns>
        public long GetTotal(string html)
        {
            const string left = "<span class=\"sb_count\">";
            const string right = "</span>";
            var total = html.GetTextBetween(left, right).OnlyNumbers();
            return long.Parse(total);
        }

        #region private methods

        /// <summary>
        ///     Method to build the url for Web scraping
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <returns>Formatted url</returns>
        private string BuildUri(string searchValue)
        {
            var value = searchValue.TextToQuery();
            return
                $"{_settings.Url}?q={value}&form=QBLH&sp=-1&pq={value}&sc=8-{value.Length}&qs=n&sk=&cvid=5BBCEE4978DC444C9B29633585E809DA";
        }

        #endregion
    }
}