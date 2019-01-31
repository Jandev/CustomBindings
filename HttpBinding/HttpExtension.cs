using System;
using Microsoft.Azure.WebJobs;

namespace HttpBinding
{
    public static class HttpExtension
    {
        public static IWebJobsBuilder AddHttpBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<HttpBinding>();
            return builder;
        }
    }
}
