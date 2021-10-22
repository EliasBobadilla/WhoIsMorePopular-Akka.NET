using System;
using Akka.Actor;
using WhoIsMorePopular.Common;

namespace WhoIsMorePopular.Server
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            var system = ActorSystem.Create("server-system", hocon);

            Console.WriteLine("Server started");

            Console.Read();
            system.Terminate().Wait();
        }
    }
}