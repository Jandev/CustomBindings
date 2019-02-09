using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace HttpBinding.HttpCommand
{
    public class HttpCommandAsyncCollector : IAsyncCollector<HttpCommand>
    {
        private readonly HttpCommandAttribute attribute;
        private readonly List<InternalHttpCommand> commandCollection;

        public HttpCommandAsyncCollector(HttpCommandAttribute attribute)
        {
            this.attribute = attribute;
            this.commandCollection = new List<InternalHttpCommand>();
        }

        public Task AddAsync(global::HttpBinding.HttpCommand.HttpCommand item, CancellationToken cancellationToken = new CancellationToken())
        {
            if (HttpBinding.HttpClient == null)
            {
                HttpBinding.HttpClient = attribute.HttpClient ?? new HttpClient();
            }

            commandCollection.Add(new InternalHttpCommand(item.Body, attribute.MediaType));
            
            return Task.CompletedTask;
        }

        public async Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            switch (this.attribute.HttpMethod)
            {
                case "POST":
                    await SendPost(cancellationToken);
                    break;
                case "PUT":
                    await SendPut(cancellationToken);
                    break;
                default:
                    throw new NotImplementedException("The selected HttpMethod is not implemented in this binding. Supported methods are `POST`, `PUT`.");

            }
        }

        private async Task SendPut(CancellationToken cancellationToken)
        {
            foreach (var command in commandCollection)
            {
                await HttpBinding.HttpClient.PutAsync(attribute.CommandUrl, command.Content, cancellationToken);
            }
        }

        private async Task SendPost(CancellationToken cancellationToken)
        {
            foreach (var command in commandCollection)
            {
                await HttpBinding.HttpClient.PostAsync(attribute.CommandUrl, command.Content, cancellationToken);
            }
        }
    }
}