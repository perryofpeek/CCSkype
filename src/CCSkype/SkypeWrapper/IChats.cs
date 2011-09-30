namespace CCSkype.SkypeWrapper
{
    public interface IChats
    {
        IChat Get(string name, IUserCollection userCollection);
    }
}