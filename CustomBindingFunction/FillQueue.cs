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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] 
            HttpRequest req,
            [ServiceBus("wrong-implementation", Connection = "ServiceBusConnection", EntityType = EntityType.Queue)] 
            ICollector<Guid> wrongImplementationCollection,
            [ServiceBus("correct-implementation-netframework", Connection = "ServiceBusConnection", EntityType = EntityType.Queue)] 
            ICollector<Guid> correctNetFrameworkkImplementationCollection,
            [ServiceBus("correct-implementation-netcore", Connection = "ServiceBusConnection", EntityType = EntityType.Queue)] 
            ICollector<Guid> correctNetCoreImplementationCollection,
            ILogger log)
        {
            log.LogInformation($"Executing {nameof(FillQueue)}");

            for (int i = 0; i < 1000; i++)
            {
                wrongImplementationCollection.Add(Guid.NewGuid());
                correctNetFrameworkkImplementationCollection.Add(Guid.NewGuid());
                correctNetCoreImplementationCollection.Add(Guid.NewGuid());
            }

            log.LogInformation($"Executed {nameof(FillQueue)}");
            return new OkObjectResult($"The queues are filled up.");
        }
    }
}
