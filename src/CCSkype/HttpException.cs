using System;

namespace CCSkype
{
    public class HttpException : Exception
    {
        public HttpException(string message) : base(message)
        {
        }
    }
}