namespace CCSkype.SkypeWrapper
{
    public class Skype : ISkype
    {
        private SKYPE4COMLib.Skype _skype;

        public Skype()
        {
            _skype = new SKYPE4COMLib.Skype();
        }

        public IClient SkypeClient()
        {
            return new Client(_skype.Client);
        }

        public IChat CreateChatMultiple(IUserCollection userCollection)
        {
            return new Chat(_skype.CreateChatMultiple(userCollection.GetUserCollection));
        }

        public User Get_User(string username)
        {
            return new User(_skype.get_User(username));
        }
    }
}