namespace CCSkype
{
    public class EndpointImpl : IEndPoint
    {
        private readonly IHttpGet _httpGet;
        private readonly string _url;

        public EndpointImpl(IHttpGet httpGet, string url)
        {
            _httpGet = httpGet;
            _url = url;
        }

        public string GetXml()
        {
            _httpGet.Request(_url);
            if (_httpGet.StatusCode != 200)
            {
                throw new HttpException(string.Format("Http status code is {0}", _httpGet.StatusCode));
            }
            return _httpGet.ResponseBody;
        }
    }
}