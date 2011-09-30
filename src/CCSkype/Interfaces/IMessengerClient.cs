using System.Collections.Generic;

namespace CCSkype
{
    public interface IMessengerClient
    {
        void SendMessage(string message, string name);
        
        void SetUserList(List<User> users);
        
        bool AllKnownUsers(List<User> users);
    }
}