using SKYPE4COMLib;

namespace CCSkype.Skype1
{
    public class SkypeUserCollection
    {
        private readonly UserCollection _userCollection;

        public SkypeUserCollection(UserCollection userCollection)
        {
            _userCollection = userCollection;
        }

        public UserCollection GetUserCollection
        {
            get { return _userCollection; }
        }
    }

    public class SkypeChat
    {
        private readonly Chat _chat;

        public SkypeChat(Chat chat)
        {
            _chat = chat;
        }

        public Chat GetChat
        {
            get { return _chat; }
        }

        public void OpenWindow()
        {
            _chat.OpenWindow();
        }

        public void Leave()
        {
            _chat.Leave();
        }

        public void SendMessage(string message)
        {
            _chat.Leave();
        }
    }

    public class SkypeWrapper
    {
        private Skype _skype;

        public SkypeWrapper()
        {
            _skype = new Skype();
        }

        public Skype_Client Skype_Client()
        {
            return new Skype_Client(_skype.Client);
        }

        public SkypeChat CreateChatMultiple(SkypeUserCollection userCollection)
        {
            return new SkypeChat(_skype.CreateChatMultiple(userCollection.GetUserCollection));
        }
    }

    public class Skype_Client
    {
        private readonly Client _client;

        public Skype_Client(Client client)
        {
            _client = client;
        }

        public Client GetClient()
        {
            return _client;
        }

        public bool IsRunning()
        {
            return _client.IsRunning;
        }

        public void Start(bool minimised,bool noSplash)
        {
            _client.Start(minimised, noSplash);
        }
    }


    public class SkypeUser
    {
        private readonly SKYPE4COMLib.User _user;

        public SkypeUser(SKYPE4COMLib.User user)
        {
            _user = user;
        }

        public SKYPE4COMLib.User GetUser()
        {
            return _user;
        }
    }
}