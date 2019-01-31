using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Description;

namespace HttpBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class HttpAttribute : Attribute
    {
        [AutoResolve]
        public string Url { get; set; }

        /// <summary>
        /// If you have already instantiated an <seealso cref="System.Net.Http.HttpClient"/>, pass it to this property.
        /// </summary>
        public HttpClient HttpClient { get; set; }
    }
}
