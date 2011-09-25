using System.Collections.Generic;

namespace CCSkype
{
    public class UserGroup : IUserGroup
    {
        private readonly ISkypeClient _skypeClient;

        private readonly List<User> _users;
        
        public string Name { get; private set; }

        public UserGroup(ISkypeClient skypeClient, List<User> users, string name)
        {
            Name = name;
            _skypeClient = skypeClient;
            _users = users;
        }

        public void Send(string message)
        {
            _skypeClient.SetUserList(_users);
            _skypeClient.SendMessage(message);            
        }
    }
}