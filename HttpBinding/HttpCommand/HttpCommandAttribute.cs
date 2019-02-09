using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Description;

namespace HttpBinding.HttpCommand
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class HttpCommandAttribute : Attribute
    {
        public HttpClient HttpClient { get; set; }

        public string MediaType { get; set; }

        public HttpMethod HttpMethod { get; set; }
        public string CommandUrl { get; set; }
    }
}