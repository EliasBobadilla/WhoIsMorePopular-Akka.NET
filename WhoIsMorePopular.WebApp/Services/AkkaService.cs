using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using WhoIsMorePopular.Common;
using WhoIsMorePopular.WebApp.Actors;
using WhoIsMorePopular.WebApp.Providers;

namespace WhoIsMorePopular.WebApp.Services
{
    public static class AkkaService
    {
        public static void AddAkkaService(this IServiceCollection services)
        {
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            services.AddSingleton(_ => ActorSystem.Create("search-actor-system", hocon)); // ActorSystem
            
            services.AddSingleton<SearchManagerActorProvider>(provider =>
            {
                var actorSystem = provider.GetService<ActorSystem>();
                if (actorSystem is null) return null;
                return () => actorSystem.ActorOf(Props.Create(() => new SearchManagerActor()));
            });
        }
    }
}