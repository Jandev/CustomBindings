using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HttpBinding.HttpCommand;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace HttpBinding
{
    [Extension(nameof(HttpBinding))]
    public class HttpBinding : IExtensionConfigProvider
    {
        internal static HttpClient HttpClient;

        public void Initialize(ExtensionConfigContext context)
        {
            var ruleQuery = context.AddBindingRule<HttpAttribute>();
            var ruleCommand = context.AddBindingRule<HttpCommandAttribute>();
            ruleQuery.BindToInput<HttpModel>(BuildFromAttribute);
            ruleCommand.BindToCollector<HttpCommand.HttpCommand>(attribute => new HttpCommandAsyncCollector(attribute));
        }

        private async Task<HttpModel> BuildFromAttribute(
            HttpAttribute attribute,
            CancellationToken cancellationToken)
        {
            if (HttpBinding.HttpClient == null)
            {
                HttpBinding.HttpClient = attribute.HttpClient ?? new HttpClient();
            }

            var response = await HttpClient.GetAsync(attribute.Url, cancellationToken);

            return new HttpModel
            {
                Response = await response.Content.ReadAsStringAsync(),
                ResponseCode = (int)response.StatusCode
            };
        }
    }
}
