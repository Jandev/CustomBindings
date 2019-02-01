using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace MyCorrectWebJob
{
    public class Functions
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public static async Task ProcessQueueMessage(
            [ServiceBusTrigger("correct-implementation-netframework", Connection = "ServiceBusConnection")]
            Guid identifier,
            TextWriter log)
        {
            var baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
            var response = await HttpClient.GetAsync($"{baseAddress}api/Echo/{identifier}");
            log.WriteLine(response.ToString());
        }
    }
}