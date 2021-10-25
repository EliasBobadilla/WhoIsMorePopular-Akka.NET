using System;
using Akka.Actor;
using WhoIsMorePopular.Common;

namespace WhoIsMorePopular.Server
{
    internal static class Program
    {
        private static void Main()
        {
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            var system = ActorSystem.Create("server-system", hocon);
            Console.WriteLine("Akka.NET Server started");
            Console.Read();
            system.Terminate().Wait();
        }
    }
}