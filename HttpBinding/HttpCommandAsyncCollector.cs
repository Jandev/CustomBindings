using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace HttpBinding
{
    public class HttpCommandAsyncCollector : IAsyncCollector<HttpCommand>
    {
        private readonly HttpCommandAttribute attribute;

        public HttpCommandAsyncCollector(HttpCommandAttribute attribute)
        {
            this.attribute = attribute;
        }

        public Task AddAsync(HttpCommand item, CancellationToken cancellationToken = new CancellationToken())
        {
            if (HttpBinding.HttpClient == null)
            {
                HttpBinding.HttpClient = attribute.HttpClient ?? new HttpClient();
            }

            throw new System.NotImplementedException();
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}