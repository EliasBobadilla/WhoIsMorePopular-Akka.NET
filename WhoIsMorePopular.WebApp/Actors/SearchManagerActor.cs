using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Util.Internal;

namespace WhoIsMorePopular.WebApp.Actors
{
    public class SearchManagerActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var request = message as RequestMessage;
            SearchValue(request);
        }

        private static void SearchValue(RequestMessage message)
        {
            foreach (var provider in message.Providers)
            {
                var searchActor = Context.ActorOf(Props.Create(() => new SearchActor(provider)));
                var taskList = message.Words.Select(word => searchActor.Ask<string>(word)).ToArray();
                Task.WhenAll(taskList);
                foreach (var task in taskList)
                {
                    Console.WriteLine($"Response => {task.Result}");
                }
                
            }
            
            /*
             foreach (var word in message.Words)
                {
                    tasks.Add(Task.Run(() => { searchActor.Ask<string>(word); }));
                    // var resp = await searchActor.Ask<string>(word);
                    // Console.WriteLine($"Response => {resp}");
                }
             */
        }
    }
}