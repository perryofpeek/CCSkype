using System;
using System.Collections.Generic;
using SKYPE4COMLib;
using UserCollection = CCSkype.SkypeWrapper.UserCollection;

namespace CCSkype
{
    public class MessengerClient : IMessengerClient
    {
        private readonly SkypeWrapper.ISkype _skype;
        private SkypeWrapper.IUserCollection _userCollection;

        public MessengerClient(SkypeWrapper.ISkype skype, SkypeWrapper.IUserCollection userCollection)
        {
            _skype = skype;
            _userCollection = userCollection;
        }

        public void SendMessage(string message, SkypeWrapper.IUserCollection userCollection)
        {
            _userCollection = userCollection;
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            StartSkype();
            var chat = _skype.CreateChatMultiple(_userCollection);
            chat.OpenWindow();
            try
            {
                chat.SendMessage(message);
                chat.Leave();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }

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
            foreach (var user in users)
            {
                var x = _skype.GetUser(user.Username);
                _userCollection.Add(x);
            }
        }

        public bool AllKnownUsers(List<User> users)
        {
            var skypeUsers = _skype.GetUsers();

            foreach (var user in users)
            {
                if (!skypeUsers.Contains(user.Username))
                {
                    throw new UserNotKnowException(user.Username);                    
                }
            }
            return true;
        }
    }
}