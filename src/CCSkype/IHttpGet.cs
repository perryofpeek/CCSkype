namespace CCSkype
{
    public interface IHttpGet
    {
        string ResponseBody { get; }
        
        int StatusCode { get; }
        
        double ResponseTime { get; }
        
        void Request(string url);
    }
}