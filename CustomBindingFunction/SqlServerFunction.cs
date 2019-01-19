using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using SqlServerBinding;

namespace CustomBindingFunction
{
    public static class SqlServerFunction
    {
        [FunctionName(nameof(GetSingleRecord))]
        public static IActionResult GetSingleRecord(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = nameof(GetSingleRecord))]
            HttpRequest req,
            [SqlServer(Query = "SELECT TOP 1 Id, EventName, EventDescription FROM Cfps")]
            SqlServerModel model)
        {
            return (ActionResult)new OkObjectResult(model.Record.Id);
        }

        [FunctionName(nameof(GetCollectionFromSqlServer))]
        public static IActionResult GetCollectionFromSqlServer(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = nameof(GetCollectionFromSqlServer))]
            HttpRequest req,
            [SqlServer(Query = "SELECT TOP 100 Id, EventName, EventDescription FROM Cfps")]
            IEnumerable<SqlServerModel> collection)
        {
            return (ActionResult)new OkObjectResult(collection.Select(m => m.Record.Id));
        }
    }
}
