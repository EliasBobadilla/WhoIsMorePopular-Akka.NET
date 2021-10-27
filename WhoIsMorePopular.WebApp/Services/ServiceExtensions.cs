using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhoIsMorePopular.Common.Settings;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services,  IConfiguration configuration)
        {
            var googleSettings = configuration.GetSection("GoogleSettings").Get<GoogleSettings>();
            var bingSettings = configuration.GetSection("BingSettings").Get<BingSettings>();
            
            services.AddSingleton(googleSettings);
            services.AddSingleton(bingSettings);
            services.AddScoped<ISearchProvider, BingSearchProvider>();
            // services.AddScoped<ISearchProvider, GoogleSearchProvider>();
        }
    }
}