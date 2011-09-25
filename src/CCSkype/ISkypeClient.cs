using System.Collections.Generic;

namespace CCSkype
{
    public interface ISkypeClient
    {
        void SendMessage(string message);
        void SetUserList(List<User> users);
    }
}