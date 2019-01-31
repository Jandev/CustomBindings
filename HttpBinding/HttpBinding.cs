using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace HttpBinding
{
    [Extension(nameof(HttpBinding))]
    public class HttpBinding : IExtensionConfigProvider
    {
        private static HttpClient httpClient;

        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<HttpAttribute>();
            rule.BindToInput<HttpModel>(BuildFromAttribute);
        }

        private async Task<HttpModel> BuildFromAttribute(
            HttpAttribute attribute,
            CancellationToken cancellationToken)
        {
            if (httpClient == null)
            {
                httpClient = attribute.HttpClient ?? new HttpClient();
            }

            var response = await httpClient.GetAsync(attribute.Url, cancellationToken);

            return new HttpModel
            {
                Response = await response.Content.ReadAsStringAsync(),
                ResponseCode = (int)response.StatusCode
            };
        }
    }
}
