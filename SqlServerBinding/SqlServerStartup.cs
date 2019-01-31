using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using SqlServerBinding;

[assembly: WebJobsStartup(typeof(SqlServerStartup))]
namespace SqlServerBinding
{
    public class SqlServerStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSqlServerBinding();
        }
    }
}
