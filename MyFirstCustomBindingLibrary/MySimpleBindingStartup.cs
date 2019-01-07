using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using MyFirstCustomBindingLibrary;

[assembly: WebJobsStartup(typeof(MySimpleBindingStartup))]
namespace MyFirstCustomBindingLibrary
{
    public class MySimpleBindingStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddMySimpleBinding();
        }
    }
}
