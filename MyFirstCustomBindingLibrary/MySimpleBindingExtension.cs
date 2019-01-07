using System;
using Microsoft.Azure.WebJobs;

namespace MyFirstCustomBindingLibrary
{
    public static class MySimpleBindingExtension
    {
        public static IWebJobsBuilder AddMySimpleBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<MySimpleBinding>();
            return builder;
        }
    }
}
