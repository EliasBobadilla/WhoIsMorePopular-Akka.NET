using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WhoIsMorePopular.WebApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = BuildWebHost(args);
            await host.RunAsync();
        }

        private static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();
    }
}