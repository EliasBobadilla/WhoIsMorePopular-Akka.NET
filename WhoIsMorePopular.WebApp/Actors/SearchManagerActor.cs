using System;
using Akka.Actor;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class SearchManagerActor: UntypedActor
    {
        public SearchManagerActor()
        {
            Console.WriteLine("CalculatorActor constructor");
        }
        
        
        protected override void OnReceive(object message)
        {
            var msg = message as string;
            
            switch (msg)
            {
                case "uno":
                {
                    Console.WriteLine("LLEGO UN UNO");
                    break;
                }
                case "dos":
                {
                    Console.WriteLine("LLEGO UN DOS");
                    break;
                }
                default:
                    Console.WriteLine("LLEGO NADA");
                    break;
            }
        }
    }
}