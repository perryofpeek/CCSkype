using System;
using System.Collections.Generic;
using CCSkype.SkypeWrapper;

namespace CCSkype
{
    public class MessengerClient : IMessengerClient
    {
        private readonly ISkype _skype;
        private IUserCollection _userCollection;
        private readonly IChats _chats;

        public MessengerClient(ISkype skype, IUserCollection userCollection, IChats chats)
        {
            _skype = skype;
            _userCollection = userCollection;
            _chats = chats;
        }

        public void SendMessage(string message, IUserCollection userCollection, string name)
        {
            _userCollection = userCollection;
            SendMessage(message, name);
        }

        public void SendMessage(string message, string name)
        {
            StartSkypeIfNotRunning();
            var chat = GetChatWindow(name);
            chat.SendMessage(message);
        }

        private IChat GetChatWindow(string name)
        {
            var chat = _chats.Get(name, _userCollection);
            chat.OpenWindow();
            return chat;
        }

        private void StartSkypeIfNotRunning()
        {
            if (!_skype.SkypeClient().IsRunning())
            {
                _skype.SkypeClient().Start(false, true);
            }
        }

        public void SetUserList(List<User> users)
        {
            users.ForEach(AddUser);          
        }

        private void  AddUser(User user)
        {
            _userCollection.Add(_skype.GetUser(user.Username));            
        }

        public bool AllKnownUsers(List<User> users)
        {
            StartSkypeIfNotRunning();
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