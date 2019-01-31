using System;
using Microsoft.Azure.WebJobs;

namespace SqlServerBinding
{
    public static class SqlServerExtension
    {
        public static IWebJobsBuilder AddSqlServerBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SqlServer>();
            return builder;
        }
    }
}
