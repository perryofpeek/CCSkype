using System.Collections.Generic;
using SKYPE4COMLib;
using UserCollection = CCSkype.SkypeWrapper.UserCollection;

namespace CCSkype
{
    public class MessengerClient : IMessengerClient 
    {
        private SkypeWrapper.Skype _skype;

        public MessengerClient(SkypeWrapper.Skype skype)
        {
            _skype = skype;
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
            if (_skype.Skype_Client().IsRunning() == false)
            {
                _skype.Skype_Client().Start(false, true);
            }
        }

        private UserCollection _userCollection;

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