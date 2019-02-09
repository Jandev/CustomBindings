using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpBinding;
using HttpBinding.HttpCommand;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CustomBindingFunction
{
    /// <summary>
    /// Correct implementation of an Azure Function using an <see cref="HttpClient"/>.
    /// When testing, do make sure you only have 1 active Azure Function. Even if you just
    /// comment out the <see cref="FunctionNameAttribute"/>, the <see cref="ServiceBusTriggerAttribute"/>
    /// is still activated.
    /// </summary>
    public static class CorrectImplementation
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        [FunctionName("CorrectImplementation")]
        public static async Task Run(
            [ServiceBusTrigger("correct-implementation-netstandard", Connection = "ServiceBusConnection")]
            IncomingNetStandardModel netStandardModel,
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {netStandardModel.Identifier}");

            var baseAddress = Environment.GetEnvironmentVariable("BaseAddress", EnvironmentVariableTarget.Process);
            await HttpClient.GetAsync($"{baseAddress}api/Echo/{netStandardModel.Identifier}");

            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {netStandardModel.Identifier}");
        }

        [FunctionName("CorrectImplementationWithBinding")]
        public static void CorrectImplementationWithBinding(
            [ServiceBusTrigger("correct-implementation-netstandard", Connection = "ServiceBusConnection")]
            IncomingNetStandardModel netStandardModel,
            [Http(Url = "%BaseAddress%api/Echo/{Identifier}")] 
            HttpModel httpModel,
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {netStandardModel.Identifier}");

            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {netStandardModel.Identifier}");
        }

        [FunctionName("CorrectImplementationWithPostBinding")]
        public static void CorrectImplementationWithPostBinding(
            [ServiceBusTrigger("correct-implementation-netstandard", Connection = "ServiceBusConnection")]
            Guid identifier,
            [HttpCommand(CommandUrl = "%BaseAddress%api/EchoCommand", MediaType = "application/json", HttpMethod = "POST")]
            IAsyncCollector<HttpCommand> httpPostCommandCollector,
            ILogger log)
        {
            log.LogInformation($"Executing ServiceBus queue trigger. Processing message: {identifier}");

            var model = new ModelToSend
            {
                Identifier = identifier.ToString("D")
            };
            httpPostCommandCollector.AddAsync(new HttpCommand(JsonConvert.SerializeObject(model)));

            log.LogInformation($"Executed ServiceBus queue trigger. Processing message: {identifier}");
        }

        private class ModelToSend
        {
            public string Identifier { get; set; }
        }
    }
}
