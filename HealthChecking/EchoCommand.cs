using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthChecking
{
    public static class EchoCommand
    {
        [FunctionName("EchoCommand")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", "post", Route = null)] 
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Executing {nameof(EchoCommand)}.");
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<EchoModel>(requestBody);
            var identifier = data.Identifier;

            log.LogInformation($"Executed {nameof(EchoCommand)} with identifier {identifier}.");

            return new OkObjectResult($"Received identifier {identifier}");
        }

        private class EchoModel
        {
            public string Identifier { get; set; }
        }
    }
}
