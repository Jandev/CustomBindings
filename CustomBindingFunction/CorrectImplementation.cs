using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CustomBindingFunction
{
    public static class CorrectImplementation
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        [FunctionName("CorrectImplementation")]
        public static async Task Run(
            [ServiceBusTrigger("correct-implementation-netstandard", Connection = "ServiceBusConnection")]
            Guid identifier,
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {identifier}");

            var baseAddress = Environment.GetEnvironmentVariable("BaseAddress", EnvironmentVariableTarget.Process);
            await HttpClient.GetAsync($"{baseAddress}api/Echo/{identifier}");

            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {identifier}");
        }

        [FunctionName("CorrectImplementationWithBinding")]
        public static void CorrectImplementationWithBinding(
            [ServiceBusTrigger("correct-implementation-netstandard", Connection = "ServiceBusConnection")]
            Guid identifier,
            [Http(Url = "%BaseAddress%api/Echo/{identifier}")] HttpModel httpModel,
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {identifier}");

            log.LogInformation($"Retrieved status: {httpModel.ResponseCode} Content: {httpModel.Response}");

            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {identifier}");
        }
    }
}
