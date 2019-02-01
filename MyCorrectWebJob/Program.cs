using System.Net.Http;
using Microsoft.Azure.WebJobs;

namespace MyCorrectWebJob
{
    class Program
    {
        internal static HttpClient HttpClient;
        static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            config.UseServiceBus();

        
            if (HttpClient == null)
            {
                HttpClient = new HttpClient();
            }
            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
