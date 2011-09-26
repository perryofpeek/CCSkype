namespace CCSkype.SkypeWrapper
{
    public interface ISkype
    {
        IClient SkypeClient();

        IChat CreateChatMultiple(IUserCollection userCollection);
        
        User Get_User(string username);
    }
}