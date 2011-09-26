using System.Collections.Generic;
using SKYPE4COMLib;
using UserCollection = CCSkype.SkypeWrapper.UserCollection;

namespace CCSkype
{
    public class MessengerClient : IMessengerClient 
    {
        private readonly SkypeWrapper.ISkype _skype;
        private SkypeWrapper.IUserCollection _userCollection;

        public MessengerClient(SkypeWrapper.ISkype skype)
        {
            _skype = skype;
        }

        public void SendMessage(string message,SkypeWrapper.IUserCollection userCollection)
        {
            _userCollection = userCollection;
            SendMessage(message);
        }

        public void SendMessage(string message)
        {           
            StartSkype();                                   
            var chat = _skype.CreateChatMultiple(_userCollection);
            chat.OpenWindow();            
            chat.SendMessage(message);
            chat.Leave();
        }

        private void StartSkype()
        {
            if (_skype.SkypeClient().IsRunning() == false)
            {
                _skype.SkypeClient().Start(false, true);
            }
        }        

        public void SetUserList(List<User> users)
        {
           _userCollection = new UserCollection(new UserCollectionClass());            
            foreach (var user in users)
            {
                _userCollection.Add(_skype.Get_User(user.Username));
            }           
        }
    }
}