namespace CCSkype
{
    public interface IUserGroup
    {
        string Name { get; }
        void Send(string message);
    }
}