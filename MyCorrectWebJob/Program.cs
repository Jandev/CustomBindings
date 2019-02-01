using Microsoft.Azure.WebJobs;

namespace MyCorrectWebJob
{
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }
            config.UseServiceBus();

            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
