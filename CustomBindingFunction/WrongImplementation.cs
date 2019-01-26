using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CustomBindingFunction
{
    public static class WrongImplementation
    {
        [FunctionName("WrongImplementation")]
        public static async Task Run(
            [ServiceBusTrigger("wrong-implementation", Connection = "ServiceBusConnection")]
            Guid identifier, 
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {identifier}");

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("BaseAddress", EnvironmentVariableTarget.Process));
            await httpClient.GetAsync($"api/Echo/{identifier}");
            
            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {identifier}");
        }
    }
}
