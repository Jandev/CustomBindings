using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace SqlServerBinding
{
    [Extension(nameof(SqlServer))]
    public class SqlServer : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            throw new NotImplementedException();
        }
    }
}
