using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CustomBindingFunction
{
    public static class CorrectImplementation
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        [FunctionName("CorrectImplementation")]
        public static async Task Run([ServiceBusTrigger("correct-implementation-netcore", Connection = "ServiceBusConnection")]
            Guid identifier,
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {identifier}");

            var baseAddress = Environment.GetEnvironmentVariable("BaseAddress", EnvironmentVariableTarget.Process);
            await HttpClient.GetAsync($"{baseAddress}api/Echo/{identifier}");

            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {identifier}");
        }
    }
}
