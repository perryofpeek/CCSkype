using System.Collections.Generic;

namespace CCSkype
{
    public class UserGroup : IUserGroup
    {
        private readonly IMessengerClient _messengerClient;

        private readonly List<User> _users;
        
        public string Name { get; private set; }

        public UserGroup(IMessengerClient messengerClient, List<User> users, string name)
        {
            Name = name;
            _messengerClient = messengerClient;
            _users = users;
        }

        public void Send(string message)
        {
            _messengerClient.SetUserList(_users);
            _messengerClient.SendMessage(message, Name);            
        }
    }
}