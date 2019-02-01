using Microsoft.Azure.WebJobs;

namespace MyWebJob
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
