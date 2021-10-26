using System.Collections.Generic;

namespace WhoIsMorePopular.WebApp.Messages
{
    public class ResultDetailDto
    {
        public string Word { get; set; }
        public string Provider { get; set; }
        public long Total { get; set; }
    }

    public class ProviderDetailDto
    {
        public string Provider { get; set; }
        public string Winner { get; set; }
    }

    public class SearchResponseDto
    {
        public List<ResultDetailDto> ResultDetail { get; set; }
        public List<ProviderDetailDto> ProviderDetailDto { get; set; }
        public string Winner { get; set; }
    }
}