namespace CCSkype
{
    public interface IResponse
    {
        string Message { get; }
        bool Success { get; }
    }
}