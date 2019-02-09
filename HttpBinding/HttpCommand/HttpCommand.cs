namespace HttpBinding.HttpCommand
{
    public class HttpCommand
    {
        public string Body { get; set; }

        public HttpCommand(string body)
        {
            this.Body = body;
        }
    }
}