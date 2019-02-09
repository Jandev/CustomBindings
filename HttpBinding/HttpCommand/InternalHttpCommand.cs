using System.Net.Http;
using System.Text;

namespace HttpBinding.HttpCommand
{
    internal class InternalHttpCommand
    {
        public HttpContent Content { get; set; }

        public InternalHttpCommand(string body, string mediaType)
        {
            this.Content = new StringContent(body, Encoding.UTF8, mediaType);
        }
    }
}