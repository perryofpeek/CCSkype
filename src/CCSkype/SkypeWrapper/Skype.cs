namespace CCSkype.SkypeWrapper
{
    public class Skype
    {
        private SKYPE4COMLib.Skype _skype;

        public Skype()
        {
            _skype = new SKYPE4COMLib.Skype();
        }

        public Client Skype_Client()
        {
            return new Client(_skype.Client);
        }

        public Chat CreateChatMultiple(UserCollection userCollection)
        {
            return new Chat(_skype.CreateChatMultiple(userCollection.GetUserCollection));
        }

        public User Get_User(string username)
        {
            return new User(_skype.get_User(username));
        }
    }
}