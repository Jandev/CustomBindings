using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CustomBindingFunction
{
    public static class FillQueue
    {
        [FunctionName("FillQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "fill\\{queueName}")] HttpRequest req,
            string queueName,
            ILogger log)
        {
            log.LogInformation($"Executing {nameof(FillQueue)} for {queueName}");

            log.LogInformation($"Executed {nameof(FillQueue)} for {queueName}");
            return new OkObjectResult($"The queue `{queueName}` is filled up.");
        }
    }
}
