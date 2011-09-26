namespace CCSkype.SkypeWrapper
{
    public interface IUserCollection
    {
        SKYPE4COMLib.UserCollection GetUserCollection { get; }
        void Add(User user);
    }
}