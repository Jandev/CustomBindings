using System;
using Microsoft.Azure.WebJobs.Description;

namespace MyFirstCustomBindingLibrary
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class MySimpleBindingAttribute : Attribute
    {
        /// <summary>
        /// Path to the folder where a file should be written.
        /// </summary>
        [AutoResolve]
        public string Location { get; set; }
    }
}
