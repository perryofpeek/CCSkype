using System.Collections.Generic;

namespace CCSkype
{
    public interface IMessengerClient
    {
        void SendMessage(string message);
        
        void SetUserList(List<User> users);
    }
}