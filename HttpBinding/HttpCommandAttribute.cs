using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Description;

namespace HttpBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class HttpCommandAttribute : Attribute
    {
        public HttpClient HttpClient { get; set; }
    }
}