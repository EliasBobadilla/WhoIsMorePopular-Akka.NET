using System.Collections.Generic;

namespace WhoIsMorePopular.WebApp.Messages
{
    public record ResultDetailDto
    {
        public string Word { get; init; }
        public string Provider { get; init; }
        public long Total { get; init; }
    }

    public record ProviderDetailDto
    {
        public string Provider { get; init; }
        public string Winner { get; init; }
    }

    public record SearchResponseDto
    {
        public List<ResultDetailDto> ResultDetail { get; init; }
        public List<ProviderDetailDto> ProviderDetail { get; init; }
        public string Winner { get; set; }
    }
}