using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace MyWebJob
{
    public class Functions
    {
        public static async Task ProcessQueueMessage(
            [ServiceBusTrigger("wrong-implementation", Connection = "ServiceBusConnection")]
            Guid identifier, 
            TextWriter log)
        {
            var httpClient = new HttpClient();
            var baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
            httpClient.BaseAddress = new Uri(baseAddress);
            await httpClient.GetAsync($"api/Echo/{identifier}");
        }
    }
}
