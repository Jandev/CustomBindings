using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace HealthChecking
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Echo/{identifier}")]
            HttpRequest req,
            string identifier,
            ILogger log)
        {
            log.LogInformation($"Executing {nameof(Echo)}");


            log.LogInformation($"Executed {nameof(Echo)}");
            return (ActionResult) new OkObjectResult($"Echoing, {identifier}");
        }
    }
}
