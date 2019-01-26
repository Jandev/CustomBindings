using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using MyFirstCustomBindingLibrary;

namespace CustomBindingFunction
{
    public static class CustomBindingFunction
    {
        [FunctionName("CustomBindingFunction")]
        public static IActionResult RunCustomBindingFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "custombinding/{name}")]
            HttpRequest req,
            string name,
            [MySimpleBinding(Location = "%filepath%\\{name}")]
            MySimpleModel simpleModel)
        {
            return (ActionResult) new OkObjectResult(simpleModel.Content);
        }
    }
}
