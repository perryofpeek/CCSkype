using System.Collections.Generic;

namespace CCSkype.SkypeWrapper
{
    public class Skype : ISkype
    {
        private SKYPE4COMLib.Skype _skype;

        public Skype()
        {
            _skype = new SKYPE4COMLib.Skype();
        }

        public IClient SkypeClient()
        {
            return new Client(_skype.Client);
        }

        public IChat CreateChatMultiple(IUserCollection userCollection, string name)
        {
            var userCol = userCollection.GetUserCollection;
            var chat = _skype.CreateChatMultiple(userCol);
            chat.Description = name;
            return new Chat(chat, name);
        }

        public IUser GetUser(string username)
        {
            return new User(_skype.get_User(username));
        }

        public List<string> GetUsers()
        {
            var f = _skype.Friends;
            return new UserCollection(f).GetUsers();
        }
    }
}