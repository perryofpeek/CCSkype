namespace CCSkype
{
    public class Response : IResponse
    {
        public Response(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public string Message { get; private set; }

        public bool Success { get; private set; }
    }
}
