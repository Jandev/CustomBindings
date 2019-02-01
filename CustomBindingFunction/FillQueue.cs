using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace CustomBindingFunction
{
    public static class FillQueue
    {
        [FunctionName("FillQueue")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "FillQueue/{name}")] 
            HttpRequest req,
            string name,
            [ServiceBus("wrong-implementation", Connection = "ServiceBusConnection", EntityType = EntityType.Queue)] 
            ICollector<Guid> wrongImplementationCollection,
            [ServiceBus("correct-implementation-netframework", Connection = "ServiceBusConnection", EntityType = EntityType.Queue)] 
            ICollector<Guid> correctNetFrameworkkImplementationCollection,
            [ServiceBus("correct-implementation-netcore", Connection = "ServiceBusConnection", EntityType = EntityType.Queue)] 
            ICollector<Guid> correctNetCoreImplementationCollection,
            ILogger log)
        {
            log.LogInformation($"Executing {nameof(FillQueue)} for queue {name}");

            const int maximum = 5000;
            switch (name.ToLowerInvariant())
            {
                case "wrong-implementation":
                    for (int i = 0; i < maximum; i++)
                    {
                        wrongImplementationCollection.Add(Guid.NewGuid());
                    }
                    break;
                case "correct-implementation-netframework":
                    for (int i = 0; i < maximum; i++)
                    {
                        correctNetFrameworkkImplementationCollection.Add(Guid.NewGuid());
                    }
                    break;
                case "correct-implementation-netcore":
                    for (int i = 0; i < maximum; i++)
                    {
                        correctNetCoreImplementationCollection.Add(Guid.NewGuid());
                    }
                    break;
            }

            log.LogInformation($"Executed {nameof(FillQueue)} for queue {name}");
            return new OkObjectResult($"The queue {name} is filled up.");
        }
    }
}
