using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WhoIsMorePopular.Common;
using WhoIsMorePopular.Common.Settings;

namespace WhoIsMorePopular.WebApp.Providers
{
    public class GoogleSearchProvider: ISearchProvider
    {
        private readonly GoogleSettings _settings;
        public string Name { get; } = "Google";

        public GoogleSearchProvider(GoogleSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        ///     Method to get the total result in Google search
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <returns>Total search result</returns>
        public async Task<long> Search(string searchValue)
        {
            var url = BuildUri(searchValue);
            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            // return GetTotal(response);
            return 100000;
        }

        /// <summary>
        ///     Method to extract the total search result value
        /// </summary>
        /// <param name="response">html text</param>
        /// <returns>Total search result</returns>
        public long GetTotal(string response)
        {
            dynamic json = JsonConvert.DeserializeObject(response);
            if (json == null) return 0;
            var queries = json.queries;
            var request = queries.request;
            var total = request[0].totalResults;
            return long.Parse(total.ToString());
        }

        #region Private methods

        /// <summary>
        ///     Method to build the url for custom search google api
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <returns>Formatted url</returns>
        private string BuildUri(string searchValue)
        {
            var value = searchValue.TextToQuery();
            return $"{_settings.Url}?key={_settings.ApiKey}&cx=017576662512468239146:omuauf_lfve&q={value}";
        }
        
        #endregion
    }
}