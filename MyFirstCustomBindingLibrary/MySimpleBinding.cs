using System.IO;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;


namespace MyFirstCustomBindingLibrary
{
    /// <summary>
    /// Extension for the binding <see cref="MySimpleBindingAttribute"/>.
    /// Will enable to read files from local disk.
    /// </summary>
    public class MySimpleBinding : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<MySimpleBindingAttribute>();
            rule.BindToInput<MySimpleModel>(BuildItemFromAttribute);
        }

        private MySimpleModel BuildItemFromAttribute(MySimpleBindingAttribute arg)
        {
            string content = default(string);
            if (File.Exists(arg.Location))
            {
                content = File.ReadAllText(arg.Location);
            }

            return new MySimpleModel
            {
                FullFilePath = arg.Location,
                Content = content
            };
        }
    }
}
