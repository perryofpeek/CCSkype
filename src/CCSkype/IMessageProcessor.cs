namespace CCSkype
{
    public interface IMessageProcessor
    {
        IResponse Process(string message);
    }
}