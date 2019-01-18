using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using SqlServerBinding;

namespace CustomBindingFunction
{
    public static class SqlServerFunction
    {
        [FunctionName("SqlServerFunction")]
        public static IActionResult RunSqlServerFunction(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sqlserver")]
            HttpRequest req,
            [SqlServer(Query = "SELECT TOP 1 Id, EventName, EventDescription FROM Cfps")]
            SqlServerModel model)
        {
            return (ActionResult)new OkObjectResult(model.Record.Id);
        }
    }
}
