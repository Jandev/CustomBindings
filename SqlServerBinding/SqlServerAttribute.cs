using System;
using Microsoft.Azure.WebJobs.Description;

namespace SqlServerBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class SqlServerAttribute : Attribute
    {
        [ConnectionString(Default = "SqlServerConnectionString")]
        public string ConnectionString { get; set; }

        [AutoResolve]
        public string Query { get; set; }
    }
}
