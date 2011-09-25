using System.Collections.Generic;
using SKYPE4COMLib;

namespace CCSkype
{
    public class SkypeClient : ISkypeClient 
    {
        private Skype _skype;

        public SkypeClient(Skype skype)
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
            if (_skype.Client.IsRunning == false)
            {
                _skype.Client.Start(false, true);
            }
        }

        private UserCollection _userCollection;

        public void SetUserList(List<User> users)
        {
           _userCollection = new UserCollection();
            foreach (var user in users)
            {
                _userCollection.Add(_skype.get_User(user.Username));
            }           
        }
    }
}